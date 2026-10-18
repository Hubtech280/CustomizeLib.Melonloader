using System.Collections.Generic;
using System.Text.RegularExpressions;
using Il2CppAlmanacData;
using HarmonyLib;

namespace CustomizeLib.MelonLoader;

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

[HarmonyPatch(typeof(AlmanacPlantMenu), "SetCard", new System.Type[] { typeof(UnityEngine.Transform), typeof(PlantType) })]
public static class AlmanacCustomCardDiagnosticPatch
{
	private static int logged;

	[HarmonyPrefix]
	[HarmonyPriority(Priority.Last)]
	public static void BeforeSetCard(PlantType thePlantType)
	{
		if (!CustomCore.CustomPlants.ContainsKey(thePlantType))
			return;
		CustomPlantUnlockPatch.EnsureCustomPlantEntries();
		if (logged >= 6)
			return;
		logged++;
		var data = AlmanacDataLoader.plantDatas;
		var unlocks = PlantDataManager.unlocked;
		var manager = GameAPP.resourcesManager;
		CustomCore.CLogger?.LogWarning(
			$"[CustomizeLib] Almanac card diagnostic ID={(int)thePlantType}" +
			$" | Info={data != null && data.ContainsKey(thePlantType)}" +
			$" | PlantData={PlantDataManager.PlantData_Default != null && PlantDataManager.PlantData_Default.ContainsKey(thePlantType)}" +
			$" | Unlock={unlocks != null && unlocks.ContainsKey(thePlantType)}" +
			$" | Prefab={manager != null && manager.plantPrefabs != null && manager.plantPrefabs.ContainsKey(thePlantType)}" +
			$" | Preview={manager != null && manager.plantPreviews != null && manager.plantPreviews.ContainsKey(thePlantType)}");
	}
}
