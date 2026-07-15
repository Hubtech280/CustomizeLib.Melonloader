using System.Text.RegularExpressions;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Bullet_pea_threeCherry))]
public static class Bullet_pea_threeCherryPatch
{
	[HarmonyPatch("HitZombie")]
	[HarmonyPrefix]
	public static void PreHitZombie(Bullet_pea_threeCherry __instance)
	{
		if (Regex.IsMatch(((Component)(object)__instance).gameObject.name, "Bullet_(\\d+)"))
		{
			__instance.bombPrefab = Resources.Load<GameObject>("items/timebomb/TimeBomb");
		}
	}
}
