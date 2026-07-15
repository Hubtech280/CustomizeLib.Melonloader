using System;
using System.Collections.Generic;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelMgr))]
public static class TravelMgrPatch
{
	[HarmonyPatch("OnBoardStart")]
	[HarmonyPostfix]
	public static void PostOnBoardStart(TravelMgr __instance)
	{
		if (((Component)(object)__instance).GetData("CustomBuffsLevel") == null)
		{
			((Component)(object)__instance).SetData("CustomBuffsLevel", new int[CustomCore.CustomBuffsLevel.Count]);
		}
		if (((Component)(object)__instance).GetData("LoadByEndless") == null)
		{
			((Component)(object)__instance).SetData("LoadByEndless", false);
		}
		if (!((Component)(object)__instance).GetData<bool>("LoadByEndless"))
		{
			((Component)(object)__instance).SetData("CustomBuffsLevel", new int[CustomCore.CustomBuffsLevel.Count]);
		}
		((Component)(object)TravelMgr.Instance).SetData("LoadByEndless", false);
	}

	[HarmonyPatch("GetAdvancedBuffPool")]
	[HarmonyPostfix]
	public static void PostGetAdvancedBuffPool(ref Il2CppSystem.Collections.Generic.List<AdvBuff> __result)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Invalid comparison between Unknown and I4
		var enumerator = CustomCore.CustomAdvancedBuffs.GetEnumerator();
		try
		{
			int num = default(int);
			ValueTuple<PlantType, string, Func<bool>, int> val = default(ValueTuple<PlantType, string, Func<bool>, int>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out num, out val);
				int num2 = num;
				ValueTuple<PlantType, string, Func<bool>, int> val2 = val;
				if (val2.Item3.Invoke() && !TravelMgr.Instance.data.advBuffs.Contains((AdvBuff)num2))
				{
					__result.Add((AdvBuff)num2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator2 = CustomCore.CustomPlantInfo.GetEnumerator();
		try
		{
			PlantType val3 = default(PlantType);
			List<ValueTuple<BuffType, int>> val4 = default(List<ValueTuple<BuffType, int>>);
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.Deconstruct(out val3, out val4);
				PlantType val5 = val3;
				List<ValueTuple<BuffType, int>> val6 = val4;
				if (Lawnf.GetPlantCount(val5, Board.Instance) <= 0 || !__result.Contains((AdvBuff)val5))
				{
					continue;
				}
				var enumerator3 = val6.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						ValueTuple<BuffType, int> current = enumerator3.Current;
						BuffType item = current.Item1;
						int item2 = current.Item2;
						if ((int)item == 1 && __result.Contains((AdvBuff)item2))
						{
							for (int i = 0; i < __result.Count / 8; i++)
							{
								__result.Add((AdvBuff)item2);
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("GetDebuffPool")]
	[HarmonyPostfix]
	public static void GetDebuffPool(ref Il2CppSystem.Collections.Generic.List<TravelDebuff> __result)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = CustomCore.CustomDebuffs.GetEnumerator();
		try
		{
			int num = default(int);
			ValueTuple<string, ZombieType, Func<bool>> val = default(ValueTuple<string, ZombieType, Func<bool>>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out num, out val);
				int num2 = num;
				ValueTuple<string, ZombieType, Func<bool>> val2 = val;
				if (val2.Item3.Invoke() && !TravelMgr.Instance.data.travelDebuffs.Contains((TravelDebuff)num2))
				{
					__result.Add((TravelDebuff)num2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("GetText")]
	[HarmonyPostfix]
	public static void PostGetText(Il2CppSystem.Object buff, ref string __result)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<BuffType, int> typeAndID = TravelExtensions.GetTypeAndID(buff);
		BuffType item = typeAndID.Item1;
		int item2 = typeAndID.Item2;
		if (CustomCore.CustomBuffText.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			__result = CustomCore.CustomBuffText[new ValueTuple<BuffType, int>(item, item2)];
		}
	}
}
