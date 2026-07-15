using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(SeedLibrary))]
public static class SeedLibraryPatch
{
	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	public static void PostAwake(SeedLibrary __instance)
	{
		SelectCustomPlants.InitButton();
		PatchMgr.ShowCustomCards((MonoBehaviour)(object)__instance);
	}
}
