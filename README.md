# Description

Cartoon Zombie VR Built with [Unity Engine](https://unity.com/). 

## Game Target Experience
Targeted for quick action (5-10 min) free roam experience on mobile (untethered ) VR.

# Optimization

Optimized for mobile VR, specifically, following Oculus Quest guidelines: https://developer.oculus.com/documentation/unity/unity-perf/

## Optimization methods

1. Fully baked light to remove high computation load for real time lighting
2. Decal Blob Shadows instead of real time shadows to provide sufficient immersion
3. Baked occlusion culling to render only visible objects
4. Static batching for static objects to reduce draw calls
5. Single-pass instancing to reduce load and power consumption
6. Lowpoly models to reduce triangle count
7. Balanced URP settings sufficient for immersion and computation load

### Tested Devices

Mainly tested on 'Windows Mixed Reality' with 'Lenovo Explorer' headset

Not tested with Oculus Quest, but should meet general performance requirements

Configured with 'OpenXR' and should work with compatible devices

# Launch Game

To launch the game run ['MainScene' scene](./Assets/Level/Scenes/MainScene.unity)

# Game Design

Game design related files located at [/Assets/Level/](./Assets/Level/)

Scriptable objects with game configuration are available at [/Assets/Level/Gameplay](./Assets/Level/Gameplay)

Can configure game length, enemy waves, player controls, enemies stats and skin mesh and etc.

## Level Design

Level environment built with ProBuilder and PolyBrush

# Testing

Game mainly targeted for free-roam but can enable teleport for easy testing

Check [/Assets/Level/ApplicationConfig.asset](./Assets/Level/ApplicationConfig.asset) settings to assign various game and player configs and display test info (FPS counter and etc.)
