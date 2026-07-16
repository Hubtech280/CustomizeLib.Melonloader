using System;
using System.Collections.Generic;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(InitZombieList))]
public static class InitZombieListAllowZombiePatch
{
	[HarmonyPatch("PickZombie")]
	[HarmonyPrefix]
	public static void PrePickZombie()
	{





		if (!Utils.IsCustomLevel(out var levelData))
		{
			return;
		}
		var enumerator = levelData.ZombieList.Invoke().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ZombieType current = enumerator.Current;
				InitZombieList.zombieToSpawns.Add(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
