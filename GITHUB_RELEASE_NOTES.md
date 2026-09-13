# CustomizeLib.MelonLoader 3.9.0-ml.1

Compatibility update for **Plants vs. Zombies Fusion 3.9**.

This release updates the MelonLoader port of CustomizeLib for the new PvZ Fusion 3.9 IL2CPP assemblies. It does not add a new content API; its purpose is to keep CustomizeLib-based mods working against the 3.9 game update.

## Requirements

- PvZ Fusion 3.9
- MelonLoader 0.7.3

## Installation

1. Install MelonLoader 0.7.3 on PvZ Fusion 3.9.
2. Launch the game once so `MelonLoader/Il2CppAssemblies` is generated.
3. Remove every older copy of CustomizeLib from the game.
4. Copy `CustomizeLib.MelonLoader.dll` into the game's `Mods` folder.
5. Keep external CustomizeLib skins in `Mods/Skin`.

Do not load the old BepInEx and MelonLoader versions of CustomizeLib at the same time.

## Changes

- Updated generated IL2CPP references and build metadata for PvZ Fusion 3.9.
- Adapted zombie total-health handling to the 64-bit health values used by PvZ Fusion 3.9.
- Updated the library version to `3.9.0-ml.1`.
- Verified a clean Release build and successful MelonLoader startup on PvZ Fusion 3.9.

See the [complete changelog](CHANGELOG.md) for previous versions.
