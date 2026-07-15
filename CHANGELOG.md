# Changelog

[Version française](CHANGELOG_FR.md)

## 3.8.0-ml.1

- First public port of CustomizeLib 3.8 to MelonLoader 0.7.3.
- Compatibility target set to PvZ Fusion 3.8, IL2CPP, and .NET 6.
- Preserved the `CustomizeLib.BepInEx` identity for consumer mods.
- Replaced the BepInEx lifecycle with MelonLoader.
- Adapted generated IL2CPP namespaces and collections.
- Reconstructed missing coroutines from the 3.8 DLL.
- Moved external skins to `Mods/Skin`.
- Removed external BepInEx and `MapValue.BepInEx` dependencies.
