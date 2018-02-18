# pixelSurrogate
Unity 3d Asset - Texture to Mesh to Playable Pixels :)
<br><br>

### Summary
 - pixelSurrogate takes a texture and turns it's pixels into meshes.
 - With those meshes, you can code behaviours to your liking.
 - The current behaviour is _hatch, which follows the player when too close and returns when a certain distance.
 - The pixels will rebuild themselves back into the texture automatically when returning.
 
### Warning

 - Make backups prior to use. Only test this within a new project.
 - pixelSurrogate transforms all pixels in a texture to meshes. This can generate thousands of meshes in the scene.
 - 64x64 is fairly safe, however larger images will require better hardware.
 - Depending on hardware, this may freeze Unity. Force quit if that occurs.
 
 ### Sample Images
 
![anim1](https://github.com/eagleEggs/pixelSurrogate/blob/master/screenShots/pixelSurrogate_quads.png?raw=true)<br>
![anim1](https://github.com/eagleEggs/pixelSurrogate/blob/master/screenShots/pixelSurrogate_gif2.gif?raw=true)<br>
![anim1](https://github.com/eagleEggs/pixelSurrogate/blob/master/screenShots/dragon3.gif?raw=true)<br>
![anim1](https://github.com/eagleEggs/pixelSurrogate/blob/master/screenShots/pixelSurrogate_demo9.gif?raw=true)<br>

### Notes:

 - Processing time depends on hardware. Start with a smaller image (64x64) which is included in the sample scene.
 - Larger images do process, but may take more time. It is possible it can freeze Unity with too many meshes.

### Updates:

- No longer being pushed to [materialGate](https://www.github.com/eagleEggs/materialGate), this is now standalone.
