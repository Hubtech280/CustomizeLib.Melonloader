using System;
using System.Collections.Generic;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Lawnf))]
public class LawnfPatch
{
	[HarmonyPatch("GetUpgradedPlantCost")]
	[HarmonyPrefix]
	public static bool Prefix(ref PlantType thePlantType, ref int targetLevel, ref int __result)
	{
		if (CustomCore.CustomUltimatePlants.Contains(thePlantType))
		{
			__result = 1500 * targetLevel * (targetLevel + 1) / 2;
			return false;
		}
		return true;
	}

	[HarmonyPatch("IsUltiPlant")]
	[HarmonyPrefix]
	public static bool Prefix(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.CustomPlantTypes.Contains(thePlantType))
		{
			__result = CustomCore.CustomUltimatePlants.Contains(thePlantType);
			return false;
		}
		return true;
	}

	[HarmonyPatch("GetUltimatePlants")]
	[HarmonyPostfix]
	public static void Postfix(ref Il2CppSystem.Collections.Generic.List<PlantType> __result)
	{






		var enumerator = CustomCore.CustomUltimatePlants.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlantType current = enumerator.Current;
				if (!__result.Contains(current))
				{
					__result.Add(current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	[HarmonyPatch("GetName", new System.Type[] { typeof(PlantType) })]
	[HarmonyPrefix]
	public static bool PreGetName(PlantType thePlantType, ref string __result)
	{


		if (CustomCore.CustomPlantNames.ContainsKey(thePlantType))
		{
			__result = CustomCore.CustomPlantNames[thePlantType];
			return false;
		}
		return true;
	}

	[HarmonyPatch("GetName", new System.Type[] { typeof(ZombieType) })]
	[HarmonyPrefix]
	public static bool PreGetName_Zombie(ZombieType theZombieType, ref string __result)
	{


		if (CustomCore.CustomZombieNames.ContainsKey(theZombieType))
		{
			__result = CustomCore.CustomZombieNames[theZombieType];
			return false;
		}
		return true;
	}

	[HarmonyPatch("TravelAdvanced")]
	[HarmonyPostfix]
	public static void PostTravelAdvanced_0(ref AdvBuff buff, ref bool __result)
	{




		ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff((BuffType)1, (int)buff);
		if (!val.Item1)
		{
			return;
		}
		int item = val.Item2;
		if (!((Object)(object)TravelMgr.Instance == null))
		{
			int[] data = ((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel");
			if (data != null && item < data.Length)
			{
				__result = data[item] > 0;
			}
		}
	}

	[HarmonyPatch("TravelUltimate")]
	[HarmonyPostfix]
	public static void PostTravelUltimate_0(ref UltiBuff buff, ref bool __result)
	{




		ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff((BuffType)2, (int)buff);
		if (!val.Item1)
		{
			return;
		}
		int item = val.Item2;
		if (!((Object)(object)TravelMgr.Instance == null))
		{
			int[] data = ((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel");
			if (data != null && item < data.Length)
			{
				__result = data[item] > 0;
			}
		}
	}

	[HarmonyPatch("TravelUltimateLevel")]
	[HarmonyPostfix]
	public static void PostTravelUltimateLevel(ref UltiBuff buff, ref int __result)
	{




		ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff((BuffType)2, (int)buff);
		if (!val.Item1)
		{
			return;
		}
		int item = val.Item2;
		if (!((Object)(object)TravelMgr.Instance == null))
		{
			int[] data = ((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel");
			if (data != null && (int)buff < data.Length)
			{
				__result = data[item];
			}
		}
	}

	[HarmonyPatch("TravelDebuff", new System.Type[] { typeof(TravelDebuff) })]
	[HarmonyPostfix]
	public static void PostTravelDebuff_1(ref TravelDebuff buff, ref bool __result)
	{




		ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff((BuffType)3, (int)buff);
		if (!val.Item1)
		{
			return;
		}
		int item = val.Item2;
		if (!((Object)(object)TravelMgr.Instance == null))
		{
			int[] data = ((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel");
			if (data != null && item < data.Length)
			{
				__result = data[item] > 0;
			}
		}
	}
}
