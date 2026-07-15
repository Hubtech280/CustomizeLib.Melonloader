using System;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(SaveInfo))]
public static class SaveInfoPatch
{
	[HarmonyPatch("SaveSurvivalData", new System.Type[]
	{
		typeof(SurvivalData),
		typeof(int),
		typeof(int)
	})]
	[HarmonyPostfix]
	public static void PostSaveSurvivalDataByButton(ref int level, ref int id)
	{
		PatchMgr.SaveEndlessData(level, id);
	}

	[HarmonyPatch("SaveSurvivalData", new System.Type[]
	{
		typeof(int),
		typeof(bool),
		typeof(int),
		typeof(string)
	})]
	[HarmonyPostfix]
	public static void PostSaveSurvivalDataByAuto(ref int level, ref int id)
	{
		PatchMgr.SaveEndlessData(level, id);
	}
}
