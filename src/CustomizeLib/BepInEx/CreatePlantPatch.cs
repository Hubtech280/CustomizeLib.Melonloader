using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppCore;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(CreatePlant))]
public static class CreatePlantPatch
{
	[HarmonyPatch("SetPlant")]
	[HarmonyPostfix]
	public static void Postfix_SetPlant(CreatePlant __instance, ref int newColumn, ref int newRow, ref Plant __result)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)__result != null && ((Component)(object)__result).TryGetComponent(out Plant component) && CustomCore.CustomPlantTypes.Contains(component.thePlantType))
		{
			TypeMgr.GetPlantTag(component);
		}
	}

	[HarmonyPatch("Lim")]
	[HarmonyPostfix]
	public static void PostLim(CreatePlant __instance, ref PlantType theSeedType, ref bool __result)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (!CustomCore.CustomBanMix.ContainsKey(theSeedType) || CustomCore.CustomBanMix[theSeedType].Item1 == null)
		{
			return;
		}
		if (CustomCore.CustomBanMix[theSeedType].Item1.Invoke())
		{
			Action item = CustomCore.CustomBanMix[theSeedType].Item2;
			if (item != null)
			{
				item.Invoke();
			}
			return;
		}
		__result = true;
		InGameTextPatch.disable = true;
		Action item2 = CustomCore.CustomBanMix[theSeedType].Item3;
		if (item2 != null)
		{
			item2.Invoke();
		}
	}

	[HarmonyPatch("LimTravel")]
	[HarmonyPostfix]
	public static void Postfix_LimTravel(CreatePlant __instance, ref PlantType theSeedType, ref bool __result)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if ((Object)(object)TravelMgr.Instance != null && Board.Instance.boardTag.isTravel)
		{
			flag = true;
		}
		if (__instance.board.boardTag.enableAllTravelPlant || __instance.board.boardTag.enableTravelPlant || __instance.board.boardTag.isTravel)
		{
			flag = true;
		}
		if (CustomCore.CustomUltimatePlants.Contains(theSeedType) && !flag)
		{
			__result = true;
			InGameText.Instance.ShowText("该配方仅旅行生存系列或深渊可用", 3f, false);
		}
		if (CustomCore.CustomStrongUltimatePlants.ContainsKey(theSeedType))
		{
			if ((Object)(object)__instance.board == null)
			{
				__result = false;
			}
			else if (!__instance.board.boardTag.enableAllTravelPlant && !__instance.board.boardTag.enableTravelPlant && !__instance.board.boardTag.isSuperRandom && !__instance.board.boardTag.isUltimateSuperRandom)
			{
				__result = true;
				InGameText.Instance.ShowText("该配方仅旅行模式或深渊可用", 4f, false);
			}
			else if ((Object)(object)TravelMgr.Instance == null)
			{
				__result = false;
			}
			else if (TravelMgr.Instance.data.unlockedPlants.Contains((TravelUnlocks)CustomCore.CustomStrongUltimatePlants[theSeedType]) || __instance.board.boardTag.enableAllTravelPlant || __instance.board.boardTag.isSuperRandom || __instance.board.boardTag.isUltimateSuperRandom)
			{
				__result = false;
			}
			else
			{
				__result = true;
				InGameText.Instance.ShowText("该配方需要抽取", 4f, false);
			}
		}
	}

	[HarmonyPatch("MixBombCheck")]
	[HarmonyPrefix]
	public static bool Prefix_MixBombCheck(CreatePlant __instance, ref int theBoxColumn, ref int theBoxRow, ref bool __result)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		List<Plant> val = Enumerable.ToList<Plant>((System.Collections.Generic.IEnumerable<Plant>)Il2Cpp.Lawnf.Get1x1Plants(theBoxColumn, theBoxRow).ToArray());
		var enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Plant plant = enumerator.Current;
				if ((Object)(object)plant == null || !Enumerable.Any<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>>)CustomCore.CustomMixBombFusions, (Func<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>, bool>)((KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>> kvp) => kvp.Key.Item2 == plant.thePlantType)))
				{
					continue;
				}
				__result = true;
				return false;
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return true;
	}
}
