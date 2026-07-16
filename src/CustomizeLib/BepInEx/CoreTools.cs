using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class CoreTools
{

	public static Dictionary<string, AdvBuff> AdvBuffPair = new Dictionary<string, AdvBuff>();

	public static Dictionary<string, UltiBuff> UltiBuffPair = new Dictionary<string, UltiBuff>();

	public static Dictionary<string, TravelDebuff> DebuffBuffPair = new Dictionary<string, TravelDebuff>();

	public static float ColumnX
	{
		get
		{
			if ((UnityEngine.Object)(object)Mouse.Instance != null && !((UnityEngine.Object)(object)Mouse.Instance).IsDestroyed())
			{
				return Mouse.Instance.GetBoxXFromColumn(1) - Mouse.Instance.GetBoxXFromColumn(0);
			}
			return 1f;
		}
	}

	public static float RowY
	{
		get
		{
			if ((UnityEngine.Object)(object)Mouse.Instance != null && !((UnityEngine.Object)(object)Mouse.Instance).IsDestroyed())
			{
				return Mouse.Instance.GetBoxYFromRow(1) - Mouse.Instance.GetBoxYFromRow(0);
			}
			return 1f;
		}
	}

	public static void InitBuffDic()
	{
		TravelDictionary.advancedBuffsText = new Il2CppSystem.Collections.Generic.Dictionary<AdvBuff, string>();
		TravelDictionary.AdvBuffPlantPairs = new Il2CppSystem.Collections.Generic.Dictionary<AdvBuff, PlantType>();
		TravelDictionary.allStrongUltimtePlant = new Il2CppSystem.Collections.Generic.List<PlantType>();
		TravelDictionary.CurseBuffs = new Il2CppSystem.Collections.Generic.HashSet<AdvBuff>();
		TravelDictionary.debuffData = new Il2CppSystem.Collections.Generic.Dictionary<TravelDebuff, Il2CppSystem.ValueTuple<string, ZombieType>>();
		TravelDictionary.PlantInfo = new Il2CppSystem.Collections.Generic.Dictionary<PlantType, Il2CppSystem.ValueTuple<Il2CppSystem.Nullable<PlantType>, Il2CppSystem.Object, Il2CppSystem.Object, bool>>();
		TravelDictionary.RandomBuffs = new Il2CppSystem.Collections.Generic.HashSet<AdvBuff>();
		TravelDictionary.RogueBuffs = new Il2CppSystem.Collections.Generic.HashSet<AdvBuff>();
		TravelDictionary.ultimateBuffsText = new Il2CppSystem.Collections.Generic.Dictionary<UltiBuff, string>();
		TravelDictionary.unlocksText = new Il2CppSystem.Collections.Generic.Dictionary<TravelUnlocks, string>();
	}

	public static System.Collections.IEnumerator Init()
	{
		while (TravelDictionary.advancedBuffsText.Count < System.Enum.GetValues<AdvBuff>().Length)
		{
			yield return new WaitForSeconds(1f);
		}
		Il2CppSystem.Collections.Generic.Dictionary<AdvBuff, string>.Enumerator enumerator = TravelDictionary.advancedBuffsText.GetEnumerator();
		string value;
		while (enumerator.MoveNext())
		{
			enumerator.Current.Deconstruct(out var key, out value);
			AdvBuff buff = key;
			string str = value;
			int index = str.IndexOf('：');
			if (index == -1)
			{
				index = str.IndexOf(":");
			}
			if (index != -1 && !AdvBuffPair.ContainsKey(str.Substring(0, index)))
			{
				AdvBuffPair.Add(str.Substring(0, index), buff);
			}
		}
		while (TravelDictionary.ultimateBuffsText.Count < System.Enum.GetValues<UltiBuff>().Length)
		{
			yield return new WaitForSeconds(1f);
		}
		Il2CppSystem.Collections.Generic.Dictionary<UltiBuff, string>.Enumerator enumerator2 = TravelDictionary.ultimateBuffsText.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			enumerator2.Current.Deconstruct(out var key2, out value);
			UltiBuff buff2 = key2;
			string str2 = value;
			int index2 = str2.IndexOf('：');
			if (index2 == -1)
			{
				index2 = str2.IndexOf(":");
			}
			if (index2 != -1 && !UltiBuffPair.ContainsKey(str2.Substring(0, index2)))
			{
				UltiBuffPair.Add(str2.Substring(0, index2), buff2);
			}
		}
		while (TravelDictionary.ultimateBuffsText.Count < System.Enum.GetValues<TravelDebuff>().Length)
		{
			yield return new WaitForSeconds(1f);
		}
		Il2CppSystem.Collections.Generic.Dictionary<TravelDebuff, Il2CppSystem.ValueTuple<string, ZombieType>>.Enumerator enumerator3 = TravelDictionary.debuffData.GetEnumerator();
		while (enumerator3.MoveNext())
		{
			enumerator3.Current.Deconstruct(out var key3, out var value2);
			TravelDebuff buff3 = key3;
			Il2CppSystem.ValueTuple<string, ZombieType> tuple = value2;
			string str3 = tuple.Item1;
			int index3 = str3.IndexOf('：');
			if (index3 == -1)
			{
				index3 = str3.IndexOf(":");
			}
			if (index3 != -1 && !DebuffBuffPair.ContainsKey(str3.Substring(0, index3)))
			{
				DebuffBuffPair.Add(str3.Substring(0, index3), buff3);
			}
		}
	}

	public static AdvBuff GetAdvBuffByString(string name)
	{




		if (AdvBuffPair.ContainsKey(name))
		{
			return AdvBuffPair[name];
		}
		return (AdvBuff)(-1);
	}

	public static UltiBuff GetUltiBuffByString(string name)
	{




		if (UltiBuffPair.ContainsKey(name))
		{
			return UltiBuffPair[name];
		}
		return (UltiBuff)(-1);
	}

	public static TravelDebuff GetTravelDebuffByString(string name)
	{




		if (DebuffBuffPair.ContainsKey(name))
		{
			return DebuffBuffPair[name];
		}
		return (TravelDebuff)(-1);
	}

	public static TravelUnlocks GetTravelUnlocksByString(string name)
	{


		int num = -1;
		switch (global::_003CPrivateImplementationDetails_003E.ComputeStringHash(name))
		{
		case 579291176u:
			if (name == "UltimateChomper")
			{
				num = 0;
			}
			break;
		case 3642137842u:
			if (name == "UltimateGatling")
			{
				num = 1;
			}
			break;
		case 1230894425u:
			if (name == "UltimateFume")
			{
				num = 2;
			}
			break;
		case 4092523632u:
			if (name == "UltimateTorch")
			{
				num = 3;
			}
			break;
		case 3288302550u:
			if (name == "UltimateStar")
			{
				num = 4;
			}
			break;
		case 2080084114u:
			if (name == "UltimateGloom")
			{
				num = 5;
			}
			break;
		case 782615001u:
			if (name == "UltimateMelon")
			{
				num = 6;
			}
			break;
		case 2651869455u:
			if (name == "UltimateCannon")
			{
				num = 7;
			}
			break;
		case 586257720u:
			if (name == "UltimateTallNut")
			{
				num = 8;
			}
			break;
		case 1808007360u:
			if (name == "UltimateHypno")
			{
				num = 9;
			}
			break;
		case 1392432628u:
			if (name == "UltimateBigGatling")
			{
				num = 10;
			}
			break;
		case 3918294657u:
			if (name == "UltimateCabbage")
			{
				num = 11;
			}
			break;
		case 3901976090u:
			if (name == "UltimatePumpkin")
			{
				num = 12;
			}
			break;
		case 2492855731u:
			if (name == "UltimateSpring")
			{
				num = 13;
			}
			break;
		case 174472378u:
			if (name == "UltimateKelp")
			{
				num = 14;
			}
			break;
		case 772492824u:
			if (name == "UltimateCorn")
			{
				num = 15;
			}
			break;
		case 884725436u:
			if (name == "UltimateSpruce")
			{
				num = 16;
			}
			break;
		case 1194366690u:
			if (name == "UltimateBigChomper")
			{
				num = 17;
			}
			break;
		case 1598971790u:
			if (name == "UltimateExplodeCannon")
			{
				num = 18;
			}
			break;
		case 1501075583u:
			if (name == "UltimateSunflower")
			{
				num = 19;
			}
			break;
		case 2463483526u:
			if (name == "UltimateWinterMelon")
			{
				num = 20;
			}
			break;
		case 3799210076u:
			if (name == "UltimateCattail")
			{
				num = 21;
			}
			break;
		case 2548218397u:
			if (name == "UltimateSeaShroom")
			{
				num = 22;
			}
			break;
		case 421145996u:
			if (name == "UltimateJalapeno")
			{
				num = 23;
			}
			break;
		}
		return (TravelUnlocks)num;
	}

	public static bool TravelAdvanced(string name)
	{

		return Lawnf.TravelAdvanced(GetAdvBuffByString(name));
	}

	public static bool TravelUltimate(string name)
	{

		return Lawnf.TravelUltimate(GetUltiBuffByString(name));
	}

	public static int TravelUltimateLevel(string name)
	{

		return Lawnf.TravelUltimateLevel(GetUltiBuffByString(name));
	}

	public static bool TravelDebuff(string name)
	{

		return Lawnf.TravelDebuff(GetTravelDebuffByString(name));
	}

	public static List<int> Range(int end = 1)
	{
		List<int> val = new List<int>();
		for (int i = 0; i < end; i++)
		{
			val.Add(i);
		}
		return val;
	}

	public static GameObject CreateCherryExplodeCustom(Vector2 v, int theRow, CherryBombType bombType = (CherryBombType)0, int damage = 1800, PlantType fromType = (PlantType)(-1), Action<Zombie> action = null, bool immediately = true, bool shake = true)
	{







		GameObject result = CreateParticle.SetParticle(CustomCore.CustomCherryStartID + (int)bombType, (Vector3)v, 11, true);
		if (shake)
		{
			ScreenShake.TriggerShake(0.15f);
		}
		GameAPP.PlaySound(40, 0.5f, 1f);
		BombCherry val = new BombCherry();
		val.board = Board.Instance;
		val.damageToZombie = damage;
		val.bombRow = theRow;
		val.bombType = bombType;
		val.zombieAction = action;
		val.bombPosition = v;
		val.fromType = fromType;
		val.targetPlant = null;
		if (immediately)
		{
			val.Explode(CustomDamageMaker.DamageMaker);
		}
		return result;
	}

	public static ValueTuple<BombCherry, GameObject> CreateCherryExplode(Vector2 v, int theRow, CherryBombType bombType = (CherryBombType)0, int damage = 1800, PlantType fromType = (PlantType)(-1), Action<Zombie> action = null, bool immediately = true, bool shake = true, int soundID = 40, float volume = 0.5f, float pitch = 1f)
	{





















		if ((UnityEngine.Object)(object)Board.Instance == null || ((UnityEngine.Object)(object)Board.Instance).IsDestroyed())
		{
			return new ValueTuple<BombCherry, GameObject>((BombCherry)null, (GameObject)null);
		}
		GameObject gameObject = null;
		if (CustomCore.CustomCherrys.ContainsKey(bombType))
		{
			gameObject = CreateParticle.SetParticle(CustomCore.CustomCherryStartID + (int)bombType, (Vector3)v, 11, true);
			GameAPP.PlaySound(soundID, volume, pitch);
		}
		else
		{
			gameObject = (((int)bombType == 1) ? CreateParticle.SetParticle(3, (Vector3)v, 11, true).gameObject : (((int)bombType == 2 || (int)bombType == 5) ? CreateParticle.SetParticle(14, (Vector3)v, 11, true).gameObject : (((int)bombType != 3) ? CreateParticle.SetParticle(2, (Vector3)v, 11, true).gameObject : CreateParticle.SetParticle(100, (Vector3)v, 11, true).gameObject)));
			GameAPP.PlaySound(soundID, volume, pitch);
		}
		if (shake)
		{
			ScreenShake.TriggerShake(0.15f);
		}
		BombCherry val = new BombCherry();
		val.board = Board.Instance;
		val.damageToZombie = damage;
		val.bombRow = theRow;
		val.bombType = bombType;
		val.zombieAction = action;
		val.bombPosition = v;
		val.fromType = fromType;
		val.targetPlant = null;
		if (immediately)
		{
			val.Explode(CustomDamageMaker.DamageMaker);
		}
		return new ValueTuple<BombCherry, GameObject>(val, gameObject);
	}

	public static bool IsObjExist(this Component component)
	{
		return !(component == null) && !component.IsDestroyed() && !(component.gameObject == null) && !component.gameObject.IsDestroyed();
	}

	public static bool IsObjExist(this GameObject gameObject)
	{
		return !(gameObject == null) && !gameObject.IsDestroyed();
	}

	public static int GetStarProbability()
	{
		int num = 0;
		GameConfig config = GameAPP.config;
		if (config.levelZombieInRandom)
		{
			num += 2;
		}
		if (config.strongUltiZombieInRandom)
		{
			num += 2;
		}
		if (config.leaderInRandom)
		{
			num += 6;
		}
		return num;
	}

	public static string FormatAlmanac(string input)
	{
		return StringFormatter.Format(input);
	}
}
