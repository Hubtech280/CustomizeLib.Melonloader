using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(MixBomb), "AttributeEvent")]
public static class MixBombPatch
{
	[HarmonyPrefix]
	public static bool Prefix(MixBomb __instance)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		if ((Object)(object)__instance != null)
		{
			List<Plant> val = Enumerable.ToList<Plant>((System.Collections.Generic.IEnumerable<Plant>)Lawnf.Get1x1Plants(((Plant)__instance).thePlantColumn, ((Plant)__instance).thePlantRow).ToArray());
			if (val == null)
			{
				return true;
			}
			var enumerator = val.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Plant plant = enumerator.Current;
					if (!((Object)(object)plant != null) || !Enumerable.Any<ValueTuple<PlantType, PlantType, PlantType>>((System.Collections.Generic.IEnumerable<ValueTuple<PlantType, PlantType, PlantType>>)CustomCore.CustomMixBombFusions.Keys, (Func<ValueTuple<PlantType, PlantType, PlantType>, bool>)((ValueTuple<PlantType, PlantType, PlantType> k) => k.Item2 == plant.thePlantType)))
					{
						continue;
					}
					List<ValueTuple<PlantType, PlantType, PlantType>> val2 = Enumerable.ToList<ValueTuple<PlantType, PlantType, PlantType>>(Enumerable.Select<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>, ValueTuple<PlantType, PlantType, PlantType>>(Enumerable.Where<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>>)CustomCore.CustomMixBombFusions, (Func<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>, bool>)((KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>> kvp) => kvp.Key.Item2 == plant.thePlantType)), (Func<KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>, ValueTuple<PlantType, PlantType, PlantType>>)((KeyValuePair<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>> kvp) => kvp.Key)));
					List<Plant> val3 = Enumerable.ToList<Plant>((System.Collections.Generic.IEnumerable<Plant>)Lawnf.Get1x1Plants(((Plant)__instance).thePlantColumn - 1, ((Plant)__instance).thePlantRow).ToArray());
					List<Plant> val4 = Enumerable.ToList<Plant>((System.Collections.Generic.IEnumerable<Plant>)Lawnf.Get1x1Plants(((Plant)__instance).thePlantColumn + 1, ((Plant)__instance).thePlantRow).ToArray());
					var enumerator2 = val2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							ValueTuple<PlantType, PlantType, PlantType> fusion = enumerator2.Current;
							Plant val5 = Enumerable.FirstOrDefault<Plant>((System.Collections.Generic.IEnumerable<Plant>)val3, (Func<Plant, bool>)((Plant p) => p.thePlantType == fusion.Item1));
							Plant val6 = Enumerable.FirstOrDefault<Plant>((System.Collections.Generic.IEnumerable<Plant>)val4, (Func<Plant, bool>)((Plant p) => p.thePlantType == fusion.Item3));
							if ((Object)(object)val5 == null || (Object)(object)val6 == null)
							{
								CustomCore.CustomMixBombFusions[fusion].Item2[Random.Range(0, CustomCore.CustomMixBombFusions[fusion].Item2.Count)].Invoke(val5, plant, val6);
							}
							else if (Enumerable.Any<Plant>((System.Collections.Generic.IEnumerable<Plant>)val3, (Func<Plant, bool>)((Plant p) => p.thePlantType == fusion.Item1)) && Enumerable.Any<Plant>((System.Collections.Generic.IEnumerable<Plant>)val4, (Func<Plant, bool>)((Plant p) => p.thePlantType == fusion.Item3)))
							{
								CustomCore.CustomMixBombFusions[fusion].Item1[Random.Range(0, CustomCore.CustomMixBombFusions[fusion].Item1.Count)].Invoke(val5, plant, val6);
								flag = true;
							}
							else
							{
								CustomCore.CustomMixBombFusions[fusion].Item2[Random.Range(0, CustomCore.CustomMixBombFusions[fusion].Item2.Count)].Invoke(val5, plant, val6);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
			}
		}
		if ((Object)(object)__instance != null && flag)
		{
			((Plant)__instance).Die((DieReason)0);
		}
		if (flag)
		{
			return false;
		}
		return true;
	}
}
