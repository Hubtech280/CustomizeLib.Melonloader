using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelBuffOptionButton))]
public static class TravelBuffOptionButtonPatch
{
	[HarmonyPatch("SetBuff")]
	[HarmonyPrefix]
	public static void PreSetBuff(TravelBuffOptionButton __instance, Il2CppSystem.Object buff)
	{

		__instance.GeneralSet(buff);
	}

	[HarmonyPatch("SetPlant", new System.Type[] { })]
	[HarmonyPostfix]
	public static void PostSetPlant(TravelBuffOptionButton __instance)
	{

















		ValueTuple<BuffType, int> val = __instance.TryGetTypeAndID();
		BuffType item = val.Item1;
		int buffIndex = val.Item2;
		List<KeyValuePair<int, ValueTuple<PlantType, string, int>>> val2 = Enumerable.ToList<KeyValuePair<int, ValueTuple<PlantType, string, int>>>(Enumerable.Where<KeyValuePair<int, ValueTuple<PlantType, string, int>>>((System.Collections.Generic.IEnumerable<KeyValuePair<int, ValueTuple<PlantType, string, int>>>)CustomCore.CustomUltimateBuffs, (Func<KeyValuePair<int, ValueTuple<PlantType, string, int>>, bool>)((KeyValuePair<int, ValueTuple<PlantType, string, int>> kvp) => kvp.Key == buffIndex)));
		if ((int)item != 2 || val2.Count <= 0)
		{
			return;
		}
		var enumerator = val2.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, ValueTuple<PlantType, string, int>> current = enumerator.Current;
				if ((int)current.Value.Item1 == -1)
				{
					__instance.SetPlant((PlantType)254);
				}
				else
				{
					__instance.SetPlant(current.Value.Item1);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
