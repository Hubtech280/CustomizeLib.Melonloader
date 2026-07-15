// MelonLoader's Il2CppInterop generator moves game types from the global
// namespace into Il2Cpp. A global import keeps CustomizeLib's public source API
// readable while binding every game type to the generated 3.8 wrappers.
global using Il2Cpp;
global using PlantData = Il2Cpp.PlantDataManager.PlantData;
global using ZombieData = Il2Cpp.ZombieDataManager.ZombieData;
global using BoardTag = Il2Cpp.Board.BoardTag;
global using DieReason = Il2Cpp.Plant.DieReason;
global using CardInfo = Il2Cpp.AlmanacBuffMenu.CardInfo;
global using PlantTag = Il2Cpp.Plant.PlantTag;
global using Object = UnityEngine.Object;
global using Random = UnityEngine.Random;
