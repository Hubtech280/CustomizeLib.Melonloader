# Contribuer

Ce port cible précisément PvZ Fusion 3.8 et MelonLoader 0.7.3.

Avant de proposer un changement :

1. compile le projet en Release avec les assemblies IL2CPP de cette version ;
2. ne commit aucune DLL du jeu, de MelonLoader ou de BepInEx ;
3. vérifie que l'assembly produit ne référence pas BepInEx ;
4. décris les tests effectués en jeu et joins les logs utiles ;
5. garde les corrections limitées au problème traité.

Les changements nécessitant une autre version du jeu doivent être isolés et documentés : les signatures IL2CPP peuvent changer entre deux versions.
