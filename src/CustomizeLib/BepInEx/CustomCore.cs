using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Il2CppAlmanacData;
using BepInEx;
using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using Il2CppCore;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using CustomizeLib.BepInEx.ExtensionData.Unity;
using CustomizeLib.BepInEx.Internal;
using CustomizeLib.BepInEx.UnmanagedTools;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[BepInPlugin("salmon.inf75.pvzcustomization", "CustomizeLib.MelonLoader", "3.8.0-ml.2")]
public class CustomCore : BasePlugin
{
	public static class TypeMgrExtra
	{
		[field: CompilerGenerated]
		public static List<PlantType> BigNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<ZombieType> BigZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<PlantType> DoubleBoxPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<ZombieType> EliteZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<ZombieType> DriverZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<PlantType> FlyingPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<ZombieType> IsAirZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsCaltrop
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsCustomPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsFirePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsIcePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsMagnetPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsPlantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsPot
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsPotatoMine
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsPuff
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsPumpkin
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsSmallRangeLantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsSpecialPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsSpickRock
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsTallNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsTangkelp
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<PlantType> IsWaterPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<ZombieType> NotRandomBungiZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<ZombieType> NotRandomZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<ZombieType> UltimateZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<PlantType> UmbrellaPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static List<ZombieType> UselessHypnoZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<ZombieType> WaterZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<ZombieType>();

		[field: CompilerGenerated]
		public static List<PlantType> UncrashablePlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new List<PlantType>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, CardLevel> LevelPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, CardLevel>();
	}

	public static class TypeMgrExtraSkin
	{
		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> BigNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> BigZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> DoubleBoxPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> EliteZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> FlyingPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> IsAirZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsCaltrop
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsCustomPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsFirePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsIcePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsMagnetPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPlantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPot
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPotatoMine
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPuff
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPumpkin
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSmallRangeLantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSpecialPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSpickRock
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsTallNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsTangkelp
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsWaterPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> NotRandomBungiZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> NotRandomZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> UltimateZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> UmbrellaPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> UselessHypnoZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> WaterZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();
	}

	public static class TypeMgrExtraSkinBackup
	{
		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> BigNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> BigZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> DoubleBoxPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> EliteZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> FlyingPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> IsAirZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsCaltrop
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsCustomPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsFirePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsIcePlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsMagnetPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPlantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPot
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPotatoMine
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPuff
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsPumpkin
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSmallRangeLantern
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSpecialPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsSpickRock
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsTallNut
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsTangkelp
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> IsWaterPlant
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> NotRandomBungiZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> NotRandomZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> UltimateZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<PlantType, int> UmbrellaPlants
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<PlantType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> UselessHypnoZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();

