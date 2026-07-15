using System;
using System.Collections.Generic;
using System.Linq;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Board))]
public static class Board_Patch
{
	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart()
	{
		if (!((Object)(object)TravelMgr.Instance == null))
		{
			if (((Component)(object)TravelMgr.Instance).GetData("LoadByEndless") == null)
			{
				((Component)(object)TravelMgr.Instance).SetData("LoadByEndless", false);
			}
			if ((((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel") == null || (((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel") != null && Enumerable.SequenceEqual<int>((System.Collections.Generic.IEnumerable<int>)((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel"), (System.Collections.Generic.IEnumerable<int>)new int[CustomCore.CustomAdvancedBuffs.Count]))) && !((Component)(object)TravelMgr.Instance).GetData<bool>("LoadByEndless"))
			{
				((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", new int[CustomCore.CustomAdvancedBuffs.Count]);
			}
		}
	}

	[HarmonyPatch("OnDestroy")]
	[HarmonyPostfix]
	public static void PostOnDestroy()
	{
		try
		{
			if (!((Object)(object)TravelMgr.Instance == null))
			{
				if (((Component)(object)TravelMgr.Instance).GetData("LoadByEndless") == null)
				{
					((Component)(object)TravelMgr.Instance).SetData("LoadByEndless", false);
				}
				if ((((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel") == null || (((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel") != null && Enumerable.SequenceEqual<int>((System.Collections.Generic.IEnumerable<int>)((Component)(object)TravelMgr.Instance).GetData<int[]>("CustomBuffsLevel"), (System.Collections.Generic.IEnumerable<int>)new int[CustomCore.CustomAdvancedBuffs.Count]))) && !((Component)(object)TravelMgr.Instance).GetData<bool>("LoadByEndless"))
				{
					((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", new int[CustomCore.CustomAdvancedBuffs.Count]);
				}
			}
		}
		catch
		{
		}
	}

	[HarmonyPatch("Update")]
	[HarmonyPostfix]
	public static void PostUpdate()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected I4, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)TravelMgr.Instance == null)
		{
			return;
		}
		try
		{
			int[] array = (int[])((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel");
			if (array == null)
			{
				return;
			}
			var enumerator = CustomCore.CustomBuffsLevel.GetEnumerator();
			try
			{
				ValueTuple<BuffType, int> val = default(ValueTuple<BuffType, int>);
				ValueTuple<int, int> val2 = default(ValueTuple<int, int>);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out val, out val2);
					ValueTuple<BuffType, int> val3 = val;
					ValueTuple<int, int> val4 = val2;
					ValueTuple<bool, int> val5 = MultiLevelBuff.IsMultiLevelBuff(val3.Item1, val3.Item2);
					if (!val5.Item1)
					{
						continue;
					}
					int item = val5.Item2;
					if (item >= array.Length)
					{
						continue;
					}
					TravelData data = TravelMgr.Instance.data;
					BuffID buffID = new BuffID(val3.Item2);
					BuffType item2 = val3.Item1;
					BuffType val6 = item2;
					switch ((int)val6)
					{
					case 1:
						if (!data.advBuffs.Contains(buffID))
						{
							array[item] = 0;
						}
						if (array[item] <= 0 && data.advBuffs.Contains(buffID))
						{
							array[item] = 1;
						}
						break;
					case 2:
						if (!data.ultiBuffs.Contains(buffID) && !data.ultiBuffs_lv2.Contains(buffID))
						{
							array[item] = 0;
						}
						if (array[item] <= 0 && data.ultiBuffs.Contains(buffID))
						{
							array[item] = 1;
						}
						if (array[item] <= 0 && data.ultiBuffs_lv2.Contains(buffID))
						{
							array[item] = 2;
						}
						break;
					case 3:
						if (!data.travelDebuffs.Contains(buffID))
						{
							array[item] = 0;
						}
						if (array[item] <= 0 && data.travelDebuffs.Contains(buffID))
						{
							array[item] = 1;
						}
						break;
					case 0:
						if (!data.unlockedPlants.Contains(buffID))
						{
							array[item] = 0;
						}
						if (array[item] <= 0 && data.unlockedPlants.Contains(buffID))
						{
							array[item] = 1;
						}
						break;
					}
					((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", array);
				}
			}
			finally
			{
				((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
			}
		}
		catch (ArgumentException)
		{
		}
	}

	[HarmonyPatch("WheatLimit")]
	[HarmonyPrefix]
	public static bool PreWheatLimit(ref PlantType plantType, ref bool __result)
	{
		if (CustomCore.CustomUltimatePlants.Contains(plantType))
		{
			__result = true;
			return false;
		}
		return true;
	}
}
