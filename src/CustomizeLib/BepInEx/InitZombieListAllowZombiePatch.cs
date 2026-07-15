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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
