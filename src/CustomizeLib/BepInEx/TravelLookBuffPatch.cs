using System;
using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TravelLookBuff))]
public static class TravelLookBuffPatch
{
	[HarmonyPatch("SetBuff")]
	[HarmonyPrefix]
	public static void PreSetBuff(TravelLookBuff __instance, Il2CppSystem.Object buff)
	{

		((TravelBuffOptionButton)(object)__instance).GeneralSet(buff);
	}

	[HarmonyPatch("SetBuff")]
	[HarmonyPostfix]
	public static void PostSetBuff(TravelLookBuff __instance)
	{

























		ValueTuple<BuffType, int> val = ((TravelBuffOptionButton)(object)__instance).TryGetTypeAndID();
		BuffType item = val.Item1;
		int item2 = val.Item2;
		if (CustomCore.CustomBuffIcon.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			if (((TravelBuffOptionButton)__instance).show != null)
			{
				UnityEngine.Object.Destroy(((TravelBuffOptionButton)__instance).show);
			}
			((TravelBuffOptionButton)__instance).SetPlant(CustomCore.CustomBuffIcon[new ValueTuple<BuffType, int>(item, item2)]);
		}
		if (CustomCore.CustomBuffsBg.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
				((TravelBuffOptionButton)__instance).SetBackground((TravelBuffOptionButton.BgType)CustomCore.CustomBuffsBg[new ValueTuple<BuffType, int>(item, item2)]);
		}
		if (CustomCore.CustomDebuffs.ContainsKey(item2))
		{
			if (((TravelBuffOptionButton)__instance).show != null)
			{
				UnityEngine.Object.Destroy(((TravelBuffOptionButton)__instance).show);
			}
			((TravelBuffOptionButton)__instance).SetZombie(CustomCore.CustomDebuffs[item2].Item2);
		}
		ValueTuple<bool, int> val2 = MultiLevelBuff.IsMultiLevelBuff(item, item2);
		try
		{
			if (!val2.Item1)
			{
				return;
			}
			int[] buffArray = MultiLevelBuff.GetBuffArray();
			if (buffArray == null)
			{
				return;
			}
			int item3 = val2.Item2;
			int buffMaxLevel = MultiLevelBuff.GetBuffMaxLevel(item, item2);
			if (TravelLookMenu.Instance.showAll)
			{
				__instance.SetText(buffArray[item3] != 0, buffArray[item3]);
				if (buffArray[item3] <= buffMaxLevel && buffArray[item3] != 0)
				{
					if (buffMaxLevel > 1)
					{
						__instance.SetText($"已开启（{buffArray[item3]}级）");
					}
					else
					{
						__instance.SetText("已开启");
					}
				}
			}
			else
			{
				if (buffArray[item3] < buffMaxLevel && buffMaxLevel != 1)
				{
					__instance.SetText($"{buffArray[item3]}级");
				}
				else if (buffArray[item3] >= buffMaxLevel && buffMaxLevel != 1)
				{
					__instance.SetText("已满级");
				}
				((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
			}
		}
		catch (ArgumentException ex)
		{
			ArgumentException ex2 = ex;
			ManualLogSource cLogger = CustomCore.CLogger;
			bool flag = default(bool);
			BepInExWarningLogInterpolatedStringHandler val3 = new BepInExWarningLogInterpolatedStringHandler(12, 1, ref flag);
			if (flag)
			{
				((BepInExLogInterpolatedStringHandler)val3).AppendLiteral("StackTrace: ");
				((BepInExLogInterpolatedStringHandler)val3).AppendFormatted<string>(((System.Exception)(object)ex2).StackTrace);
			}
			cLogger.LogWarning(val3);
		}
	}

	[HarmonyPatch("OnMouseUpAsButton")]
	[HarmonyPrefix]
	public static bool PreOnMouseUpAsButton(TravelLookBuff __instance)
	{















		ValueTuple<BuffType, int> val = ((TravelBuffOptionButton)(object)__instance).TryGetTypeAndID();
		BuffType item = val.Item1;
		int item2 = val.Item2;
		ValueTuple<bool, int> val2 = MultiLevelBuff.IsMultiLevelBuff(item, item2);
		bool flag = false;
		if (val2.Item1)
		{
			try
			{
				int[] buffArray = MultiLevelBuff.GetBuffArray();
				if (buffArray == null)
				{
					return true;
				}
				int item3 = val2.Item2;
				int buffMaxLevel = MultiLevelBuff.GetBuffMaxLevel(item, item2);
				if (TravelLookMenu.Instance.showAll)
				{
					MultiLevelBuff.AddBuffLevel(item, item2);
					__instance.SetText(buffArray[item3] != 0, buffArray[item3]);
					if (buffArray[item3] <= buffMaxLevel && buffArray[item3] != 0)
					{
						if (buffMaxLevel > 1)
						{
							__instance.SetText($"已开启（{buffArray[item3]}级）");
						}
						else
						{
							__instance.SetText("已开启");
						}
					}
					((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
					return false;
				}
				if (buffArray[item3] < buffMaxLevel && CoreTools.TravelAdvanced("升级") && buffMaxLevel != 1)
				{
					buffArray[item3]++;
					flag = true;
					if (buffArray[item3] >= buffMaxLevel)
					{
						__instance.SetText("已满级");
					}
					else
					{
						__instance.SetText($"{buffArray[item3]}级");
					}
				}
				if (buffArray[item3] >= buffMaxLevel)
				{
					__instance.SetText("已满级");
				}
				((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
			}
			catch (ArgumentException ex)
			{
				ArgumentException ex2 = ex;
				ManualLogSource cLogger = CustomCore.CLogger;
				bool flag2 = default(bool);
				BepInExWarningLogInterpolatedStringHandler val3 = new BepInExWarningLogInterpolatedStringHandler(12, 1, ref flag2);
				if (flag2)
				{
					((BepInExLogInterpolatedStringHandler)val3).AppendLiteral("StackTrace: ");
					((BepInExLogInterpolatedStringHandler)val3).AppendFormatted<string>(((System.Exception)(object)ex2).StackTrace);
				}
				cLogger.LogWarning(val3);
			}
		}
		if (flag)
		{
			((TravelBuffOptionButton)__instance).manager.data.advBuffs.Remove(CoreTools.GetAdvBuffByString("升级"));
			return false;
		}
		return true;
	}
}
