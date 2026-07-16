# Changelog

[Version française](CHANGELOG_FR.md)

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