		[field: CompilerGenerated]
		public static Dictionary<ZombieType, int> WaterZombie
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		} = new Dictionary<ZombieType, int>();
	}

	public static List<CheckCardState> checkBehaviours = new List<CheckCardState>();

	public static int CustomBuffStartID = 17500;

	public static int CustomBulletSkinStartID = 2750;

	public static int RegisteredSkinBulletCount = 0;

	public static int CustomCherryStartID = 2000;

	public static ManualLogSource CLogger => CoreData.Logger?.Value;

	public static Lazy<CustomCore> Instance => new Lazy<CustomCore>(CoreData.Instance?.Value);

	[field: CompilerGenerated]
	public static Dictionary<int, ValueTuple<PlantType, string, Func<bool>, int>> CustomAdvancedBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, ValueTuple<PlantType, string, Func<bool>, int>>();

	[field: CompilerGenerated]
	public static Dictionary<BulletType, GameObject> CustomBullets
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<BulletType, GameObject>();

	[field: CompilerGenerated]
	public static Dictionary<int, ValueTuple<string, ZombieType, Func<bool>>> CustomDebuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, ValueTuple<string, ZombieType, Func<bool>>>();

	[field: CompilerGenerated]
	public static List<ValueTuple<int, int, int>> CustomFusions
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<ValueTuple<int, int, int>>();

	[field: CompilerGenerated]
	public static List<CustomLevelData> CustomLevels
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<CustomLevelData>();

	[field: CompilerGenerated]
	public static Dictionary<ParticleType, GameObject> CustomParticles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ParticleType, GameObject>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, Action<Plant>> CustomPlantClicks
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, Action<Plant>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, CustomPlantData> CustomPlants
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, CustomPlantData>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, List<CustomPlantData>> CustomPlantsSkin
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, List<CustomPlantData>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, bool> CustomPlantsSkinActive
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, bool>();

	[field: CompilerGenerated]
	public static List<PlantType> CustomPlantTypes
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<PlantType>();

	[field: CompilerGenerated]
	public static Dictionary<int, Sprite> CustomSprites
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, Sprite>();

	[field: CompilerGenerated]
	public static Dictionary<int, ValueTuple<PlantType, string, int>> CustomUltimateBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, ValueTuple<PlantType, string, int>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, BucketType>, Action<Plant>> CustomUseItems
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, BucketType>, Action<Plant>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, Action<Plant>> CustomUseFertilize
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, Action<Plant>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, ValueTuple<List<Func<Transform?>>, int>> CustomCards
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, ValueTuple<List<Func<Transform>>, int>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, ValueTuple<List<Func<Transform?>>, int>> CustomNormalCards
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, ValueTuple<List<Func<Transform>>, int>>();

	[field: CompilerGenerated]
	public static Dictionary<ZombieType, ValueTuple<GameObject, Sprite, ZombieData>> CustomZombies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ZombieType, ValueTuple<GameObject, Sprite, ZombieData>>();

	[field: CompilerGenerated]
	public static List<ZombieType> CustomZombieTypes
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<ZombieType>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, PlantAlmanac> PlantsAlmanac
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, PlantAlmanac>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, ValueTuple<string, string>?> PlantsSkinAlmanac
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, ValueTuple<string, string>?>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, ValueTuple<Func<Plant, int>, Action<Plant>, int>> SuperSkills
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, ValueTuple<Func<Plant, int>, Action<Plant>, int>>();

	[field: CompilerGenerated]
	public static Dictionary<ZombieType, ValueTuple<string?, string?, ZombieInfo?>> ZombiesAlmanac
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ZombieType, ValueTuple<string, string, ZombieInfo>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant?, Plant?, Plant?>>, List<Action<Plant?, Plant?, Plant?>>>> CustomMixBombFusions
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>>();

	[field: CompilerGenerated]
	public static Dictionary<int, Action<Bullet>> CustomBulletMovingWay
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, Action<Bullet>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, ValueTuple<int, int>> CustomBuffsLevel
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, ValueTuple<int, int>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, int> CustomBuffIDMapping
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, int>();

	[field: CompilerGenerated]
	public static List<PlantType> CustomUltimatePlants
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<PlantType>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, BuffBgType> CustomBuffsBg
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, BuffBgType>();

	[field: CompilerGenerated]
	public static Dictionary<int, ValueTuple<PlantType, string, int>> CustomUnlockBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, ValueTuple<PlantType, string, int>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, int> CustomStrongUltimatePlants
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, int>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, PlantType>, List<ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>>> CustomClickCardOnPlantEvents
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, PlantType>, List<ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, List<int>> CustomStrongUltimatePlantBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, List<int>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, ValueTuple<Func<bool>?, Action?, Action?>> CustomBanMix
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, ValueTuple<Func<bool>, Action, Action>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, PlantType>, List<Action<Plant>>> CustomOnMixEvent
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, PlantType>, List<Action<Plant>>>();

	[field: CompilerGenerated]
	public static Dictionary<CherryBombType, GameObject> CustomCherrys
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<CherryBombType, GameObject>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, List<ValueTuple<BuffType, int>>> CustomPlantInfo
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, List<ValueTuple<BuffType, int>>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, int> CustomBuffCost
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, int>();

	[field: CompilerGenerated]
	public static Dictionary<string, AssetBundle> LoadedAssetBundles
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<string, AssetBundle>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, int>, Dictionary<BulletType, List<BulletType>>> CustomBulletSkinReplace
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, int>, Dictionary<BulletType, List<BulletType>>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> CustomBulletsSkinID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>>();

	[field: CompilerGenerated]
	public static Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> CustomSkinBullet
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<BulletType, List<ValueTuple<BulletType, GameObject>>>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, bool> EnableSkin
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, bool>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, List<int>> CustomPlantSkinIndex
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, List<int>>();

	[field: CompilerGenerated]
	public static List<AssetBundle> LoadedSkinAssetBundle
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new List<AssetBundle>();

	[field: CompilerGenerated]
	public static Dictionary<PlantType, string> CustomPlantNames
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<PlantType, string>();

	[field: CompilerGenerated]
	public static Dictionary<ZombieType, string> CustomZombieNames
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ZombieType, string>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, string> CustomBuffText
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, string>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, PlantType> CustomBuffIcon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, PlantType>();

	[field: CompilerGenerated]
	public static Dictionary<int, AudioClip> CustomSounds
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<int, AudioClip>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, ValueTuple<string, PlantType, ZombieType>> CustomBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, ValueTuple<string, PlantType, ZombieType>>();

	[field: CompilerGenerated]
	public static Dictionary<ValueTuple<BuffType, int>, ValueTuple<AlmanacBuffType, PlantType, ZombieType>> CustomAlmanacBuffType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<ValueTuple<BuffType, int>, ValueTuple<AlmanacBuffType, PlantType, ZombieType>>();

	[field: CompilerGenerated]
	public static Dictionary<Type, string> CustomEndlessSaveData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Dictionary<Type, string>();

	public static void AddPlantAlmanacStrings(int id, string name, string description)
	{

		string name2 = name;
		if (!((Group)Regex.Match(name, "\\(\\d+\\)$")).Success)
		{
			name2 = $"{name}({id})";
		}
		PlantsAlmanac.Add((PlantType)id, new PlantAlmanac
		{
			name = name2,
			info = description,
			plantType = (PlantType)id
		});
		string text = Regex.Replace(name, "[\\(（].*[\\)）]", "");
		CustomPlantNames.Add((PlantType)id, text);
	}

	public static void AddPlantAlmanacStrings(PlantType plantType, string name, string info, string introduce, int cost)
	{






		string name2 = name;
		if (!((Group)Regex.Match(name, "\\(\\d+\\)$")).Success)
		{
			name2 = $"{name}({(int)plantType})";
		}
		PlantsAlmanac.Add(plantType, new PlantAlmanac
		{
			name = name2,
			info = info,
			introduce = introduce,
			cost = cost.ToString(),
			plantType = plantType
		});
		string text = Regex.Replace(name, "[\\(（].*[\\)）]", "");
		CustomPlantNames.Add(plantType, text);
	}

	public static void AddZombieAlmanacStrings(int id, string name, string description)
	{

		string text = name;
		if (!((Group)Regex.Match(name, "\\(\\d+\\)$")).Success)
		{
			text = $"{name}({id})";
		}
		ZombiesAlmanac.Add((ZombieType)id, new ValueTuple<string, string, ZombieInfo>(text, description, (ZombieInfo)null));
		string text2 = Regex.Replace(name, "[\\(（].*[\\)）]", "");
		CustomZombieNames.Add((ZombieType)id, text2);
	}

	public static void AddZombieAlmanacStrings(int id, ZombieInfo info)
	{

		if (!((Group)Regex.Match(info.name, "\\(\\d+\\)$")).Success)
		{
			info.name = $"{info.name}({id})";
		}
		ZombiesAlmanac.Add((ZombieType)id, new ValueTuple<string, string, ZombieInfo>((string)null, (string)null, info));
		string text = Regex.Replace(info.name, "[\\(（].*[\\)）]", "");
		CustomZombieNames.Add((ZombieType)id, text);
	}

	public static AssetBundle GetAssetBundle(Assembly assembly, string name)
	{







		try
		{
			AssetBundle result = default(AssetBundle);
			bool flag = default(bool);
			if (LoadedAssetBundles.TryGetValue(name, out result))
			{
				ManualLogSource log = ((BasePlugin)Instance.Value).Log;
				BepInExInfoLogInterpolatedStringHandler val = new BepInExInfoLogInterpolatedStringHandler(31, 1, ref flag);
				if (flag)
				{
					((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Successfully load AssetBundle ");
					((BepInExLogInterpolatedStringHandler)val).AppendFormatted<string>(name);
					((BepInExLogInterpolatedStringHandler)val).AppendLiteral(".");
				}
				log.LogInfo(val);
				return result;
			}
			Stream val2 = assembly.GetManifestResourceStream(assembly.FullName.Split(",", (StringSplitOptions)0)[0] + "." + name) ?? assembly.GetManifestResourceStream(name);
			try
			{
				MemoryStream val3 = new MemoryStream();
				try
				{
					val2.CopyTo((Stream)(object)val3);
					AssetBundle assetBundle = AssetBundle.LoadFromMemory(val3.ToArray());
					ArgumentNullException.ThrowIfNull((object)assetBundle, "ab");
					ManualLogSource log2 = ((BasePlugin)Instance.Value).Log;
					BepInExInfoLogInterpolatedStringHandler val = new BepInExInfoLogInterpolatedStringHandler(31, 1, ref flag);
					if (flag)
					{
						((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Successfully load AssetBundle ");
						((BepInExLogInterpolatedStringHandler)val).AppendFormatted<string>(name);
						((BepInExLogInterpolatedStringHandler)val).AppendLiteral(".");
					}
					log2.LogInfo(val);
					LoadedAssetBundles.Add(name, assetBundle);
					return assetBundle;
				}
				finally
				{
					((System.IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			throw new ArgumentException($"Failed to load {name} \n{ex}");
		}
	}

	public static AssetBundle GetAssetBundle(string name)
	{
		return GetAssetBundle(Assembly.GetCallingAssembly(), name);
	}

	public static AssetBundle GetAssetBundleFromPath(string path, string name)
	{





		try
		{
			AssetBundle result = default(AssetBundle);
			bool flag = default(bool);
			BepInExInfoLogInterpolatedStringHandler val;
			if (LoadedAssetBundles.TryGetValue(name, out result))
			{
				ManualLogSource log = ((BasePlugin)Instance.Value).Log;
				val = new BepInExInfoLogInterpolatedStringHandler(31, 1, ref flag);
				if (flag)
				{
					((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Successfully load AssetBundle ");
					((BepInExLogInterpolatedStringHandler)val).AppendFormatted<string>(name);
					((BepInExLogInterpolatedStringHandler)val).AppendLiteral(".");
				}
				log.LogInfo(val);
				return result;
			}
			AssetBundleCreateRequest assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);
			ManualLogSource log2 = ((BasePlugin)Instance.Value).Log;
			val = new BepInExInfoLogInterpolatedStringHandler(31, 1, ref flag);
			if (flag)
			{
				((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Successfully load AssetBundle ");
				((BepInExLogInterpolatedStringHandler)val).AppendFormatted<string>(name);
				((BepInExLogInterpolatedStringHandler)val).AppendLiteral(".");
			}
			log2.LogInfo(val);
			LoadedAssetBundles.Add(name, assetBundleCreateRequest.assetBundle);
			return assetBundleCreateRequest.assetBundle;
		}
		catch (System.Exception ex)
		{
			throw new ArgumentException($"Failed to load {name} \n{ex}");
		}
	}

	public static void PlaySound(AudioClip audio, float volume = 1f)
	{
		GameObject gameObject = new GameObject("SoundPlayer");
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		SoundCtrl val = gameObject.AddComponent<SoundCtrl>();
		audioSource.clip = audio;
		audioSource.volume = volume * GameAPP.config.gameSoundVolume;
		GameAPP.music.PlayOneShot(audio, volume);
	}

	public static void RegisterCustomSound(AudioClip audio, int soundID)
	{


		if (!CustomSounds.ContainsKey(soundID))
		{
			CustomSounds.Add(soundID, audio);
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(19, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate sound id ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<int>(soundID);
		}
		log.LogError(val);
	}

	public static int RegisterCustomBuff(string text, BuffType buffType, Func<bool> canUnlock, int cost, PlantType plantType = (PlantType)(-1), int level = 1, BuffBgType bg = default(BuffBgType))
	{


		return RegisterCustomBuff(text, buffType, canUnlock, cost, (PlantType)(-1), addProbability: false, plantType, level, bg);
	}

	public static int RegisterCustomBuff(string text, BuffType buffType, Func<bool> canUnlock, int cost, PlantType infoType, bool addProbability, PlantType plantType = (PlantType)(-1), int level = 1, BuffBgType bg = default(BuffBgType))
	{



		return RegisterCustomBuff(text, buffType, canUnlock, cost, plantType, level, bg, (ZombieType)0, -1, infoType, addProbability);
	}

	public static int RegisterCustomDebuff(string text, Func<bool> unlock = null, ZombieType zombieType = (ZombieType)0, int level = 1, BuffBgType bg = default(BuffBgType))
	{

		return RegisterCustomBuff(text, (BuffType)3, unlock, 0, (PlantType)(-1), level, bg, zombieType, -1, (PlantType)(-1));
	}

	public static int RegisterCustomBuff(string text, BuffType buffType, Func<bool> canUnlock, int cost, PlantType icon, int level, BuffBgType bgType = default(BuffBgType), ZombieType zombieType = (ZombieType)0, int buffID = -1, PlantType plantType = (PlantType)(-1), bool addProbability = false)
	{


















































		CoreTools.InitBuffDic();
		int num = -1;
		switch ((int)buffType)
		{
		case 1:
			num = CustomBuffStartID + CustomAdvancedBuffs.Count;
			if (buffID != -1)
			{
				num = buffID;
			}
			CustomAdvancedBuffs.Add(num, new ValueTuple<PlantType, string, Func<bool>, int>(icon, text, canUnlock, cost));
			TravelDictionary.advancedBuffsText.Add((AdvBuff)num, text);
			TravelDictionary.AdvBuffPlantPairs.Add((AdvBuff)num, icon);
			break;
		case 2:
			num = CustomBuffStartID + CustomUltimateBuffs.Count;
			if (buffID != -1)
			{
				num = buffID;
			}
			CustomUltimateBuffs.Add(num, new ValueTuple<PlantType, string, int>(icon, text, cost));
			TravelDictionary.ultimateBuffsText.Add((UltiBuff)num, text);
			break;
		case 3:
			num = CustomBuffStartID + CustomDebuffs.Count;
			if (buffID != -1)
			{
				num = buffID;
			}
			CustomDebuffs.Add(num, new ValueTuple<string, ZombieType, Func<bool>>(text, zombieType, canUnlock));
			TravelDictionary.debuffData.Add((TravelDebuff)num, new Il2CppSystem.ValueTuple<string, ZombieType>(text, zombieType));
			TravelHelper.LeaderAppear.Add((TravelDebuff)num);
			break;
		case 0:
			num = CustomBuffStartID + CustomUnlockBuffs.Count;
			if (buffID == -1)
			{
				num = buffID;
			}
			CustomUnlockBuffs.Add(num, new ValueTuple<PlantType, string, int>(icon, text, cost));
			TravelDictionary.unlocksText.Add((TravelUnlocks)num, text);
			break;
		}
		CustomBuffCost.Add(new ValueTuple<BuffType, int>(buffType, num), cost);
		CustomBuffText.Add(new ValueTuple<BuffType, int>(buffType, num), text);
		if ((int)buffType != 3)
		{
			CustomBuffIcon.Add(new ValueTuple<BuffType, int>(buffType, num), icon);
		}
		if (buffID != -1 && !CustomBuffIDMapping.ContainsKey(new ValueTuple<BuffType, int>(buffType, buffID)))
		{
			CustomBuffIDMapping.Add(new ValueTuple<BuffType, int>(buffType, num), buffID);
		}
		if (level != 1)
		{
			CustomBuffsLevel.Add(new ValueTuple<BuffType, int>(buffType, num), new ValueTuple<int, int>(CustomBuffsLevel.Count, level));
		}
		if (!CustomBuffsBg.ContainsKey(new ValueTuple<BuffType, int>(buffType, num)))
		{
			CustomBuffsBg.Add(new ValueTuple<BuffType, int>(buffType, num), bgType);
		}
		if ((int)plantType != -1 && addProbability)
		{
			if (CustomPlantInfo.ContainsKey(plantType))
			{
				CustomPlantInfo[plantType].Add(new ValueTuple<BuffType, int>(buffType, num));
			}
			else
			{
				Dictionary<PlantType, List<ValueTuple<BuffType, int>>> customPlantInfo = CustomPlantInfo;
				List<ValueTuple<BuffType, int>> obj = new List<ValueTuple<BuffType, int>>();
				obj.Add(new ValueTuple<BuffType, int>(buffType, num));
				customPlantInfo.Add(plantType, obj);
			}
		}
		CustomBuffs.Add(new ValueTuple<BuffType, int>(buffType, num), new ValueTuple<string, PlantType, ZombieType>(text, icon, zombieType));
		return num;
	}

	public static void SetCustomBuffAlmanacType(BuffType buffType, int id, AlmanacBuffType type, PlantType icon)
	{




		CustomAlmanacBuffType.Add(new ValueTuple<BuffType, int>(buffType, id), new ValueTuple<AlmanacBuffType, PlantType, ZombieType>(type, icon, (ZombieType)(-1)));
	}

	public static void SetCustomBuffAlmanacType(BuffType buffType, int id, AlmanacBuffType type, ZombieType icon)
	{




		CustomAlmanacBuffType.Add(new ValueTuple<BuffType, int>(buffType, id), new ValueTuple<AlmanacBuffType, PlantType, ZombieType>(type, (PlantType)(-1), icon));
	}

	public static void RegisterCustomBullet<TBullet>(BulletType id, GameObject bulletPrefab) where TBullet : Bullet
	{






		if (!CustomBullets.ContainsKey(id))
		{
			((Bullet)bulletPrefab.AddComponent<TBullet>()).theBulletType = id;
			CustomBullets.Add(id, bulletPrefab);
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(21, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate Bullet ID: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<BulletType>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomBullet<TBase, TBullet>(BulletType id, GameObject bulletPrefab) where TBase : Bullet where TBullet : MonoBehaviour
	{






		if (!CustomBullets.ContainsKey(id))
		{
			((Bullet)bulletPrefab.AddComponent<TBase>()).theBulletType = id;
			bulletPrefab.AddComponent<TBullet>();
			CustomBullets.Add(id, bulletPrefab);
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(21, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate Bullet ID: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<BulletType>(id);
		}
		log.LogError(val);
	}

	public static int RegisterCustomLevel(CustomLevelData ldata)
	{
		int result = (ldata.ID = CustomLevels.Count);
		CustomLevels.Add(ldata);
		return result;
	}

	public static void RegisterCustomParticle(ParticleType id, GameObject particle)
	{

		CustomParticles.Add(id, particle);
	}

	public static void RegisterCustomPlant<TBase, TClass>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, List<ValueTuple<int, int>> fusions, float attackInterval, float produceInterval, int attackDamage, int maxHealth, float cd, int sun) where TBase : Plant where TClass : MonoBehaviour
	{

















		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		prefab.AddComponent<TClass>();
		if (!CustomPlantTypes.Contains((PlantType)id))
		{
			CustomPlantTypes.Add((PlantType)id);
			CustomPlants.Add((PlantType)id, new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				}
			});
			var enumerator = fusions.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<int, int> current = enumerator.Current;
					AddFusion(id, current.Item1, current.Item2);
				}
				return;
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(20, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate Plant ID: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<int>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomPlant<TBase>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, List<ValueTuple<int, int>> fusions, float attackInterval, float produceInterval, int attackDamage, int maxHealth, float cd, int sun) where TBase : Plant
	{

















		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		if (!CustomPlantTypes.Contains((PlantType)id))
		{
			CustomPlantTypes.Add((PlantType)id);
			CustomPlants.Add((PlantType)id, new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				}
			});
			var enumerator = fusions.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<int, int> current = enumerator.Current;
					AddFusion(id, current.Item1, current.Item2);
				}
				return;
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(20, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate Plant ID: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<int>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomPlantSkin<TBase, TClass>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, List<ValueTuple<int, int>> fusions, float attackInterval, float produceInterval, int attackDamage, int maxHealth, float cd, int sun, List<ValueTuple<BulletType, List<GameObject?>>>? bulletSkinList = null) where TBase : Plant where TClass : MonoBehaviour
	{
















































		if (bulletSkinList != null)
		{
			var enumerator = bulletSkinList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<BulletType, List<GameObject>> current = enumerator.Current;
					BulletType item = current.Item1;
					List<GameObject> item2 = current.Item2;
					var enumerator2 = item2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							GameObject current2 = enumerator2.Current;
							BulletType val = (BulletType)(CustomBulletSkinStartID + CustomSkinBullet.Count);
							if (!CustomSkinBullet.ContainsKey(item))
							{
								Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> customSkinBullet = CustomSkinBullet;
								List<ValueTuple<BulletType, GameObject>> obj = new List<ValueTuple<BulletType, GameObject>>();
								obj.Add(new ValueTuple<BulletType, GameObject>(val, current2));
								customSkinBullet.Add(item, obj);
							}
							else
							{
								CustomSkinBullet[item].Add(new ValueTuple<BulletType, GameObject>(val, current2));
							}
							if (!CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>((PlantType)id, item)))
							{
								Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomBulletsSkinID;
								ValueTuple<PlantType, BulletType> val2 = new ValueTuple<PlantType, BulletType>((PlantType)id, item);
								List<BulletType> obj2 = new List<BulletType>();
								obj2.Add(val);
								customBulletsSkinID.Add(val2, obj2);
							}
							else
							{
								CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>((PlantType)id, item)].Add(val);
							}
							RegisteredSkinBulletCount++;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		prefab.tag = "Plant";
		preview.tag = "Preview";
		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		prefab.AddComponent<TClass>();
		if (!CustomPlantsSkinActive.ContainsKey((PlantType)id))
		{
			CustomPlantsSkinActive.Add((PlantType)id, false);
		}
		if (!CustomPlantsSkin.ContainsKey((PlantType)id))
		{
			Dictionary<PlantType, List<CustomPlantData>> customPlantsSkin = CustomPlantsSkin;
			List<CustomPlantData> obj3 = new List<CustomPlantData>();
			obj3.Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				},
				BulletList = bulletSkinList
			});
			customPlantsSkin.Add((PlantType)id, obj3);
		}
		else
		{
			CustomPlantsSkin[(PlantType)id].Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				},
				BulletList = bulletSkinList
			});
		}
		var enumerator3 = fusions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				ValueTuple<int, int> current3 = enumerator3.Current;
				AddFusion(id, current3.Item1, current3.Item2);
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}

	public static void RegisterCustomPlantSkin<TBase>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, List<ValueTuple<int, int>> fusions, float attackInterval, float produceInterval, int attackDamage, int maxHealth, float cd, int sun, List<ValueTuple<BulletType, List<GameObject?>>>? bulletSkinList = null) where TBase : Plant
	{
















































		if (bulletSkinList != null)
		{
			var enumerator = bulletSkinList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<BulletType, List<GameObject>> current = enumerator.Current;
					BulletType item = current.Item1;
					List<GameObject> item2 = current.Item2;
					var enumerator2 = item2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							GameObject current2 = enumerator2.Current;
							BulletType val = (BulletType)(CustomBulletSkinStartID + CustomSkinBullet.Count);
							if (!CustomSkinBullet.ContainsKey(item))
							{
								Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> customSkinBullet = CustomSkinBullet;
								List<ValueTuple<BulletType, GameObject>> obj = new List<ValueTuple<BulletType, GameObject>>();
								obj.Add(new ValueTuple<BulletType, GameObject>(val, current2));
								customSkinBullet.Add(item, obj);
							}
							else
							{
								CustomSkinBullet[item].Add(new ValueTuple<BulletType, GameObject>(val, current2));
							}
							if (!CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>((PlantType)id, item)))
							{
								Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomBulletsSkinID;
								ValueTuple<PlantType, BulletType> val2 = new ValueTuple<PlantType, BulletType>((PlantType)id, item);
								List<BulletType> obj2 = new List<BulletType>();
								obj2.Add(val);
								customBulletsSkinID.Add(val2, obj2);
							}
							else
							{
								CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>((PlantType)id, item)].Add(val);
							}
							RegisteredSkinBulletCount++;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		prefab.tag = "Plant";
		preview.tag = "Preview";
		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		CustomPlantsSkinActive.Add((PlantType)id, false);
		if (!CustomPlantsSkin.ContainsKey((PlantType)id))
		{
			Dictionary<PlantType, List<CustomPlantData>> customPlantsSkin = CustomPlantsSkin;
			List<CustomPlantData> obj3 = new List<CustomPlantData>();
			obj3.Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				},
				BulletList = bulletSkinList
			});
			customPlantsSkin.Add((PlantType)id, obj3);
		}
		else
		{
			CustomPlantsSkin[(PlantType)id].Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = new PlantData
				{
					attackDamage = attackDamage,
					thePlantType = (PlantType)id,
					attackInterval = attackInterval,
					produceInterval = produceInterval,
					maxHealth = maxHealth,
					cd = cd,
					cost = sun
				},
				BulletList = bulletSkinList
			});
		}
		var enumerator3 = fusions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				ValueTuple<int, int> current3 = enumerator3.Current;
				AddFusion(id, current3.Item1, current3.Item2);
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}

	public static void RegisterCustomPlantSkin<TBase>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, Action<TBase> ctor, List<ValueTuple<BulletType, List<GameObject?>>>? bulletSkinList = null) where TBase : Plant
	{
























		if (bulletSkinList != null)
		{
			var enumerator = bulletSkinList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<BulletType, List<GameObject>> current = enumerator.Current;
					BulletType item = current.Item1;
					List<GameObject> item2 = current.Item2;
					var enumerator2 = item2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							GameObject current2 = enumerator2.Current;
							BulletType val = (BulletType)(CustomBulletSkinStartID + CustomSkinBullet.Count);
							if (!CustomSkinBullet.ContainsKey(item))
							{
								Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> customSkinBullet = CustomSkinBullet;
								List<ValueTuple<BulletType, GameObject>> obj = new List<ValueTuple<BulletType, GameObject>>();
								obj.Add(new ValueTuple<BulletType, GameObject>(val, current2));
								customSkinBullet.Add(item, obj);
							}
							else
							{
								CustomSkinBullet[item].Add(new ValueTuple<BulletType, GameObject>(val, current2));
							}
							if (!CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>((PlantType)id, item)))
							{
								Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomBulletsSkinID;
								ValueTuple<PlantType, BulletType> val2 = new ValueTuple<PlantType, BulletType>((PlantType)id, item);
								List<BulletType> obj2 = new List<BulletType>();
								obj2.Add(val);
								customBulletsSkinID.Add(val2, obj2);
							}
							else
							{
								CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>((PlantType)id, item)].Add(val);
							}
							RegisteredSkinBulletCount++;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		prefab.tag = "Plant";
		preview.tag = "Preview";
		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		ctor.Invoke(prefab.GetComponent<TBase>());
		CustomPlantsSkinActive.Add((PlantType)id, false);
		if (!CustomPlantsSkin.ContainsKey((PlantType)id))
		{
			Dictionary<PlantType, List<CustomPlantData>> customPlantsSkin = CustomPlantsSkin;
			List<CustomPlantData> obj3 = new List<CustomPlantData>();
			obj3.Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = null,
				BulletList = bulletSkinList
			});
			customPlantsSkin.Add((PlantType)id, obj3);
		}
		else
		{
			CustomPlantsSkin[(PlantType)id].Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = null,
				BulletList = bulletSkinList
			});
		}
	}

	public static void RegisterCustomPlantSkin<TBase, TClass>([NotNull] int id, [NotNull] GameObject prefab, [NotNull] GameObject preview, Action<TBase> ctor, List<ValueTuple<BulletType, List<GameObject?>>>? bulletSkinList = null) where TBase : Plant where TClass : MonoBehaviour
	{
























		if (bulletSkinList != null)
		{
			var enumerator = bulletSkinList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					ValueTuple<BulletType, List<GameObject>> current = enumerator.Current;
					BulletType item = current.Item1;
					List<GameObject> item2 = current.Item2;
					var enumerator2 = item2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							GameObject current2 = enumerator2.Current;
							BulletType val = (BulletType)(CustomBulletSkinStartID + CustomSkinBullet.Count);
							if (!CustomSkinBullet.ContainsKey(item))
							{
								Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> customSkinBullet = CustomSkinBullet;
								List<ValueTuple<BulletType, GameObject>> obj = new List<ValueTuple<BulletType, GameObject>>();
								obj.Add(new ValueTuple<BulletType, GameObject>(val, current2));
								customSkinBullet.Add(item, obj);
							}
							else
							{
								CustomSkinBullet[item].Add(new ValueTuple<BulletType, GameObject>(val, current2));
							}
							if (!CustomBulletsSkinID.ContainsKey(new ValueTuple<PlantType, BulletType>((PlantType)id, item)))
							{
								Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomBulletsSkinID;
								ValueTuple<PlantType, BulletType> val2 = new ValueTuple<PlantType, BulletType>((PlantType)id, item);
								List<BulletType> obj2 = new List<BulletType>();
								obj2.Add(val);
								customBulletsSkinID.Add(val2, obj2);
							}
							else
							{
								CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>((PlantType)id, item)].Add(val);
							}
							RegisteredSkinBulletCount++;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		prefab.tag = "Plant";
		preview.tag = "Preview";
		((Plant)prefab.AddComponent<TBase>()).thePlantType = (PlantType)id;
		prefab.AddComponent<TClass>();
		ctor.Invoke(prefab.GetComponent<TBase>());
		CustomPlantsSkinActive.Add((PlantType)id, false);
		if (!CustomPlantsSkin.ContainsKey((PlantType)id))
		{
			Dictionary<PlantType, List<CustomPlantData>> customPlantsSkin = CustomPlantsSkin;
			List<CustomPlantData> obj3 = new List<CustomPlantData>();
			obj3.Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = null,
				BulletList = bulletSkinList
			});
			customPlantsSkin.Add((PlantType)id, obj3);
		}
		else
		{
			CustomPlantsSkin[(PlantType)id].Add(new CustomPlantData
			{
				ID = id,
				Prefab = prefab,
				Preview = preview,
				PlantData = null,
				BulletList = bulletSkinList
			});
		}
	}

	public static void RegisterCustomSkinBullet(BulletType origin, BulletType bulletType, GameObject bullet)
	{










		if (CustomSkinBullet.ContainsKey(origin))
		{
			CustomSkinBullet[origin].Add(new ValueTuple<BulletType, GameObject>(bulletType, bullet));
		}
		else
		{
			Dictionary<BulletType, List<ValueTuple<BulletType, GameObject?>>> customSkinBullet = CustomSkinBullet;
			List<ValueTuple<BulletType, GameObject>> obj = new List<ValueTuple<BulletType, GameObject>>();
			obj.Add(new ValueTuple<BulletType, GameObject>(bulletType, bullet));
			customSkinBullet.Add(origin, obj);
		}
		GameAPP.resourcesManager.bulletPrefabs[bulletType] = bullet;
		if (!GameAPP.resourcesManager.allBullets.Contains(bulletType))
		{
			GameAPP.resourcesManager.allBullets.Add(bulletType);
		}
		RegisteredSkinBulletCount++;
	}

	public static void RegisterCustomSprite(int id, Sprite sprite)
	{
		CustomSprites.Add(id, sprite);
	}

	public static void RegisterCustomUseItemOnPlantEvent([NotNull] PlantType id, [NotNull] BucketType bucketType, [NotNull] Action<Plant> callback)
	{



		CustomUseItems.Add(new ValueTuple<PlantType, BucketType>(id, bucketType), callback);
	}

	public static void RegisterCustomUseItemOnPlantEvent([NotNull] PlantType id, [NotNull] BucketType bucketType, [NotNull] PlantType newPlant)
	{





		CustomUseItems.Add(new ValueTuple<PlantType, BucketType>(id, bucketType), (Action<Plant>)delegate(Plant p)
		{

			p.Die((DieReason)0);
			CreatePlant.Instance.SetPlant(p.thePlantColumn, p.thePlantRow, newPlant, (Plant)null, default(Vector2), false, true, (Plant)null);
		});
	}

	public static void RegisterCustomUseFertilizeOnPlantEvent([NotNull] PlantType id, [NotNull] Action<Plant> callback)
	{

		CustomUseFertilize.Add(id, callback);
	}

	public static void RegisterCustomUseFertilizeOnPlantEvent([NotNull] PlantType id, [NotNull] PlantType newPlant)
	{



		CustomUseFertilize.Add(id, (Action<Plant>)delegate(Plant p)
		{

			p.Die((DieReason)0);
			CreatePlant.Instance.SetPlant(p.thePlantColumn, p.thePlantRow, newPlant, (Plant)null, default(Vector2), false, true, (Plant)null);
		});
	}

	public static void RegisterCustomCard([NotNull] PlantType thePlantType, [NotNull] List<Func<Transform?>> parent, int repeatTime = 1)
	{







		if (!CustomCards.ContainsKey(thePlantType))
		{
			CustomCards.Add(thePlantType, new ValueTuple<List<Func<Transform>>, int>(parent, repeatTime));
			return;
		}
		var enumerator = parent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Func<Transform> current = enumerator.Current;
				CustomCards[thePlantType].Item1.Add(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public static void RegisterCustomCard([NotNull] PlantType thePlantType, int repeatTime = 1)
	{





		if (!CustomCards.ContainsKey(thePlantType))
		{
			Dictionary<PlantType, ValueTuple<List<Func<Transform?>>, int>> customCards = CustomCards;
			List<Func<Transform>> obj = new List<Func<Transform>>();
			obj.Add((Func<Transform>)(() => Utils.GetNormalCardParent()));
			customCards.Add(thePlantType, new ValueTuple<List<Func<Transform>>, int>(obj, repeatTime));
		}
		else
		{
			CustomCards[thePlantType].Item1.Add((Func<Transform>)(() => Utils.GetNormalCardParent()));
		}
	}

	public static void RegisterCustomCardToColorfulCards([NotNull] PlantType thePlantType, int repeatTime = 1)
	{

		List<Func<Transform>> obj = new List<Func<Transform>>();
		obj.Add((Func<Transform>)(() => Utils.GetColorfulCardParent()));
		RegisterCustomCard(thePlantType, obj, repeatTime);
	}

	public static void RegisterCustomNormalCard([NotNull] PlantType thePlantType, List<Func<Transform?>> parent, int repeatTime = 1)
	{







		if (!CustomNormalCards.ContainsKey(thePlantType))
		{
			CustomNormalCards.Add(thePlantType, new ValueTuple<List<Func<Transform>>, int>(parent, repeatTime));
			return;
		}
		var enumerator = parent.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Func<Transform> current = enumerator.Current;
				CustomNormalCards[thePlantType].Item1.Add(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public static void RegisterCustomNormalCard([NotNull] PlantType thePlantType, int repeatTime = 1)
	{





		if (!CustomNormalCards.ContainsKey(thePlantType))
		{
			Dictionary<PlantType, ValueTuple<List<Func<Transform?>>, int>> customNormalCards = CustomNormalCards;
			List<Func<Transform>> obj = new List<Func<Transform>>();
			obj.Add((Func<Transform>)(() => Utils.GetNormalCardParent()));
			customNormalCards.Add(thePlantType, new ValueTuple<List<Func<Transform>>, int>(obj, repeatTime));
		}
		else
		{
			CustomNormalCards[thePlantType].Item1.Add((Func<Transform>)(() => Utils.GetNormalCardParent()));
		}
	}

	public static void RegisterCustomZombie<TBase, TClass>(ZombieType id, GameObject zombie, Sprite preview, int theAttackDamage, int theMaxHealth, int theFirstArmorMaxHealth, int theSecondArmorMaxHealth) where TBase : Zombie where TClass : MonoBehaviour
	{














		((Zombie)zombie.AddComponent<TBase>()).theZombieType = id;
		zombie.AddComponent<TClass>();
		if (!CustomZombieTypes.Contains(id))
		{
			CustomZombieTypes.Add(id);
			CustomZombies.Add(id, new ValueTuple<GameObject, Sprite, ZombieData>(zombie, preview, new ZombieData
			{
				theAttackDamage = theAttackDamage,
				theFirstArmorMaxHealth = theFirstArmorMaxHealth,
				theMaxHealth = theMaxHealth,
				theSecondArmorMaxHealth = theSecondArmorMaxHealth
			}));
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(22, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate ZombieType: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<ZombieType>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomZombie<TBase>(ZombieType id, GameObject zombie, Sprite preview, int theAttackDamage, int theMaxHealth, int theFirstArmorMaxHealth, int theSecondArmorMaxHealth) where TBase : Zombie
	{














		((Zombie)zombie.AddComponent<TBase>()).theZombieType = id;
		if (!CustomZombieTypes.Contains(id))
		{
			CustomZombieTypes.Add(id);
			CustomZombies.Add(id, new ValueTuple<GameObject, Sprite, ZombieData>(zombie, preview, new ZombieData
			{
				theAttackDamage = theAttackDamage,
				theFirstArmorMaxHealth = theFirstArmorMaxHealth,
				theMaxHealth = theMaxHealth,
				theSecondArmorMaxHealth = theSecondArmorMaxHealth
			}));
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(22, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate ZombieType: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<ZombieType>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomZombie<TBase, TClass>(ZombieType id, GameObject zombie, Sprite preview, ZombieData data) where TBase : Zombie where TClass : MonoBehaviour
	{








		((Zombie)zombie.AddComponent<TBase>()).theZombieType = id;
		zombie.AddComponent<TClass>();
		if (!CustomZombieTypes.Contains(id))
		{
			CustomZombieTypes.Add(id);
			CustomZombies.Add(id, new ValueTuple<GameObject, Sprite, ZombieData>(zombie, preview, data));
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(22, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate ZombieType: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<ZombieType>(id);
		}
		log.LogError(val);
	}

	public static void RegisterCustomZombie<TBase>(ZombieType id, GameObject zombie, Sprite preview, ZombieData data) where TBase : Zombie
	{








		((Zombie)zombie.AddComponent<TBase>()).theZombieType = id;
		if (!CustomZombieTypes.Contains(id))
		{
			CustomZombieTypes.Add(id);
			CustomZombies.Add(id, new ValueTuple<GameObject, Sprite, ZombieData>(zombie, preview, data));
			return;
		}
		ManualLogSource log = ((BasePlugin)Instance.Value).Log;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(22, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate ZombieType: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<ZombieType>(id);
		}
		log.LogError(val);
	}

	public static void RegisterSuperSkill([NotNull] int id, [NotNull] Func<Plant, int> cost, [NotNull] Action<Plant> skill, [NotNull] int defaultCost = 1000)
	{

		SuperSkills.Add((PlantType)id, new ValueTuple<Func<Plant, int>, Action<Plant>, int>(cost, skill, defaultCost));
	}

	public static void AddUltimatePlant([NotNull] PlantType plantType)
	{

		CustomUltimatePlants.Add(plantType);
	}

	public static void RegisterCustomStrongUltimatePlant([NotNull] PlantType plantType, [NotNull] int id)
	{











		if (!TravelDictionary.allStrongUltimtePlant.Contains(plantType))
		{
			TravelDictionary.allStrongUltimtePlant.Add(plantType);
		}
		if (!TravelDictionary.PlantInfo.ContainsKey(plantType))
		{
			TravelDictionary.PlantInfo.Add(plantType, new Il2CppSystem.ValueTuple<Il2CppSystem.Nullable<PlantType>, Il2CppSystem.Object, Il2CppSystem.Object, bool>(new Il2CppSystem.Nullable<PlantType>(plantType), null, null, item4: true));
		}
		else
		{
			TravelDictionary.PlantInfo[plantType].Item4 = true;
		}
		if (!CustomStrongUltimatePlants.ContainsKey(plantType))
		{
			CustomStrongUltimatePlants.Add(plantType, id);
			return;
		}
		ManualLogSource cLogger = CLogger;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(32, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate strong ultimate type: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<PlantType>(plantType);
		}
		cLogger.LogError(val);
	}

	public static void RegisterCustomMixBombFusion([NotNull] PlantType left, [NotNull] PlantType center, [NotNull] PlantType right, [NotNull] List<Action<Plant, Plant, Plant>> actions, [NotNull] List<Action<Plant, Plant, Plant>> failActions)
	{























		if (CustomMixBombFusions.ContainsKey(new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)))
		{
			var enumerator = actions.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Action<Plant, Plant, Plant> current = enumerator.Current;
					CustomMixBombFusions[new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)].Item1.Add(current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			var enumerator2 = failActions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					Action<Plant, Plant, Plant> current2 = enumerator2.Current;
					CustomMixBombFusions[new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)].Item2.Add(current2);
				}
				return;
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
		}
		CustomMixBombFusions.Add(new ValueTuple<PlantType, PlantType, PlantType>(left, center, right), new ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>(actions, failActions));
	}

	public static void RegisterCustomMixBombFusion([NotNull] PlantType left, [NotNull] PlantType center, [NotNull] PlantType right, [NotNull] Action<Plant, Plant, Plant> action, [NotNull] Action<Plant, Plant, Plant> failAction)
	{




















		if (CustomMixBombFusions.ContainsKey(new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)))
		{
			CustomMixBombFusions[new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)].Item1.Add(action);
			CustomMixBombFusions[new ValueTuple<PlantType, PlantType, PlantType>(left, center, right)].Item2.Add(failAction);
			return;
		}
		Dictionary<ValueTuple<PlantType, PlantType, PlantType>, ValueTuple<List<Action<Plant?, Plant?, Plant?>>, List<Action<Plant?, Plant?, Plant?>>>> customMixBombFusions = CustomMixBombFusions;
		ValueTuple<PlantType, PlantType, PlantType> val = new ValueTuple<PlantType, PlantType, PlantType>(left, center, right);
		ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>> val2 = default(ValueTuple<List<Action<Plant, Plant, Plant>>, List<Action<Plant, Plant, Plant>>>);
		List<Action<Plant, Plant, Plant>> obj = new List<Action<Plant, Plant, Plant>>();
		obj.Add(action);
		val2.Item1 = obj;
		List<Action<Plant, Plant, Plant>> obj2 = new List<Action<Plant, Plant, Plant>>();
		obj2.Add(failAction);
		val2.Item2 = obj2;
		customMixBombFusions.Add(val, val2);
	}

	public static void RegisterCustomMixBombFusion([NotNull] PlantType left, [NotNull] PlantType center, [NotNull] PlantType right, [NotNull] Action<Plant, Plant, Plant> action, [NotNull] string failMessage = "")
	{



		RegisterCustomMixBombFusion(left, center, right, action, delegate
		{
			if (failMessage != "" && InGameText.Instance != null)
			{
				InGameText.Instance.ShowText(failMessage, 5f, false);
			}
		});
	}

	public static void RegisterCustomMixBombFusion([NotNull] PlantType left, [NotNull] PlantType center, [NotNull] PlantType right, [NotNull] PlantType target, [NotNull] string failMessage = "")
	{





		RegisterCustomMixBombFusion(left, center, right, (Action<Plant, Plant, Plant>)delegate(Plant p1, Plant p2, Plant p3)
		{

			Il2Cpp.Lawnf.SetDroppedCard((Vector2)((Entity)p2).axis.transform.position, target, 0);
			p1.Die((DieReason)0);
			p2.Die((DieReason)0);
			p3.Die((DieReason)0);
			GameAPP.PlaySound(125, 0.5f, 1f);
		}, (Action<Plant, Plant, Plant>)delegate
		{
			if (failMessage != "" && InGameText.Instance != null)
			{
				InGameText.Instance.ShowText(failMessage, 5f, false);
			}
		});
	}

	public static void RegisterCustomMixBombFusion([NotNull] PlantType left, [NotNull] PlantType center, [NotNull] PlantType right, [NotNull] PlantType target, [NotNull] Action<Plant, Plant, Plant> failAction)
	{





		RegisterCustomMixBombFusion(left, center, right, (Action<Plant, Plant, Plant>)delegate(Plant p1, Plant p2, Plant p3)
		{

			Il2Cpp.Lawnf.SetDroppedCard((Vector2)((Entity)p2).axis.transform.position, target, 0);
			p1.Die((DieReason)0);
			p2.Die((DieReason)0);
			p3.Die((DieReason)0);
		}, failAction);
	}

	public static void AddFusion(int target, int item1, int item2)
	{

		CustomFusions.Add(new ValueTuple<int, int, int>(target, item1, item2));
	}

	public static void AddFusion(PlantType target, PlantType item1, PlantType item2)
	{







		CustomFusions.Add(new ValueTuple<int, int, int>((int)target, (int)item1, (int)item2));
	}

	public static void RegisterCustomBulletMovingWay(int id, Action<Bullet> action)
	{
		CustomBulletMovingWay.Add(id, action);
	}

	public static void RegisterCustomCherry(CherryBombType id, [NotNull] GameObject prefab)
	{



		RegisterCustomParticle((ParticleType)(CustomCherryStartID + id), prefab);
		CustomCherrys.Add(id, prefab);
	}

	public static void RegisterCustomCherry<T>(CherryBombType id, [NotNull] GameObject prefab) where T : MonoBehaviour
	{



		if (!ClassInjector.IsTypeRegisteredInIl2Cpp<T>())
		{
			ClassInjector.RegisterTypeInIl2Cpp<T>();
		}
		prefab.AddComponent<T>();
		RegisterCustomParticle((ParticleType)(CustomCherryStartID + id), prefab);
		CustomCherrys.Add(id, prefab);
	}

	public static void RegisterCustomClickCardOnPlantEvent([NotNull] PlantType plantType, [NotNull] PlantType cardType, [NotNull] Action<Plant> action, Func<Plant, bool> canClick = null, [NotNull] CustomClickCardOnPlant onPlant = default(CustomClickCardOnPlant))
	{











		if (CustomClickCardOnPlantEvents.ContainsKey(new ValueTuple<PlantType, PlantType>(plantType, cardType)))
		{
			CustomClickCardOnPlantEvents[new ValueTuple<PlantType, PlantType>(plantType, cardType)].Add(new ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>(action, canClick, onPlant));
			return;
		}
		Dictionary<ValueTuple<PlantType, PlantType>, List<ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>>> customClickCardOnPlantEvents = CustomClickCardOnPlantEvents;
		ValueTuple<PlantType, PlantType> val = new ValueTuple<PlantType, PlantType>(plantType, cardType);
		List<ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>> obj = new List<ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>>();
		obj.Add(new ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant>(action, canClick, onPlant));
		customClickCardOnPlantEvents.Add(val, obj);
	}

	public static void RegisterCustomBanMix([NotNull] PlantType plantType, Func<bool>? func = null, Action? success = null, Action? fail = null)
	{






		if (!CustomBanMix.ContainsKey(plantType))
		{
			CustomBanMix.Add(plantType, new ValueTuple<Func<bool>, Action, Action>(func, success, fail));
			return;
		}
		ManualLogSource cLogger = CLogger;
		bool flag = default(bool);
		BepInExErrorLogInterpolatedStringHandler val = new BepInExErrorLogInterpolatedStringHandler(30, 1, ref flag);
		if (flag)
		{
			((BepInExLogInterpolatedStringHandler)val).AppendLiteral("Duplicate ban mix plant type: ");
			((BepInExLogInterpolatedStringHandler)val).AppendFormatted<PlantType>(plantType);
		}
		cLogger.LogError(val);
	}

	public static void RegisterCustomOnMixEvent(PlantType baseType, PlantType newType, List<Action<Plant>> actions)
	{











		if (!CustomOnMixEvent.ContainsKey(new ValueTuple<PlantType, PlantType>(baseType, newType)))
		{
			CustomOnMixEvent.Add(new ValueTuple<PlantType, PlantType>(baseType, newType), actions);
			return;
		}
		var enumerator = actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Action<Plant> current = enumerator.Current;
				CustomOnMixEvent[new ValueTuple<PlantType, PlantType>(baseType, newType)].Add(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public static void RegisterCustomOnMixEvent(PlantType baseType, PlantType newType, Action<Plant> action)
	{


		List<Action<Plant>> obj = new List<Action<Plant>>();
		obj.Add(action);
		RegisterCustomOnMixEvent(baseType, newType, obj);
	}

	public static void AddPlantName(PlantType plantType, string name)
	{

		CustomPlantNames.Add(plantType, name);
	}

	public static void AddZombieName(ZombieType zombieType, string name)
	{

		CustomZombieNames.Add(zombieType, name);
	}

	public override void Load()
	{
		ClassInjector.RegisterTypeInIl2Cpp<CustomPlantMonoBehaviour>();
		ClassInjector.RegisterTypeInIl2Cpp<SelectCustomPlants>();
		ClassInjector.RegisterTypeInIl2Cpp<CheckCardState>();
		ClassInjector.RegisterTypeInIl2Cpp<ExtensionDataComponent>();
		ClassInjector.RegisterTypeInIl2Cpp<DataComponent>();
		ClassInjector.RegisterTypeInIl2Cpp<CoreBehaviour>();
		ClassInjector.RegisterTypeInIl2Cpp<PositionRecorder>();
		ClassInjector.RegisterTypeInIl2Cpp<EmptyDoom>();
		ClassInjector.RegisterTypeInIl2Cpp<InterfaceBehaviour>();
		ClassInjector.RegisterTypeInIl2Cpp<CustomHealthText>();
		ClassInjector.RegisterTypeInIl2Cpp<SaveMaterial>();
		ClassInjector.RegisterTypeInIl2Cpp<SelectCustomPlants>();
		SkinBehaviourMgr.Init();
		HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		InitCoreData();
		MapValue.InitDatas();
		HookCall.RegisterTypes();
	}

	public void InitCoreData()
	{
		CoreData.Instance = new Lazy<CustomCore>(() => this);
		CoreData.Logger = new Lazy<ManualLogSource>(() => ((BasePlugin)this).Log);
		CoreData.Harmony = new Lazy<HarmonyLib.Harmony>(() => HarmonyInstance);
	}

	public override bool Unload()
	{
		ObjectPinner.Release();
		return true;
	}
}
