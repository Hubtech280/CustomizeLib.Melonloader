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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)GameAPP.theBoardType == 66)
		{
			__instance.ChangeString(T, CustomCore.CustomLevels[GameAPP.theBoardLevel].Name.Invoke());
		}
	}

	[HarmonyPatch("MoveCardToTarget")]
	[HarmonyPrefix]
	public static void PreMoveCardToTarget(ref CardUI card)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("RemoveCardFromBank")]
	[HarmonyPostfix]
	public static void PostReMoveCardFromBank(ref CardUI card)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
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
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
