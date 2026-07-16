using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(InitBoard))]
public static class InitBoardPatch
{
	[HarmonyPatch("PreSelectCard")]
	[HarmonyPostfix]
	public static void PostPreSelectCard(InitBoard __instance)
	{







		if ((int)GameAPP.theBoardType != 66)
		{
			return;
		}
		var enumerator = CustomCore.CustomLevels[GameAPP.theBoardLevel].PreSelectCards.Invoke().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				PlantType current = enumerator.Current;
				__instance.PreSelect(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	[HarmonyPatch("RightMoveCamera")]
	[HarmonyPostfix]
	public static void PostRightMoveCamera()
	{















		if ((int)GameAPP.theBoardType != 66)
		{
			return;
		}
		CustomLevelData customLevelData = CustomCore.CustomLevels[GameAPP.theBoardLevel];
		TravelMgr orAddComponent = ((Component)(object)GameAPP.Instance).GetOrAddComponent<TravelMgr>();
		TravelData val = ((orAddComponent != null) ? orAddComponent.data : null);
		if (val == null)
		{
			return;
		}
		var enumerator = customLevelData.AdvBuffs.Invoke().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				if (current >= 0)
				{
					val.advBuffs.Add((AdvBuff)current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		var enumerator2 = customLevelData.UltiBuffs.Invoke().GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				ValueTuple<int, int> current2 = enumerator2.Current;
				if (current2.Item1 >= 0 && current2.Item2 >= 0)
				{
					val.ultiBuffs.Add((UltiBuff)current2.Item1);
					if (current2.Item2 > 1)
					{
						val.ultiBuffs_lv2.Add((UltiBuff)current2.Item1);
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
		var enumerator3 = customLevelData.Debuffs.Invoke().GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				int current3 = enumerator3.Current;
				if (current3 >= 0)
				{
					val.travelDebuffs.Add((TravelDebuff)current3);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}
}
