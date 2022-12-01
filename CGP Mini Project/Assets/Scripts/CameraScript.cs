using UnityEngine;

// Used to see changes without going into Play mode
[ExecuteInEditMode]

// Script needs a camera for OnRenderImage to function properly
[RequireComponent(typeof(Camera))]

public class CameraScript : MonoBehaviour
{
    // ObraDinnShader
    public Shader _shader;

    // Empty material
    Material _material;

    // Runs after the camera has finished rendering - allows for modification of the final image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        // If no material is present, a material is created for the shader
        if (_material == null)
        {
            _material = new Material(_shader);
        }

        // Create the dither texture
        // A Texture2D of size 4,4 is initialized
        Texture2D tex = new Texture2D(4, 4);

        // The 16 pixels in the dither texture are set here
        // Values are the same as the Dithering Table in Lecture 6, converted to Color32
        // The shader relies on the transparency of the dither texture, so the transparency is set the same as the color value
        tex.SetPixel(0, 0, new Color32(15, 15, 15, 15));     tex.SetPixel(1, 0, new Color32(135, 135, 135, 135)); tex.SetPixel(2, 0, new Color32(45, 45, 45, 45));     tex.SetPixel(3, 0, new Color32(165, 165, 165, 165));
        tex.SetPixel(0, 1, new Color32(195, 195, 195, 195)); tex.SetPixel(1, 1, new Color32(75, 75, 75, 75));     tex.SetPixel(2, 1, new Color32(225, 225, 225, 255)); tex.SetPixel(3, 1, new Color32(105, 105, 105, 105));
        tex.SetPixel(0, 2, new Color32(60, 60, 60, 60));     tex.SetPixel(1, 2, new Color32(180, 180, 180, 180)); tex.SetPixel(2, 2, new Color32(30, 30, 30, 30));     tex.SetPixel(3, 2, new Color32(150, 150, 150, 150));
        tex.SetPixel(0, 3, new Color32(240, 240, 240, 240)); tex.SetPixel(1, 3, new Color32(120, 120, 120, 120)); tex.SetPixel(2, 3, new Color32(210, 210, 210, 210)); tex.SetPixel(3, 3, new Color32(90, 90, 90, 90));

        // Sets the filtermode of the texture to point, so it can be scaled up and down without distoring the texture
        tex.filterMode = FilterMode.Point;

        // Applies the texture
        tex.Apply();
        
        // Sets the texture, as well as the two colors, in the material
        _material.SetTexture("_DitherTex", tex);
        _material.SetColor("_Color0", new Color(0.1882353f, 0.1960784f, 0.09803922f));
        _material.SetColor("_Color1", new Color(0.9058824f, 1, 0.9921569f));

        // Read pixels from the camera's image, and modify the image by applying the material
        Graphics.Blit(source, destination, _material);
    }
}