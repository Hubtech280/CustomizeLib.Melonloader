using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(SaveMgr))]
public static class SaveMgrPatch
{
	[HarmonyPatch("SaveBoard")]
	[HarmonyPostfix]
	public static void PostSaveBoard(SaveMgr __instance, ref int level, ref int id)
	{
		PatchMgr.SaveEndlessData(level, id);
	}

	[HarmonyPatch("LoadBoard")]
	[HarmonyPostfix]
	public static void PostLoadBoard(SaveMgr __instance, ref int level, ref int id)
	{
		if (!((Object)(object)TravelMgr.Instance == null) && !((Object)(object)SaveInfo.Instance == null))
		{
			object data = ((Component)(object)SaveInfo.Instance).GetData("endlessID");
			if (data != null)
			{
				int idG = (int)data;
				PatchMgr.LoadEndlessData(level, id, idG);
			}
		}
	}
}
