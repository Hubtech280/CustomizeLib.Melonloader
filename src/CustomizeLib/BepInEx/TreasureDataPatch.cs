using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TreasureData))]
public static class TreasureDataPatch
{
	[HarmonyPatch("GetCardLevel")]
	[HarmonyPrefix]
	public static bool GetCardLevel(TreasureData __instance, ref PlantType thePlantType, ref CardLevel __result)
	{


		if (CustomCore.TypeMgrExtra.LevelPlants.ContainsKey(thePlantType))
		{
			__result = (CardLevel)(int)CustomCore.TypeMgrExtra.LevelPlants[thePlantType];
			return false;
		}
		return true;
	}
}
