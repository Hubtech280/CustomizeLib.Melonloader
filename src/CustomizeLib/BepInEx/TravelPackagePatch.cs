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
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
