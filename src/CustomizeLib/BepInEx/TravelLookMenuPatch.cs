using System;
using System.Collections.Generic;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelLookMenu))]
public static class TravelLookMenuPatch
{
	[HarmonyPatch("GetAdvBuffs")]
	[HarmonyPostfix]
	public static void PostGetAdvBuffs(TravelLookMenu __instance, ref Il2CppSystem.Collections.Generic.List<AdvBuff> __result)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomAdvancedBuffs.Count <= 0)
		{
			return;
		}
		var enumerator = CustomCore.CustomAdvancedBuffs.GetEnumerator();
		try
		{
			int num = default(int);
			ValueTuple<PlantType, string, Func<bool>, int> val = default(ValueTuple<PlantType, string, Func<bool>, int>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out num, out val);
				int num2 = num;
				if (__instance.showAll)
				{
					__result.Add((AdvBuff)num2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("GetDebuffs")]
	[HarmonyPostfix]
	public static void PostGetDebuffs(TravelLookMenu __instance, ref Il2CppSystem.Collections.Generic.List<TravelDebuff> __result)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomDebuffs.Count <= 0)
		{
			return;
		}
		var enumerator = CustomCore.CustomDebuffs.GetEnumerator();
		try
		{
			int num = default(int);
			ValueTuple<string, ZombieType, Func<bool>> val = default(ValueTuple<string, ZombieType, Func<bool>>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out num, out val);
				int num2 = num;
				if (__instance.showAll)
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

	[HarmonyPatch("GetUltiBuffs")]
	[HarmonyPostfix]
	public static void PostGetUltimateBuffs(TravelLookMenu __instance, ref Il2CppSystem.ValueTuple<Il2CppSystem.Collections.Generic.List<UltiBuff>, Il2CppSystem.Collections.Generic.List<UltiBuff>> __result)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomUltimateBuffs.Count <= 0)
		{
			return;
		}
		var enumerator = CustomCore.CustomUltimateBuffs.GetEnumerator();
		try
		{
			int num = default(int);
			ValueTuple<PlantType, string, int> val = default(ValueTuple<PlantType, string, int>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out num, out val);
				int num2 = num;
				if (__instance.showAll)
				{
					__result.Item1.Add((UltiBuff)num2);
				}
				if (__instance.showAll)
				{
					__result.Item2.Add((UltiBuff)num2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
