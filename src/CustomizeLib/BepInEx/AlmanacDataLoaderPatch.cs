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
		foreach (KeyValuePair<ZombieType, (string, string, ZombieInfo)> entry in CustomCore.ZombiesAlmanac)
		{
			if (AlmanacDataLoader.zombieDatas.ContainsKey(entry.Key))
			{
				continue;
			}

			if (entry.Value.Item3 != null)
			{
				AlmanacDataLoader.zombieDatas.Add(entry.Key, entry.Value.Item3);
				continue;
			}

			ZombieInfo zombieInfo = new ZombieInfo
			{
				name = Regex.Replace(entry.Value.Item1 ?? string.Empty, "\\([^()]*\\)", string.Empty),
				info = entry.Value.Item2 ?? string.Empty,
				introduce = string.Empty,
				theZombieType = entry.Key
			};
			AlmanacDataLoader.zombieDatas.Add(entry.Key, zombieInfo);
		}
	}

	[HarmonyPatch("LoadPlantData")]
	[HarmonyPostfix]
	[HarmonyPriority(Priority.Last)]
	public static void PostLoadPlantData()
	{
		foreach (KeyValuePair<PlantType, PlantAlmanac> entry in CustomCore.PlantsAlmanac)
		{
			PlantType plantType = entry.Key;
			PlantAlmanac source = entry.Value;
			bool alreadyLoaded = AlmanacDataLoader.plantDatas.ContainsKey(plantType);
			PlantInfo target = alreadyLoaded ? AlmanacDataLoader.plantDatas[plantType] : null;
			target ??= new PlantInfo();

			string cleanName = Regex.Replace(
				source.name ?? string.Empty,
				"[\\(（][^()（）]*[\\)）]",
				string.Empty
			).TrimEnd();

			// The native title appends "(ID)" directly, so keep one separator.
			target.name = cleanName.Length > 0 ? cleanName + " " : string.Empty;
			target.info = source.info ?? string.Empty;
			target.introduce = source.introduce ?? string.Empty;
			target.seedType = (int)source.plantType;
			target.cost = source.cost ?? string.Empty;

			if (alreadyLoaded)
			{
				AlmanacDataLoader.plantDatas[plantType] = target;
			}
			else
			{
				AlmanacDataLoader.plantDatas.Add(plantType, target);
			}
		}
	}
}
