# CMPM-163
Git repository for CMPM 163 at UCSC.


# Lab 2 - https://drive.google.com/file/d/1cpRHiODJSGLHp9TaBB26he9fIgDrrXmb/view?usp=sharing

![](images/Offering.PNG)

# Lab 3 - https://drive.google.com/open?id=1qaqewG9cD1PKVh7JALFky76aXBXGuTAe
The cube furthest to the left has a dark grey color with a phong shader using a purple specular highlight (0xccaaee)
The second farthest left cube is similar, it has a slightly brighter base color, and uses toon shading instead. It's specular highlight is bright blue (0xcaefff)
The two cubes on the far right are using fragment shaders.
  - the one on top is my shader, it hard cuts between different colors depending on the position of the pixel, it's decided by a chain of ifs.
  - the one on the bottom is using the shader from the tutorial, I only changed the colors

# Lab 4 - https://drive.google.com/open?id=1w--Ka9igTD6xp0TjlD2WUenKjspdIffD

Video: bottom row is part 1, top two are part 2, the cube on the top left is tiled

Part 1:
  What is a formula to get the x coordinate of the texture given a u value of the uv coordinate (a value between 0 and 1)?
  
  xMax = maximum value for x
  
  u * xMax = x coordinate
  
  What is a formula to get the y coordinate of the texture given a v value of the uv coordinate (a value between 0 and 1)?
  
  yMax = maximum value for y
  
  u * yMax = y coordinate
  
  What color is sampled from the texture at the uv coordinate (0.375, 0.25)?
  
  The color is white

Part 2:
This code makes a new vec2 that will sample the whole texture over uv values (0,0) to (0.5,0.5), then start over thus tiling. I use tiledUv instead of vUv.
vec2 tiledUv;
	tiledUv.x = mod(vUv.x, 0.5) * 2.0;
	tiledUv.y = mod(vUv.y, 0.5) * 2.0;
	
# Lab 5 - https://drive.google.com/open?id=1uzfL847hvurWRQMt5TgZgROr39hJ947u
The particle is very similar to the one from the tutorial, the color is changed but the sprite is the same, only some minor tweaks otherwise. I added four boxes around the track that when entered, rotates the sun around the map, and rotates the directional light, it's a little buggy, I'm still learning about quaternions as rotation. Lastly I tweaked the material for the sun by swapping the albedo for an emmision texture, I think it works pretty well.

# Lab 6 - no video
![](images/Lab6Scene.PNG)
A directional light behaves like the sun, it shines on everything no matter where it is, the angle that it shines can be changed.

A spot light points like a flashlight, it shines in a direction from a point, the angle of its cone of light can be changed. the one in my scene is green, and moves.

A point light behaves like a lightbulb, it shines in all directions from its position. Mine is in the top right of the scene, it's blue

An area light is confusing, it shines from an area, only works with baked lighting, and requires light probes, in my scene the area light behaves weird, it is on the floor in the corner, its color is blue.

I made a texture to mimic my housemate's waterbottle ![](images/Bottle.JPG) ![](images/Lab6Mat.PNG)

I got the image textures from here - opengameart.org. I used marble and stacked stone.

My skybox uses Unity's procedural skybox, I changed the colors of the atmosphere and ground, and removed the sun.
