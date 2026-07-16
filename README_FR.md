# CustomizeLib.MelonLoader 3.8

[English version](README.md)

Port non officiel de CustomizeLib vers MelonLoader pour **Plants vs. Zombies Fusion 3.8**, **MelonLoader 0.7.3**, **IL2CPP** et **.NET 6**.

> Original CustomizeLib by **Infinite75**. MelonLoader port maintained by **Hubtech280**.

## État du port

- MelonLoader détecte et charge la bibliothèque sous le nom `CustomizeLib.MelonLoader v3.8.0-ml.2`.
- Le projet compile contre les assemblies exactes de PvZ Fusion 3.8 et MelonLoader 0.7.3.
- Un mod consommateur basé sur `CorePlugin` compile contre cette version.
- Une validation statique confirme l'absence de dépendance externe à BepInEx.
- Les tests complets de toutes les fonctionnalités en jeu restent en cours.

Le projet, l'entrée MelonLoader, les logs et les métadonnées utilisent maintenant le nom `CustomizeLib.MelonLoader`. La DLL générée et le namespace public restent volontairement nommés `CustomizeLib.BepInEx` afin de ne pas casser les mods existants. Ce nom de compatibilité ne signifie **pas** que BepInEx est chargé ou nécessaire.

## Installation

1. Installe MelonLoader 0.7.3 sur PvZ Fusion 3.8.
2. Lance une première fois le jeu pour générer `MelonLoader/Il2CppAssemblies`.
3. Retire toute ancienne copie BepInEx ou MelonLoader de CustomizeLib.
4. Copie `CustomizeLib.BepInEx.dll` dans le dossier `Mods` du jeu. L'ancien nom de fichier est volontaire pour la compatibilité des mods.
5. Place les skins externes dans `Mods/Skin`.

Ne charge pas simultanément les versions BepInEx et MelonLoader de CustomizeLib.

## Utilisation depuis un mod

Un ancien mod compilé pour BepInEx n'est pas forcément compatible tel quel. S'il référence directement les assemblies BepInEx, recompile-le pour MelonLoader.

Exemple minimal basé sur `CorePlugin` :

```csharp
using CustomizeLib.BepInEx;
using MelonLoader;

[assembly: MelonInfo(typeof(MonMod), "Mon mod", "1.0.0", "Auteur")]
[assembly: HarmonyDontPatchAll]

public sealed class MonMod : CorePlugin
{
    public override void OnStart()
    {
        // Enregistre ici les plantes, zombies, cartes, etc.
    }
}
```

Le projet du mod doit référencer :

- `CustomizeLib.BepInEx.dll` ;
- `MelonLoader/net6` ;
- les assemblies de `MelonLoader/Il2CppAssemblies` ;
- `Il2Cpp` pour les types générés du jeu, si nécessaire.

Conserve `HarmonyDontPatchAll` : `CorePlugin` initialise lui-même les patches du mod.

## Compilation

Les assemblies du jeu et de MelonLoader ne sont pas distribuées dans ce dépôt.

Avec une installation complète du jeu :

```powershell
dotnet build src/CustomizeLib.MelonLoader.csproj -c Release `
  -p:PVZF_GAME_DIR="C:\Chemin\Vers\PlantsVsZombiesRH"
```

Ou en indiquant directement le dossier de références :

```powershell
dotnet build src/CustomizeLib.MelonLoader.csproj -c Release `
  -p:ReferenceRoot="C:\Chemin\Vers\PlantsVsZombiesRH\MelonLoader"
```

La DLL est générée dans `build/CustomizeLib.BepInEx.dll`.

## Changements propres au port

- cycle de vie et journalisation reliés à MelonLoader ;
- patches Harmony gérés par l'instance Harmony de MelonLoader ;
- types du jeu adaptés aux namespaces générés par Il2CppInterop ;
- coroutines manquantes reconstruites depuis la DLL 3.8 ;
- skins déplacés de `BepInEx/plugins/Skin` vers `Mods/Skin` ;
- ancien patcher `MapValue.BepInEx` remplacé par une table en mémoire intégrée ;
- petite couche de compatibilité source pour `BasePlugin`, la journalisation et les coroutines BepInEx utilisées par CustomizeLib.
- actualisation complète des almanachs de plantes personnalisées : mécaniques, flavor text, coût et espacement du titre ;
- les projectiles de skin invalides échouent maintenant proprement sans interrompre l'injection des ressources ;
- suppression des commentaires de diagnostic IL ajoutés par le décompilateur.

Cette couche n'est pas une implémentation générale de BepInEx.

## Rapporter un problème

Ouvre une issue avec :

- la version exacte du jeu et de MelonLoader ;
- le journal MelonLoader complet ;
- le mod consommateur concerné ;
- les étapes permettant de reproduire le problème.

## Attribution et licence

CustomizeLib a été créée par **Infinite75**. Le code de base fourni pour ce port ne contenait pas de fichier de licence ; aucune licence supplémentaire n'est donc ajoutée ici. Vérifie les conditions de l'auteur original avant toute redistribution ou réutilisation au-delà de ce port.
