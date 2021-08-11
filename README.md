

https://user-images.githubusercontent.com/30280876/128969050-432695d8-fbd8-40c4-9de1-b93b6aaecb75.mp4


# Package
A small tool for placing objects and giving them a little inflation wobble. This package requires the unity input system for grabbing user input in the test scene, and unity URP for the shader graph-based material that implements the wobble.

# Why?
It's satisfying.

# How?
Create a game object and add a buildingPlacer component to it. A wobble component will be added automatically. Modify the anim curve on the wobble and the float values to tweak to your liking. Use the endless checkbox to cycle the wobble and fine tune it even further.

Currently all the wobble objects are sharing a material, and only one wobble point can exist at a time, and nearby objects will get a little AOE splash-wobble.
