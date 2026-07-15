using System;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

public class CoreData
{
	public static Lazy<CustomCore>? Instance = new Lazy<CustomCore>((Func<CustomCore>)(() => new CustomCore()));

	public static Lazy<ManualLogSource>? Logger = new Lazy<ManualLogSource>((Func<ManualLogSource>)(() => ((BasePlugin)Instance.Value).Log));

	public static Lazy<HarmonyLib.Harmony>? Harmony = new Lazy<HarmonyLib.Harmony>((Func<HarmonyLib.Harmony>)(() => new HarmonyLib.Harmony("salmon.inf75.pvzcustomization")));
}
