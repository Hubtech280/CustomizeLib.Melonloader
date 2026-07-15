using System;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelStore))]
public static class TravelStorePatch
{
	[HarmonyPatch("SetCost")]
	[HarmonyPostfix]
	public static void PostRefreshBuff(ref TravelStoreWindow window)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<BuffType, int> val = window.TryGetTypeAndID();
		BuffType item = val.Item1;
		int item2 = val.Item2;
		if (CustomCore.CustomBuffCost.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			window.cost = CustomCore.CustomBuffCost[new ValueTuple<BuffType, int>(item, item2)];
			if ((Lawnf.TravelCurse() || TravelMgr.Instance.data.Invest) && window.cost > 15000)
			{
				window.UpdateButtonText("过于昂贵", Color.red);
				window.canBuy = false;
				return;
			}
			window.UpdateButtonText($"{window.cost}分", Color.yellow);
			window.canBuy = true;
		}
	}
}
