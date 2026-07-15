using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UIMgr))]
public static class UIMgrPatch_0
{
	[HarmonyPatch("EnterGame")]
	[HarmonyPrefix]
	public static void PreEnterGame(UIMgr __instance, ref int levelNumber, ref int id, ref LevelType levelType)
	{
		if (!((Object)(object)SaveInfo.Instance == null) && Lawnf.IsTravelLevel(levelType, levelNumber))
		{
			((Component)(object)SaveInfo.Instance).SetData("endlessID", id);
		}
	}
}
