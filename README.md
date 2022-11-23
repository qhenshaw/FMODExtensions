# FMOD Extensions
[![Unity 2021.3+](https://img.shields.io/badge/unity-2021.3%2B-blue.svg)](https://unity3d.com/get-unity/download)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](LICENSE.md)

A collection of scripts useful for playing FMOD audio in Unity.
```
This package requires FMOD Unity to be installed.
```

## System Requirements
Unity 2021.3+. Will likely work on earlier versions but this is the version I tested with.

## Installation
Use the Package Manager and use Add package from git URL, using the following: 
```
https://github.com/qhenshaw/FMODExtensions.git
```

## Usage
The following systems are included in this package.

### Collision Sounds
Add the ```FMODCollisionEmitter``` component to any GameObject with a 3D or 2D collider and configure the FMOD events.  
Collision criteria can be tuned with the exposed fields.

### Footsteps
Add the ```FMODFootsteps``` component to a character and call its ```PlayFootstep(GameObject surfaceObject)``` method through C# or with UnityEvents.  
The parameter is intended to be a reference to the surface the character is standing on.

#### Surface Paramters
Optionally, surface parameters can be added to walkable colliders. New surface materials can be created through:  
```Right Click => Create => FMOD => FMOD Surface Material```  
Any collider can then reference the material through the ```FMODSurface``` component. This allows surface types represented by a float to be sent to FMOD events using the parameter name ```Material```.
