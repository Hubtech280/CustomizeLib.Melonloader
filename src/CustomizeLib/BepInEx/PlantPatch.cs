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
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
