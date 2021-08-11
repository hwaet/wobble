




https://user-images.githubusercontent.com/30280876/128969225-174c5494-0211-44a0-a7c5-1c63e022e83c.mp4



# Package
A small tool for placing objects and giving them a little inflation wobble. This package requires the unity input system, and unity URP for the shader graph-based material that implements the wobble.

# Why?
It's satisfying.

# How?
Create a game object and add a buildingPlacer component to it. A wobble component will be added automatically. Modify the anim curve on the wobble and the float values to tweak to your liking. Hit play mode and click in-game to plave a building. Boing! Use the endless checkbox on the Wobble component to cycle the wobble forever, and fine tune it even further.

Currently all the wobble objects are sharing a material, and only one wobble point can exist at a time, and nearby objects will get a little AOE splash-wobble.
