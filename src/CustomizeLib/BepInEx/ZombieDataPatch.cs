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
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
