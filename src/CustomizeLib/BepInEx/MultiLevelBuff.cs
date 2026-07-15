using System;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

public static class MultiLevelBuff
{
	public static ValueTuple<bool, int> IsMultiLevelBuff(BuffType buffType, int returnID)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<int, int> buffDataInDic = GetBuffDataInDic(buffType, returnID);
		ValueTuple<int, int> val = buffDataInDic;
		if (val.Item1 != -1 || val.Item2 != -1)
		{
			int item = buffDataInDic.Item1;
			return new ValueTuple<bool, int>(buffDataInDic.Item2 > 0, item);
		}
		return new ValueTuple<bool, int>(false, -1);
	}

	public static int GetBuffCurrentLevel(BuffType buffType, int id)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<bool, int> val = IsMultiLevelBuff(buffType, id);
		if (val.Item1)
		{
			if (TravelMgr.Instance == null)
			{
				return 0;
			}
			int[] buffArray = GetBuffArray();
			if (buffArray == null)
			{
				return 0;
			}
			return buffArray[val.Item2];
		}
		return 0;
	}

	public static int GetBuffMaxLevel(BuffType buffType, int id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetBuffDataInDic(buffType, id).Item2;
	}

	public static ValueTuple<int, int> GetBuffDataInDic(BuffType buffType, int id)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.CustomBuffsLevel.ContainsKey(new ValueTuple<BuffType, int>(buffType, id)))
		{
			return CustomCore.CustomBuffsLevel[new ValueTuple<BuffType, int>(buffType, id)];
		}
		return new ValueTuple<int, int>(-1, -1);
	}

	public static int[] GetBuffArray()
	{
		return (int[])((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel");
	}

	public static void AddBuffLevel(BuffType buffType, int buffID, int value = 1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SetBuffLevel(buffType, buffID, GetBuffCurrentLevel(buffType, buffID) + value);
	}

	public static void SetBuffLevel(BuffType buffType, int buffID, int value)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected I4, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected I4, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		int num = value % (GetBuffMaxLevel(buffType, buffID) + 1);
		TravelData data = TravelMgr.Instance.data;
		int[] buffArray = GetBuffArray();
		BuffID buffID2 = new BuffID(buffID);
		int item = IsMultiLevelBuff(buffType, buffID).Item2;
		buffArray[item] = num;
		if (buffArray[item] > GetBuffMaxLevel(buffType, buffID))
		{
			buffArray[item] = 0;
		}
		if (buffArray[item] == 0)
		{
			switch ((int)buffType)
			{
			case 1:
				if (data.advBuffs.Contains(buffID2))
				{
					TravelMgr.Instance.data.advBuffs.Remove(buffID2);
				}
				break;
			case 2:
				if (data.ultiBuffs.Contains(buffID2))
				{
					data.ultiBuffs.Remove(buffID2);
				}
				if (data.ultiBuffs_lv2.Contains(buffID2))
				{
					data.ultiBuffs_lv2.Remove(buffID2);
				}
				break;
			case 3:
				if (data.travelDebuffs.Contains(buffID2))
				{
					data.travelDebuffs.Add(buffID2);
				}
				break;
			case 0:
				if (data.unlockedPlants.Contains(buffID2))
				{
					data.unlockedPlants.Add(buffID2);
				}
				break;
			}
		}
		else
		{
			switch ((int)buffType)
			{
			case 1:
				if (!data.advBuffs.Contains(buffID2))
				{
					data.advBuffs.Add(buffID2);
				}
				break;
			case 2:
				if (!data.ultiBuffs.Contains(buffID2))
				{
					data.ultiBuffs.Add(buffID2);
				}
				if (!data.ultiBuffs_lv2.Contains(buffID2))
				{
					data.ultiBuffs_lv2.Add(buffID2);
				}
				break;
			case 3:
				if (!data.travelDebuffs.Contains(buffID2))
				{
					data.travelDebuffs.Add(buffID2);
				}
				break;
			case 0:
				if (!data.unlockedPlants.Contains(buffID2))
				{
					data.unlockedPlants.Add(buffID2);
				}
				break;
			}
		}
		((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
	}

	public static int TravelCustomBuffLevel(BuffType buffType, int returnID)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return GetBuffCurrentLevel(buffType, returnID);
	}

	public static void SetToolText(UIButton self, BuffType buffType, int id, bool have)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		TextMeshProUGUI componentInChildren = ((Component)(object)self).GetComponentInChildren<TextMeshProUGUI>();
		int buffCurrentLevel = GetBuffCurrentLevel(buffType, id);
		if (!((Object)(object)componentInChildren == null))
		{
			if (have)
			{
				((TMP_Text)componentInChildren).text = $"已开启（{buffCurrentLevel}级）";
				((Graphic)(object)componentInChildren).color = Color.green;
			}
			else
			{
				((TMP_Text)componentInChildren).text = "已关闭";
				((Graphic)(object)componentInChildren).color = Color.white;
			}
		}
	}
}
