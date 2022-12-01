# 1-BIT OBRA DINN STYLE DITHERING SHADER
by Tobias Risom (Medialogy, 5th Semester)

The **1-Bit Obra Dinn Style Dithering Shader** shader is a one-bit bi-tonal shader for Unity, inspired by Lucas Pope's "Return of the Obra Dinn". It makes use of a 4x4 dithering texture, defined and created using a dithering table, instead of a pre-existing texture. 
Made in Unity Version 2021.3.9f1.

The project comes with 2 scenes:

**Obra Dinn Scene** - A 3D "museum" environment where the player can walk around and look at different setups and see how they interact with the shader, such as objects in- and out of shadow.

**GreyScaleDemoScene** - A simple scene showing a greyscale texture. Vizualizes the dither effect.

### Installation
Clone the repository to your device, and open it with Unity.

### Usage
The project is set up so the shader works without additional configuration.
To use the shader in other projects, simply attach the "Camera Script" script to the scene's Main Camera, and make sure the "Obra-Dinn Shader" is set as the script's public shader property.

### Acknowledgements
Shader based on [Binary](https://github.com/keijiro/KinoBinary) by [Keijiro](https://github.com/keijiro).
Shader inspired by [Return of the Obra Dinn](https://store.steampowered.com/app/653530/Return_of_the_Obra_Dinn/) by [Lucas Pope](https://dukope.com/).
Design inspired by Pope's [Obra Dinn TIGSource Blog](https://forums.tigsource.com/index.php?topic=40832.0).
"Perceived Brightness" equation by [Darel Rex Finley](https://alienryderflex.com/hsp.html).
