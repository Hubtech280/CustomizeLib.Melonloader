using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Il2CppAlmanacData;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(AlmanacDataLoader))]
public static class AlmanacDataLoaderPatch
{
	[HarmonyPatch("LoadZombieData")]
	[HarmonyPostfix]
	public static void PostLoadZombieData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = CustomCore.ZombiesAlmanac.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<ZombieType, ValueTuple<string, string, ZombieInfo>> current = enumerator.Current;
				if (!AlmanacDataLoader.zombieDatas.ContainsKey(current.Key))
				{
					if (current.Value.Item3 != null)
					{
						AlmanacDataLoader.zombieDatas.Add(current.Key, current.Value.Item3);
						continue;
					}
					ZombieInfo val = new ZombieInfo();
					string name = Regex.Replace(current.Value.Item1, "\\([^()]*\\)", "");
					val.name = name;
					val.info = current.Value.Item2;
					val.introduce = "";
					val.theZombieType = current.Key;
					AlmanacDataLoader.zombieDatas.Add(current.Key, val);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}

	[HarmonyPatch("LoadPlantData")]
	[HarmonyPostfix]
	public static void PostLoadPlantData()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = CustomCore.PlantsAlmanac.GetEnumerator();
		try
		{
			PlantType val = default(PlantType);
			PlantAlmanac plantAlmanac = default(PlantAlmanac);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val, out plantAlmanac);
				PlantType key = val;
				PlantAlmanac plantAlmanac2 = plantAlmanac;
				if (!AlmanacDataLoader.plantDatas.ContainsKey(key))
				{
					PlantInfo val2 = new PlantInfo();
					string name = Regex.Replace(plantAlmanac2.name, "\\([^()]*\\)", "");
					val2.name = name;
					val2.info = plantAlmanac2.info;
					val2.seedType = (int)plantAlmanac2.plantType;
					val2.cost = plantAlmanac2.cost;
					AlmanacDataLoader.plantDatas.Add(key, val2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
