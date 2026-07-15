using System;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(ZombieDataManager))]
public static class ZombieDataPatch
{
	[HarmonyPatch("LoadData")]
	[HarmonyPostfix]
	public static void InitZombieData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = CustomCore.CustomZombies.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<ZombieType, ValueTuple<GameObject, Sprite, ZombieData>> current = enumerator.Current;
				ZombieDataManager.zombieDataDic[current.Key] = current.Value.Item3;
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
