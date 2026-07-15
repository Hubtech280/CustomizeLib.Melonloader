using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UIButton))]
public static class HideCustomPlantCards
{
	[HarmonyPatch("OnMouseUpAsButton")]
	[HarmonyPostfix]
	public static void PostfixStart(UIButton __instance)
	{
		if (SelectCustomPlants.Instance != null && SelectCustomPlants.CustomPage != null && SelectCustomPlants.CustomPage.activeSelf)
		{
			SelectCustomPlants.CustomPage.SetActive(value: false);
		}
	}
}
