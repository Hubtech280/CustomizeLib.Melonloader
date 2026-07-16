using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Fertilize))]
public static class FertilizePatch
{
	[HarmonyPatch("Upgrade")]
	[HarmonyPostfix]
	public static void PostUpgrade(Fertilize __instance)
	{


		if ((Object)(object)__instance == null || (Object)(object)__instance.theTargetPlant == null)
		{
			return;
		}
		int thePlantColumn = __instance.theTargetPlant.thePlantColumn;
		int thePlantRow = __instance.theTargetPlant.thePlantRow;
		List<Plant> val = Enumerable.ToList<Plant>((System.Collections.Generic.IEnumerable<Plant>)Lawnf.Get1x1Plants(thePlantColumn, thePlantRow).ToArray());
		if (val == null)
		{
			return;
		}
		for (int i = 0; i < val.Count; i++)
		{
			Plant val2 = val[i];
			if (!((Object)(object)val2 == null) && val2.thePlantColumn == thePlantColumn && val2.thePlantRow == thePlantRow)
			{
				if ((Object)(object)Board.Instance == null)
				{
					return;
				}
				if (CustomCore.CustomUseFertilize.ContainsKey(val2.thePlantType))
				{
					CustomCore.CustomUseFertilize[val2.thePlantType].Invoke(val2);
				}
			}
		}
		Object.Destroy(((Component)(object)__instance).gameObject);
	}
}
