Shader "Obra-Dinn Shader"
{
    Properties
    {
        _MainTex("", 2D) = "" {}
        _DitherTex("", 2D) = "" {}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"

            // Object texture
            sampler2D _MainTex;
            float2 _MainTex_TexelSize;

            // Dither texture (Set by CameraScript)
            sampler2D _DitherTex;
            float2 _DitherTex_TexelSize;

            // _Color0 = Dark Color (Set by CameraScript)
            // _Color1 = Light Color (Set by CameraScript)
            float3 _Color0;
            float3 _Color1;

            float4 frag(v2f_img i) : SV_Target
            {
                // Get color value of object texture texel
                float4 source = tex2D(_MainTex, i.uv);

                // Convert Gamma color space to Linear space
                source.rgb = GammaToLinearSpace(source.rgb);

                // Use a brightness convertion equation to get perceived brightness from linear rgb-value
                float pb = (sqrt(0.299 * source.r * source.r + 0.587 * source.g * source.g + 0.114 * source.b * source.b));

                // Get coordinate of cooresponding dither texture texel
                float2 dither_uv = i.uv * _DitherTex_TexelSize;
                dither_uv /= _MainTex_TexelSize;

                // Get alpha of said dither texel
                float dither = tex2D(_DitherTex, dither_uv).a;

                float3 finalrgb;

                // If the perceived brightness of the texture is lower than the corresponding dither alpha...
                if(pb < dither)
                {
                    //... make it the dark color
                    finalrgb = _Color0;
                }
                // If it's higher...
                else
                {
                    //... make it the light color
                    finalrgb = _Color1;
                }

                // Return the final color value
                return float4(finalrgb, 1);
            }
            ENDCG
        }
    }
}