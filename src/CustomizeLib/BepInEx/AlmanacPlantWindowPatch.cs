using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(AlmanacPlantWindow))]
public static class AlmanacPlantWindowPatch
{
	[HarmonyPatch("SetPlant")]
	[HarmonyPostfix]
	public static void PostInitWindow(AlmanacPlantWindow __instance, ref PlantType thePlantType)
	{













		PlantType val = thePlantType;
		if (CustomCore.CustomPlantsSkin.ContainsKey(val))
		{
			__instance.skinButton.SetActive(CustomCore.CustomPlantsSkin.ContainsKey(val));
		}
		PlantType val2 = thePlantType;
		if (CustomCore.CustomPlantTypes.Contains(val2))
		{
			__instance.skinButton.SetActive(CustomCore.CustomPlantsSkin.ContainsKey(val2));
		}
		PlantType val3 = thePlantType;
		if (CustomCore.CustomPlantsSkinActive.ContainsKey(val3) && CustomCore.CustomPlantsSkinActive[val3])
		{
			return;
		}
		string text = global::MelonLoader.Utils.MelonEnvironment.ModsDirectory;
		if (text == null)
		{
			return;
		}
		string text2 = Path.Combine(text, "Skin");
		if (Directory.Exists(text2))
		{
			Regex regex = new Regex($"^skin_{(int)val3}(?!\\d).*$", (RegexOptions)1);
			List<string> val4 = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)Directory.GetFiles(text2), (Func<string, bool>)((string str) => regex.IsMatch(Path.GetFileNameWithoutExtension(str)))));
			__instance.skinButton.SetActive(val4.Count > 0);
		}
	}

	[HarmonyPatch("LeftSkin")]
	[HarmonyPrefix]
	public static void PreLeftSkin(AlmanacPlantWindow __instance, out bool __state)
	{


		__state = __instance.skinButton.active;
		PatchMgr.OnChangeSkin(__instance.currentPlantType, GameAPP.resourcesManager.plantSkinDic[__instance.currentPlantType]);
	}

	[HarmonyPatch("LeftSkin")]
	[HarmonyPostfix]
	public static void PostLeftSkin(AlmanacPlantWindow __instance, bool __state)
	{


		__instance.skinButton.SetActive(__state);
		PatchMgr.OnChangeSkin(__instance.currentPlantType, GameAPP.resourcesManager.plantSkinDic[__instance.currentPlantType]);
		PatchMgr.SaveSkin();
	}

	[HarmonyPatch("RightSkin")]
	[HarmonyPrefix]
	public static void PreRightSkin(AlmanacPlantWindow __instance, out bool __state)
	{


		__state = __instance.skinButton.active;
		PatchMgr.OnChangeSkin(__instance.currentPlantType, GameAPP.resourcesManager.plantSkinDic[__instance.currentPlantType]);
	}

	[HarmonyPatch("RightSkin")]
	[HarmonyPostfix]
	public static void PostRightSkin(AlmanacPlantWindow __instance, bool __state)
	{


		__instance.skinButton.SetActive(__state);
		PatchMgr.OnChangeSkin(__instance.currentPlantType, GameAPP.resourcesManager.plantSkinDic[__instance.currentPlantType]);
		PatchMgr.SaveSkin();
	}
}
