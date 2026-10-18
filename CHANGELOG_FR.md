# Changelog

[English version](CHANGELOG.md)

## 4.0.5.2-ml.5 — 2026-10-18

- Mise à jour des références et métadonnées pour PvZ Fusion 4.0.5.2.
- Retrait du patch MixBombCheck obsolète et des appels aux setters des collections TypeMgr désormais en lecture seule.
- Restauration des entrées manquantes de statistiques et de déblocage des plantes personnalisées après l'initialisation native. Les valeurs de déblocage existantes sont conservées.
- Ajout de diagnostics d'almanach limités à six entrées par session.
- Conservation du placement natif en désactivant l'ancien gestionnaire de clics personnalisés responsable de crashs CLR. Ce gestionnaire n'est pas disponible dans cette version.
- Compilation et audit hors jeu des cibles de patch avec les assemblies du jeu installé. Toutes les fonctionnalités des mods consommateurs n'ont pas été vérifiées.

## 4.0.0-ml.1

- Recompilation avec les wrappers IL2CPP générés depuis PvZ Fusion 4.0.
- Mise à jour des métadonnées du paquet et du mod pour la cible 4.0.
- Conservation du chemin natif sûr pour le placement à la souris utilisé par le port 3.9.

## 3.9.0-ml.1

- Mise à jour des références IL2CPP générées et des métadonnées pour PvZ Fusion 3.9.
- Adaptation du calcul des PV totaux aux valeurs de santé 64 bits introduites dans la 3.9.
- Validation d'une compilation Release propre et d'un chargement MelonLoader réussi sur PvZ Fusion 3.9.

## 3.8.1-ml.1

- Mise à jour de la cible de compilation et des références IL2CPP générées vers PvZ Fusion 3.8.1.
- Renommage de l'assembly généré et du namespace public de `CustomizeLib.BepInEx` vers `CustomizeLib.MelonLoader`.
- Suppression de l'ancien fichier projet portant le nom BepInEx.
- Validation d'une compilation Release propre avec PvZ Fusion 3.8.1 et MelonLoader 0.7.3.

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
