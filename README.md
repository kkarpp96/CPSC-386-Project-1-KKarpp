# Simple Platformer for CPSC-386 Game Development Class

# Project 1 Documentation

## Scripts
### PlayerMovement.cs
    Handles player input and moves the Player GameObject by its transform and accesses its rigidbody to apply linear velocity for jumping. Also contains is_grounded checks for jumping, a maximum player fall speed constraint, a constraint to prevent glitching into walls, and logic for checking if Player has fallen off the screen.
### GameRules.cs
    Handles victory and player death conditions. It tracks timer scores to PlayerPrefs, resets player position on death, and keeps track of which level to load next when the Player collides with the Goal GameObject.
### MenuButtons.cs
    Handles start and quit buttons from the main menu and pause menu. It loads the correct scene when starting the game or returning to menu and closes the game when the main menu's quit button is pressed.
### PauseButtons.cs
    Handles game pausing by stopping and starting timeScale and activates the pause buttons and text.
### Timer.cs
    Handles the corner timer and holds the runtime timer variable that GameRules.cs retrieves when a level is completed.
### TimeScores.cs
    Displayes the correct level completion times upon beating the last level. Also compares the total time to update high score in PlayerPrefs.
### VictoryTrigger.cs
    Handles the Player GameObject colliding with the Goal GameObject. Checks for the Player tag when something enters its trigger zone and then triggers GameRules.cs' Victory() method.
### BulletSpawner.cs
    Handles bullet pooling in levels 2 and 3. It instantiates a pool of three bullets that activate when spawned and deactivate when going off the screen.
### Bullet.cs
    Handles bullet movement, bullet disabling, and player collision checks.

## Scenes
### MainMenu
    Displays game title, controls, and start and quit buttons.
### Level1
    Simple first level of the game, contains controllable Player GameObject, tilemap for level platforms, and Goal GameObject for level completion.
### Level2
    Slightly more complicated level that introduces bullets coming from offscreen at a periodic interval. Touching bullets sends player back to start.
### Level3
    Final level that introduces darkness. This level does not contain a global light, but instead is only lit by a spot light that follows the Player GameObject. The player needs to deal with a more limited view while still dodging bullets and jumping across platforms.
### VictoryScreen
    Final menu screen that displays a congratulations message, level completion times, high score, and allows player to return to the main menu.

## Requirements
### Requirement 1
    My game has 5 scenes with working gameplay and buttons.
### Requirement 2
    Player is controlled with modern input system with the input mapper and has rigidbody and collider physics.
### Requirement 3
    All ground is a Tilemap that is handled with a Tilemap Collider 2D.
### Requirement 4
    The bullets from levels 2 and 3 are handled with object pooling.
### Requirement 5
    The Goal and Bullet GameObjects have OnTriggerEnter2D methods that compare for the "Player" tag to determine loss/victory.
### Requirement 6
    All level scenes can access a pause menu that sets timeScale to 0 and can be resumed or quit to the main menu.
### Requirement 7
    The level timer scores are handled with playerprefs and are persistent when closing the game.
### Requirement 8
    Level 3 uses a 2D spot light to light the scene more selectively than the previous levels' global light.
