using HarmonyLib;

namespace CustomizeLib.BepInEx.Internal;

[HarmonyPatch(typeof(PauseMenu_Btn))]
public static class PauseMenu_BtnPatch
{
	[HarmonyPatch("OnMouseUp")]
	[HarmonyPostfix]
	public static void PostOnMouseUp()
	{
		if (!HookCall.load)
		{
			HookCall.SetBuffArr();
			HookCall.load = true;
		}
	}
}
