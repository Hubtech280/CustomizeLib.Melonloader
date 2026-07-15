using System;
using System.Collections.Generic;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelPackage))]
public static class TravelPackagePatch
{
	[HarmonyPatch("Init")]
	[HarmonyPostfix]
	public static void PostInit(TravelPackage __instance)
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
					__instance.Debuffs.Add((TravelDebuff)num2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
