using System;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(PatchMgr))]
public static class PatchMgrPatch
{
	[HarmonyPatch("ShowCards")]
	[HarmonyFinalizer]
	public static System.Exception ShowFinalizer()
	{
		return null;
	}
}
