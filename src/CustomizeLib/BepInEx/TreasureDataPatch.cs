using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TreasureData))]
public static class TreasureDataPatch
{
	[HarmonyPatch("GetCardLevel")]
	[HarmonyPrefix]
	public static bool GetCardLevel(TreasureData __instance, ref PlantType thePlantType, ref CardLevel __result)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected I4, but got Unknown
		if (CustomCore.TypeMgrExtra.LevelPlants.ContainsKey(thePlantType))
		{
			__result = (CardLevel)(int)CustomCore.TypeMgrExtra.LevelPlants[thePlantType];
			return false;
		}
		return true;
	}
}
