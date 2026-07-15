# Changelog

[English version](CHANGELOG.md)

## 3.8.0-ml.1

- Premier port public de CustomizeLib 3.8 vers MelonLoader 0.7.3.
- Compatibilité ciblée avec PvZ Fusion 3.8, IL2CPP et .NET 6.
- Conservation de l'identité `CustomizeLib.BepInEx` pour les mods consommateurs.
- Remplacement du cycle de vie BepInEx par MelonLoader.
- Adaptation des namespaces et collections IL2CPP.
- Reconstruction des coroutines manquantes depuis la DLL 3.8.
- Déplacement des skins externes vers `Mods/Skin`.
- Suppression des dépendances externes à BepInEx et `MapValue.BepInEx`.
