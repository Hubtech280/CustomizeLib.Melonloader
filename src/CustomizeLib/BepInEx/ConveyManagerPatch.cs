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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (Utils.IsCustomLevel(out var levelData) && levelData.BoardTag.isConvey && levelData.ConveyBeltPlantTypes.Invoke().Count > 0)
		{
			__instance.plants = levelData.ConveyBeltPlantTypes.Invoke().ToIl2CppList<PlantType>();
		}
	}

	[HarmonyPatch("GetCardPool")]
	[HarmonyPostfix]
	public static void PostGetCardPool(ref List<PlantType> __result)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (Utils.IsCustomLevel(out var levelData) && levelData.BoardTag.isConvey && levelData.ConveyBeltPlantTypes.Invoke().Count > 0)
		{
			__result = levelData.ConveyBeltPlantTypes.Invoke().ToIl2CppList<PlantType>();
		}
	}
}
