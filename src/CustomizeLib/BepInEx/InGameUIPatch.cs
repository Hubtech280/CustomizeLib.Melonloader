using System;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppTMPro;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(InGameUI))]
public static class InGameUIPatch
{
	[HarmonyPatch("SetUniqueText")]
	[HarmonyPostfix]
	public static void PostSetUniqueText(InGameUI __instance, ref Il2CppSystem.Collections.Generic.List<TextMeshProUGUI> T)
	{


		if ((int)GameAPP.theBoardType == 66)
		{
			__instance.ChangeString(T, CustomCore.CustomLevels[GameAPP.theBoardLevel].Name.Invoke());
		}
	}

	[HarmonyPatch("MoveCardToTarget")]
	[HarmonyPrefix]
	public static void PreMoveCardToTarget(ref CardUI card)
	{


		var enumerator = CustomCore.checkBehaviours.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CheckCardState current = enumerator.Current;
				if (current != null)
				{
					current.movingCardUI = card;
					current.CheckState();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	[HarmonyPatch("RemoveCardFromBank")]
	[HarmonyPostfix]
	public static void PostReMoveCardFromBank(ref CardUI card)
	{


		var enumerator = CustomCore.checkBehaviours.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CheckCardState current = enumerator.Current;
				if (current != null)
				{
					current.movingCardUI = card;
					current.CheckState();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}
}
