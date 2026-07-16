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
