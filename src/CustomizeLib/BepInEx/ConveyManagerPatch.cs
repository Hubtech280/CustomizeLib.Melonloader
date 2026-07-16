using HarmonyLib;
using Il2CppSystem.Collections.Generic;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(ConveyManager))]
public static class ConveyManagerPatch
{
	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	public static void PostAwake(ConveyManager __instance)
	{

		if (Utils.IsCustomLevel(out var levelData) && levelData.BoardTag.isConvey && levelData.ConveyBeltPlantTypes.Invoke().Count > 0)
		{
			__instance.plants = levelData.ConveyBeltPlantTypes.Invoke().ToIl2CppList<PlantType>();
		}
	}

	[HarmonyPatch("GetCardPool")]
	[HarmonyPostfix]
	public static void PostGetCardPool(ref List<PlantType> __result)
	{

		if (Utils.IsCustomLevel(out var levelData) && levelData.BoardTag.isConvey && levelData.ConveyBeltPlantTypes.Invoke().Count > 0)
		{
			__result = levelData.ConveyBeltPlantTypes.Invoke().ToIl2CppList<PlantType>();
		}
	}
}
