using Il2CppCore;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(InGameText), "ShowText")]
public static class InGameTextPatch
{
	public static bool disable;

	[HarmonyPrefix]
	public static bool Prefix(string text, float time)
	{
		if (text == "通关挑战模式解锁配方" && time == 7f && disable)
		{
			disable = false;
			return false;
		}
		return true;
	}
}
