# MiniJam - Zodiac Gaia

A 4-player local multiplayer resource management game made for [Mini Jam](https://itch.io/jam/mini-jam), built with Unity.

## Overview

In **Zodiac Gaia**, four players each represent one of the four classical elements — **Water**, **Earth**, **Wood**, and **Fire**. Players compete to be the first to collect 5 of every resource type by picking up resources from the central portal and depositing them in their stores.

Each player has a timer that drains continuously. If it reaches zero, one of your stored resources is ejected back into the portal — so act fast!

## Gameplay

- **4 players** on the same machine, each with their own gamepad.
- Resources of all four types float around a central portal area.
- Pick up a resource and carry it to your store to deposit it.
- You can also withdraw a resource from your own store to trade or move it.
- The first player to accumulate **5 of each resource** in their store wins.
- A personal timer drains over time; when it expires, a resource is lost back to the portal and the timer resets.

## Controls

| Action | Player 1 | Players 2–4 |
|--------|----------|-------------|
| Move | Left Stick / WASD | Left Stick |
| Interact (pick up / deposit) | Joystick Button 0 / Left Mouse Button | Joystick Button 0 |

> Interaction triggers when a player walks into range of a portal or a store and presses the interact button.

## Getting Started

### Requirements

- **Unity 2017.3.0f3** (see `ProjectSettings/ProjectVersion.txt`)
- 1–4 gamepads (Xbox / generic) for full multiplayer; Player 1 also supports keyboard & mouse

### Opening the Project

1. Clone or download this repository.
2. Open **Unity Hub** and click **Add**, then select the repository root folder.
3. Make sure you are using Unity **2017.3.0f3**. Other versions may cause compatibility issues.
4. Once the project loads, open one of the scenes from the `Assets/` folder (e.g. `MainLevel.unity`).

### Running the Game

1. With the scene open in the Unity Editor, press the **Play** button (▶) to start.
2. Connect up to 4 gamepads before pressing Play for the best experience.
3. Player 1 can also use **WASD** to move and **Left Mouse Button** to interact.

## Project Structure

```
Assets/
├── Scripts/
│   ├── Constatants.cs        # Enums: RESOURCES (Water, Earth, Wood, Fire) and SOURCES
│   ├── GameManager.cs        # Singleton managing player resources and win condition
│   ├── Player.cs             # Player identity and hand reference
│   ├── PlayerMovement.cs     # Physics-based movement & body rotation
│   ├── PlayerTime.cs         # Per-player drain timer
│   ├── Portals.cs            # Central portal: spawn, pickup, and overflow logic
│   ├── Store.cs              # Per-player resource store: deposit and withdraw
│   ├── Resource.cs           # Resource object data (type, source)
│   ├── InteractableObject.cs # Collision-based interaction dispatcher
│   ├── ScorePanel.cs         # UI: displays resource counts and checks win condition
│   ├── SoundManager.cs       # Audio helper (take, put, timer sounds)
│   └── IInteractable.cs      # Interface implemented by Portal and Store
├── MainLevel.unity           # Main gameplay scene
├── LGO.unity                 # Logo / splash scene
├── Level2.unity              # Additional level scene
└── MAIN.prefab               # Core game prefab
ProjectSettings/              # Unity project settings
```

## Win Condition

The first player whose score panel detects **5 of every resource** (Water, Earth, Wood, Fire) stored triggers `GameManager.WinningNation()`, which freezes the game and displays the winner.

## License

This project was created for Mini Jam. Please check with the original authors before redistributing or building upon it.
