# CustomizeLib.MelonLoader 4.0.5.2-ml.5

Compatibility update for **PvZ Fusion 4.0.5.2**, using **MelonLoader 0.7.3** (IL2CPP / .NET 6).

## English

- Updates the game references and library metadata for 4.0.5.2.
- Removes an obsolete placement hook and adapts registration to getter-only TypeMgr collections.
- Restores missing custom plant unlock and stat records after native initialization, preserving existing unlock values.
- Keeps native mouse placement active to avoid the legacy custom-click dispatcher's fatal CLR error.

**Known limitation:** the legacy custom-click dispatcher is bypassed. Mods relying on it need an alternative input handler. Older mods may also need rebuilding or separate compatibility updates.

Installation: close the game, remove older CustomizeLib copies, then extract `CustomizeLib.MelonLoader.dll` into `Mods`. Keep external skins in `Mods/Skin`. Do not load the BepInEx and MelonLoader editions together. The game, MelonLoader and generated game assemblies are not included.

Validation: clean compilation and offline patch-target checks against 4.0.5.2; the packaged DLL matches the locally installed library used with PvZ Fusion+. This does not establish full compatibility with every consumer mod.

## Français

- Mise à jour des références et des métadonnées pour la 4.0.5.2.
- Retrait d'un ancien patch de placement et adaptation aux collections TypeMgr accessibles en lecture seule.
- Restauration des données de statistiques et de déblocage manquantes pour les plantes personnalisées, sans modifier les valeurs de déblocage existantes.
- Conservation du placement natif pour éviter le crash CLR de l'ancien gestionnaire de clics personnalisés.

**Limite connue :** cet ancien gestionnaire de clics est désactivé. Les mods qui l'utilisent doivent prévoir un autre système d'entrée. Les anciens mods peuvent aussi nécessiter une recompilation ou leurs propres correctifs.

Installation : ferme le jeu, retire les anciennes copies de CustomizeLib, puis place `CustomizeLib.MelonLoader.dll` dans `Mods`. Les skins externes restent dans `Mods/Skin`. Ne charge pas les éditions BepInEx et MelonLoader ensemble. Le jeu, MelonLoader et les assemblies générées ne sont pas inclus.

Vérifications : compilation et contrôle hors jeu des cibles de patch en 4.0.5.2 ; la DLL du paquet est identique à celle installée localement et utilisée avec PvZ Fusion+. Cela ne garantit pas toutes les fonctionnalités de tous les mods consommateurs.

Original CustomizeLib: **Infinite75**. MelonLoader port: **Hubtech280**. Attribution and redistribution terms are unchanged; see the README.
