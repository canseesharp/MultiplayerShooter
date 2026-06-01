# MultiplayerShooter
## About the game
MultiplayerShooter is a networked first-person shooter prototype built with Unity using Netcode for GameObjects. The project was created as a learning and portfolio project focused on multiplayer gameplay programming, character animation systems, and modular weapon architecture.

The gameplay is inspired by classic deathmatch modes from the Counter-Strike series, where players have an infinite amount of respawns with full armor, and come back within a few seconds of their death.

On the releases page, you can download and test the prototype.

## Gameplay video

https://github.com/user-attachments/assets/d21ba900-d766-4c7c-b4f7-d79066517749

The gameplay was recorded using two computers, one running Linux and the other running Windows, located more than 350 km apart.

## Features
- Multiplayer gameplay using Netcode for GameObjects
- First-person shooter mechanics
- Host-client networking architecture
- Health and damage system
- Deathmatch-style gameplay
- Modular weapon system for easy weapon expansion
- Animated player characters using Animation Controllers and Blend Trees
- Inverse Kinematics (IK) for weapon handling
- HUD with health bar
- Screen shake feedback when taking damage
- Designed with possible scalability in mind

## Tech Stack
- Unity
- C#
- Netcode for GameObjects
- VContainer
- Shader Graph
- Blender (for 3D models)

## Architecture Decisions
### Networking
The project uses Unity's Netcode for GameObjects to synchronize:
- Player movement
- Weapon firing
- Damage calculation
- Health
- Animations

### Weapon System
A modular weapon architecture was implemented to simplify the addition of new weapon types.

Current implementation includes:
- Pistol weapon
- Shooting mechanics
- Equiping mechanics
- Damage applying
- Muzzle flash particle effects

The system was designed with scalability in mind, allowing additional weapons to be integrated with minimal code.

### Character Animation
The character animation is done by Animator Controller state machines and Blend Trees for smooth movement transitions. Also IK is used to ensure the character's hands align correctly with the weapon and that the aiming direction visually matches the target.

### Damage feedback:
- Health display on the HUD
- Screen shake effect when receiving damage

These systems improve gameplay readability and player feedback.

### Dependency Injection

The project uses VContainer to manage some dependencies.

## What I Learned
- Multiplayer game development
- Network synchronization
- First-person shooter architecture
- Dependency Injection in Unity via VContainer
- Blend Trees and IK
- Modular game systems design
