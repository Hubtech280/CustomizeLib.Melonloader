# Changelog

[English version](CHANGELOG.md)

## 3.8.0-ml.2

- Renommage du projet, du point d'entrée MelonLoader, des logs et des métadonnées en `CustomizeLib.MelonLoader`.
- Conservation de la DLL et du namespace `CustomizeLib.BepInEx` comme contrat de compatibilité pour les mods existants.
- Suppression de 1 881 diagnostics IL du décompilateur et de 98 commentaires de casts contraints dans le code C#.
- Correction des almanachs personnalisés : les mécaniques et le flavor text sont maintenant copiés dans les entrées natives `PlantInfo` après chaque rechargement.
- Correction de l'espacement des titres et de l'actualisation des entrées d'almanach déjà chargées.
- Validation sûre des prefabs sources et des composants `Bullet` pendant l'injection des projectiles de skin.
- Correction des overrides `ID.ToString()` et `CustomDamageMaker.Team`.

## 3.8.0-ml.1

- Premier port public de CustomizeLib 3.8 vers MelonLoader 0.7.3.
- Compatibilité ciblée avec PvZ Fusion 3.8, IL2CPP et .NET 6.
- Conservation de l'identité `CustomizeLib.BepInEx` pour les mods consommateurs.
- Remplacement du cycle de vie BepInEx par MelonLoader.
- Adaptation des namespaces et collections IL2CPP.
- Reconstruction des coroutines manquantes depuis la DLL 3.8.
- Déplacement des skins externes vers `Mods/Skin`.
- Suppression des dépendances externes à BepInEx et `MapValue.BepInEx`.
