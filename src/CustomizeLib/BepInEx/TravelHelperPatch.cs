using System;
using System.Collections.Generic;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelHelper))]
public static class TravelHelperPatch
{
	[HarmonyPatch("GetAllUltimatePlantTypes")]
	[HarmonyPostfix]
	public static void PostGetAllUltimatePlantTypes(ref Il2CppSystem.Collections.Generic.List<PlantType> __result, ref bool isStrongUltimate)
	{













		if (isStrongUltimate)
		{
			var enumerator = CustomCore.CustomStrongUltimatePlants.GetEnumerator();
			try
			{
				PlantType val = default(PlantType);
				int num = default(int);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out val, out num);
					PlantType item = val;
					__result.Add(item);
				}
				return;
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		var enumerator2 = CustomCore.CustomUltimatePlants.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				PlantType current = enumerator2.Current;
				if (!CustomCore.CustomStrongUltimatePlants.ContainsKey(current))
				{
					__result.Add(current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
	}
}
