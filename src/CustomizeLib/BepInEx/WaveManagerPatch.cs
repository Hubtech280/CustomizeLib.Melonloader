using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(WaveManager))]
public static class WaveManagerPatch
{
	[HarmonyPatch("GetMaxWave")]
	[HarmonyPostfix]
	public static void PostGetMaxWave(ref int __result)
	{
		if (Utils.IsCustomLevel(out var levelData))
		{
			__result = levelData.WaveCount.Invoke();
		}
	}
}
