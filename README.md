# GameClue

This is a game platform for researching effects of audiovisual cues.

# Start contribution

This game is created using Unity. If you want to get the code base running install Unity, load the project and drag any scene in the Assets/Scenes folder to the unity scene hierarchy.


# Purpose

The idea was to create an easily modifiable shoot 'em up game, that could be used to research the effects of audiovisual cues on games. The idea behind easy modification was to enable further research on the subject if the first research found any interesting results (which it did). 

This application was initially developed as an platform, that could run and change the content without compiling the source code through Unity, and that is still part of the future possibilities with this application, but in its current state this project is nowhere near that goal. But to enable this goal (and to use Unity as it was intented), everything component based. Every gameObject is just a collection of scripts that define its behavior, and every single scripts file does only one thing. 

e.g. this project does not have a script for an asteroid enemy, but it does have a StraightMovement script and DebrisOnDeath (which is a subclass of Killable) script.

# Usage as is

There is a release branch that includes Windows binaries, but if you want to compile the sources yourself, then:

## Get it to run

1. Install Unity
1. Open the project folder in Unity
1. Drag SplashScreenScene to scene hierarchy
1. Run the game in Unity editor of compile the game

## Controls

* Arrow keys and IJKL move the player.
* Space bar shoots
* Ctrl + 1 changes to a random scene (or level, however you want to think about them.) This is the only way to change between scenes.
* Ctrl + 0 changes to a full game scene, where every game mechanic is active.
* Alt + F7 - F11 changes scene nonrandomly (i.e. F7 always activates BaseGameScene, F8 activates PointGameScene etc.)



# Modifying instruction

If you are interested in trying to create a game using this project as your base, then use the following instructions to change stuff around:

## Naming convention:
* If scripts require you to drag elements to them in Unity Editor then naming conventions tell you what kind of component needs to be dragged to that component.
* If you should drag a prefab to a script, then the handle for that is named with a "prefab" suffix. (e.g. enemyPrefabs in EnemySpawner)
* If you should drag a component from the same gameObject to a script, then the handle does not have a suffix. (e.g. rigidBody in almost all movement scripts)
* If you should drag another gameObject from a scene to a prefab to a script, then the handles is named with "object" suffix.


## Creating new scenes:

1. Go to Assets/Scenes and duplicate any scene you want to use as a base for your new scene. (OnDeathScene and SplashScreen are special scenes, and are not covered by these instructions)
1. Remove the enemy spawner gameObject from the scene. This is named `~something~Spawner`, and contains three children.
1. Go to `Assets/Prefabs/Spawners/EnemySpawners`.
1. Select an enemy spawner you want to use, or create a new one. (Note: if you change any existing spawner without duplicating it, then the change applies also to all scenes that use that spawner.)
	1. To create a new enemySpawner, copy an existing enemySpawner prefab, and change it's `EnemyList->defaultPrefabs` and `EnemySpawner->enemyPrefabs`
	1. `EnemySpawner->enemyPrefabs` is the list of prefabs that enemySpawner can spawn. All enemies that can appear in the scene should be included here.
	1. `EnemyList->defaultPrefabs` is used by SpawnList to create the enemy spawning pattern using the seed given in EnemySpawner. This list can include multiple copies of a prefab in order to control the spawning probability.
1. Drag your selected enemy spawner to the scene to replace the spawner you removed from the scene previously.
1. Add any other gameObjects you want to that scene.
1. Go to File->Build Settings and add your new scene to Scenes in Build.
1. If you want to add your scene to the randomized scene flow, go to the MutationManager and add the name of your scene to the private List named "mutations".

## Creating new enemies:

1. Create new gameObject that contains a RigidBody2D and SpriteRenderer.
1. Add sprite to SpriteRenderer and make sure that the collider in RigidBody2D is proper size to your sprite.
1. Add one script from `Assets/AI/Movement` to that gameObject
1. Add one script from `Assets/AI/Collision` to that gameObject
1. Add other scripts that the AI needs for its behavior.
1. Create a prefab from the gameObject by dragging it into the prefabs folder in Unity Editor.
	1. (Remove the gameObject from the active scene)
1. Open the prefab for the spawner you use in the scene the enemy is meant to spawn in (found in `Assets/Prefabs/Spawners/EnemySpawners`).
1. Drag the enemy prefab to the spawner prefab's `EnemyList->defaultPrefabs` and `EnemySpawner->enemyPrefabs`


# To do

There is no road map as such, but this project has a [kanban board](https://github.com/unioulu/gameclue-spacegame/projects/1), that lists all features that still need to be implemented.

Currently this application does not support easily swappable graphics and animations, which is the biggest shortcoming of this project if it is meant to be used for other similar research projects. Luckiliy swapping sprites is easy in Unity, and animations are learnable after a couple of hours of googling.
