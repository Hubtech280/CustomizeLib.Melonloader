using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Plant))]
public static class PlantPatch
{
	[HarmonyPostfix]
	[HarmonyPatch("UseItem")]
	public static void PostUseItem(Plant __instance, ref BucketType type, ref Bucket bucket)
	{




		if (CustomCore.CustomUseItems.ContainsKey(new ValueTuple<PlantType, BucketType>(__instance.thePlantType, type)))
		{
			CustomCore.CustomUseItems[new ValueTuple<PlantType, BucketType>(__instance.thePlantType, type)].Invoke(__instance);
			Object.Destroy(((Component)(object)bucket).gameObject);
		}
	}

	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart(Plant __instance)
	{








		if (!((Object)(object)__instance != null) || !CustomCore.CustomOnMixEvent.ContainsKey(new ValueTuple<PlantType, PlantType>(__instance.firstParent, __instance.secondParent)))
		{
			return;
		}
		var enumerator = CustomCore.CustomOnMixEvent[new ValueTuple<PlantType, PlantType>(__instance.firstParent, __instance.secondParent)].GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Action<Plant> current = enumerator.Current;
				current.Invoke(__instance);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
