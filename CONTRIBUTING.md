# Contributing

[Version française](CONTRIBUTING_FR.md)

This port specifically targets PvZ Fusion 3.8 and MelonLoader 0.7.3.

Before submitting a change:

1. build the project in Release mode against the IL2CPP assemblies generated for this exact game version;
2. do not commit any DLL from the game, MelonLoader, or BepInEx;
3. verify that the resulting assembly has no BepInEx assembly reference;
4. describe the in-game tests you performed and attach relevant logs;
5. keep the change focused on the issue being addressed.

Changes for another game version must be isolated and clearly documented because IL2CPP signatures may change between releases.
