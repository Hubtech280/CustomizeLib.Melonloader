# Changelog

[Version française](CHANGELOG_FR.md)

## 4.0.5.2-ml.5 — 2026-10-18

- Updated game references and runtime metadata for PvZ Fusion 4.0.5.2.
- Removed the obsolete MixBombCheck hook and setter calls on getter-only TypeMgr collections.
- Restored missing custom plant unlock/stat entries after native initialization and unlock updates. Existing unlock values are retained.
- Added limited custom Almanac card diagnostics (six per session).
- Preserved native placement by bypassing the legacy custom-click dispatcher that caused fatal CLR errors. This dispatcher is not available in this build.
- Release build and offline patch-target audit checked against the installed game assemblies. Full coverage of consumer mods remains unverified.

## 4.0.0-ml.1

- Rebuilt against the generated IL2CPP wrappers from PvZ Fusion 4.0.
- Updated package and runtime metadata for the 4.0 target.
- Kept the safe native mouse-placement path used by the 3.9 port.

## 3.9.0-ml.1

- Updated generated IL2CPP references and build metadata for PvZ Fusion 3.9.
- Adapted zombie total-health handling to the 64-bit health values introduced in 3.9.
- Verified a clean Release build and successful MelonLoader startup on PvZ Fusion 3.9.

## 3.8.1-ml.1

- Updated the build target and generated IL2CPP references to PvZ Fusion 3.8.1.
- Renamed the output assembly and public namespace from `CustomizeLib.BepInEx` to `CustomizeLib.MelonLoader`.
- Removed the obsolete duplicate BepInEx-named project file.
- Verified a clean Release build against PvZ Fusion 3.8.1 and MelonLoader 0.7.3.

## 3.8.0-ml.2

- Renamed the project, MelonLoader entry point, logs, and file metadata to `CustomizeLib.MelonLoader`.
- Kept the `CustomizeLib.BepInEx` DLL and namespace as a compatibility contract for existing consumer mods.
- Removed 1,881 decompiler IL diagnostics and 98 constrained-cast comments from the C# source.
- Fixed custom plant almanacs so mechanics and flavor text are both copied to native `PlantInfo` entries after every reload.
- Fixed custom almanac title spacing and refreshes of already loaded entries.
- Added safe validation for missing source prefabs and missing `Bullet` components during skin-projectile injection.
- Corrected the `ID.ToString()` and `CustomDamageMaker.Team` overrides.

## 3.8.0-ml.1

- First public port of CustomizeLib 3.8 to MelonLoader 0.7.3.
- Compatibility target set to PvZ Fusion 3.8, IL2CPP, and .NET 6.
- Preserved the `CustomizeLib.BepInEx` identity for consumer mods.
- Replaced the BepInEx lifecycle with MelonLoader.
- Adapted generated IL2CPP namespaces and collections.
- Reconstructed missing coroutines from the 3.8 DLL.
- Moved external skins to `Mods/Skin`.
- Removed external BepInEx and `MapValue.BepInEx` dependencies.
