# Unity-3D-FPS-Controller
A modular First-Person character controller built with Unity's New Input System, featuring smooth movement and camera mechanics.
A high-performance movement script for Unity 3D, optimized for the **New Input System**.

Features;
- Modern Input Handling: Uses `UnityEngine.InputSystem` for cross-platform compatibility.
- Physics-Based Movement: Integrated with Unity's `CharacterController`.
- Customizable Mechanics: Easily adjustable speed, gravity, and look sensitivity parameters.
- Smooth Camera: Clamped vertical rotation to prevent 360-degree camera flips.

SETUP;
1. Ensure the *Input System* package is installed via Unity Package Manager.
2. Attach this script to your Player object.
3. Assign the Main Camera to the `playerCamera` slot in the Inspector.
4. Set the "Ground" layer for correct collision detection.
