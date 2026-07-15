using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Il2CppGameLevel;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public struct CustomLevelData
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<List<int>> _003C_003E9__0_0;

		public static Func<List<PlantType>> _003C_003E9__0_1;

		public static Func<List<int>> _003C_003E9__0_2;

		public static Func<string> _003C_003E9__0_3;

		public static Action<Board> _003C_003E9__0_4;

		public static Action<InitBoard> _003C_003E9__0_5;

		public static Action _003C_003E9__0_6;

		public static Func<List<ValueTuple<int, int, PlantType>>> _003C_003E9__0_7;

		public static Func<List<PlantType>> _003C_003E9__0_8;

		public static Func<List<PlantType>> _003C_003E9__0_9;

		public static Func<int> _003C_003E9__0_10;

		public static Func<List<ValueTuple<int, int>>> _003C_003E9__0_11;

		public static Func<int> _003C_003E9__0_12;

		public static Func<int> _003C_003E9__0_13;

		public static Func<List<ZombieType>> _003C_003E9__0_14;

		internal List<int> _003C_002Ector_003Eb__0_0()
		{
			return new List<int>();
		}

		internal List<PlantType> _003C_002Ector_003Eb__0_1()
		{
			return new List<PlantType>();
		}

		internal List<int> _003C_002Ector_003Eb__0_2()
		{
			return new List<int>();
		}

		internal string _003C_002Ector_003Eb__0_3()
		{
			return "";
		}

		internal void _003C_002Ector_003Eb__0_4(Board _)
		{
		}

		internal void _003C_002Ector_003Eb__0_5(InitBoard _)
		{
		}

		internal void _003C_002Ector_003Eb__0_6()
		{
		}

		internal List<ValueTuple<int, int, PlantType>> _003C_002Ector_003Eb__0_7()
		{
			return new List<ValueTuple<int, int, PlantType>>();
		}

		internal List<PlantType> _003C_002Ector_003Eb__0_8()
		{
			return new List<PlantType>();
		}

		internal List<PlantType> _003C_002Ector_003Eb__0_9()
		{
			return new List<PlantType>();
		}

		internal int _003C_002Ector_003Eb__0_10()
		{
			return 500;
		}

		internal List<ValueTuple<int, int>> _003C_002Ector_003Eb__0_11()
		{
			return new List<ValueTuple<int, int>>();
		}

		internal int _003C_002Ector_003Eb__0_12()
		{
			return 10;
		}

		internal int _003C_002Ector_003Eb__0_13()
		{
			return 1;
		}

		internal List<ZombieType> _003C_002Ector_003Eb__0_14()
		{
			return new List<ZombieType>();
		}
	}

	[field: CompilerGenerated]
	public Func<List<int>> AdvBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = () => new List<int>();

	[field: CompilerGenerated]
	public MusicType BgmType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = (MusicType)2;

	[field: CompilerGenerated]
	public BoardTag BoardTag
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = default(BoardTag);

	[field: CompilerGenerated]
	public Func<List<PlantType>> ConveyBeltPlantTypes
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = () => new List<PlantType>();

	[field: CompilerGenerated]
	public Func<List<int>> Debuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = () => new List<int>();

	[field: CompilerGenerated]
	public int ID
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = 0;

	[field: CompilerGenerated]
	public Sprite Logo
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = new Sprite();

	[field: CompilerGenerated]
	public Func<string> Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = () => "";

	[field: CompilerGenerated]
	public bool NeedSelectCard
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = true;

	[field: CompilerGenerated]
	public Action<Board> PostBoard
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = delegate
	{
	};

	[field: CompilerGenerated]
	public Action<InitBoard> PostInitBoard
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = delegate
	{
	};

	[field: CompilerGenerated]
	public Action PreInitBoard
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<List<ValueTuple<int, int, PlantType>>> PrePlants
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<List<PlantType>> PreSelectCards
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool RealBoss2
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int RowCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public SceneType SceneType
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<List<PlantType>> SeedRainPlantTypes
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<int> Sun
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<List<ValueTuple<int, int>>> UltiBuffs
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<int> WaveCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<int> ZombieHealthRate
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Func<List<ZombieType>> ZombieList
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Il2CppGameLevel.LevelData LevelData
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public CustomLevelData()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		object obj = _003C_003Ec._003C_003E9__0_6;
		if (obj == null)
		{
			Action val = delegate
			{
			};
			_003C_003Ec._003C_003E9__0_6 = val;
			obj = (object)val;
		}
		PreInitBoard = (Action)obj;
		PrePlants = () => new List<ValueTuple<int, int, PlantType>>();
		PreSelectCards = () => new List<PlantType>();
		RealBoss2 = false;
		RowCount = 5;
		SceneType = (SceneType)0;
		SeedRainPlantTypes = () => new List<PlantType>();
		Sun = () => 500;
		UltiBuffs = () => new List<ValueTuple<int, int>>();
		WaveCount = () => 10;
		ZombieHealthRate = () => 1;
		ZombieList = () => new List<ZombieType>();
		LevelData = new Il2CppGameLevel.LevelData();
	}
}
