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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("RightMoveCamera")]
	[HarmonyPostfix]
	public static void PostRightMoveCamera()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
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
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
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
			((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
