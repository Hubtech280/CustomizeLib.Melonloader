using System;
using System.Collections.Generic;
using BepInEx.Core.Logging.Interpolation;
using BepInEx.Logging;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(AlmanacBuffMenu))]
public static class AlmanacBuffMenuPatch
{
	[HarmonyPatch("OnToolClick")]
	[HarmonyPrefix]
	public static bool PreOnToolClick(AlmanacBuffMenu __instance, ref UIButton button)
	{
















		if ((UnityEngine.Object)(object)__instance.current == null)
		{
			return true;
		}
		Il2CppSystem.Object buff = __instance.cardInfos[__instance.current].buff;
		ValueTuple<BuffType, int> typeAndID = TravelExtensions.GetTypeAndID(buff);
		BuffType item = typeAndID.Item1;
		int item2 = typeAndID.Item2;
		ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff(item, item2);
		bool flag = false;
		if (val.Item1)
		{
			try
			{
				TextMeshProUGUI componentInChildren = ((Component)(object)button).GetComponentInChildren<TextMeshProUGUI>();
				int[] buffArray = MultiLevelBuff.GetBuffArray();
				if (buffArray == null)
				{
					return true;
				}
				int item3 = val.Item2;
				int buffMaxLevel = MultiLevelBuff.GetBuffMaxLevel(item, item2);
				if (__instance.editMode)
				{
					MultiLevelBuff.AddBuffLevel(item, item2);
					MultiLevelBuff.SetToolText(button, item, item2, buffArray[item3] != 0);
					((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
					float num = (Lawnf.HasTravelBuff(buff) ? 0f : 1f);
					((Component)(object)__instance.current).GetComponent<Image>().color = new Color(num, 1f, num, 1f);
					return false;
				}
				if (buffArray[item3] < buffMaxLevel && CoreTools.TravelAdvanced("升级") && buffMaxLevel != 1)
				{
					buffArray[item3]++;
					flag = true;
					if (buffArray[item3] >= buffMaxLevel)
					{
						((TMP_Text)componentInChildren).text = "已满级";
					}
					else
					{
						((TMP_Text)componentInChildren).text = $"{buffArray[item3]}级";
					}
				}
				if (buffArray[item3] >= buffMaxLevel)
				{
					((TMP_Text)componentInChildren).text = "已满级";
				}
				((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", buffArray);
				float num2 = (Lawnf.HasTravelBuff(buff) ? 0f : 1f);
				((Component)(object)__instance.current).GetComponent<Image>().color = new Color(num2, 1f, num2, 1f);
			}
			catch (ArgumentException ex)
			{
				ArgumentException ex2 = ex;
				ManualLogSource cLogger = CustomCore.CLogger;
				bool flag2 = default(bool);
				BepInExWarningLogInterpolatedStringHandler val2 = new BepInExWarningLogInterpolatedStringHandler(12, 1, ref flag2);
				if (flag2)
				{
					((BepInExLogInterpolatedStringHandler)val2).AppendLiteral("StackTrace: ");
					((BepInExLogInterpolatedStringHandler)val2).AppendFormatted<string>(((System.Exception)(object)ex2).StackTrace);
				}
				cLogger.LogWarning(val2);
			}
		}
		if (flag)
		{
			TravelMgr.Instance.data.advBuffs.Remove(CoreTools.GetAdvBuffByString("升级"));
			return false;
		}
		return true;
	}

	[HarmonyPatch("OnCardClick")]
	[HarmonyPostfix]
	public static void PostOnCardClick(AlmanacBuffMenu __instance, ref AlmanacCardUI card)
	{










		UIButton component = ((Component)(object)__instance).transform.FindChild("Tool").GetComponent<UIButton>();
		TextMeshProUGUI componentInChildren = ((Component)(object)component).GetComponentInChildren<TextMeshProUGUI>();
		if ((UnityEngine.Object)(object)__instance.current == null || !__instance.cardInfos.ContainsKey(__instance.current))
		{
			return;
		}
		Il2CppSystem.Object buff = __instance.cardInfos[__instance.current].buff;
		ValueTuple<BuffType, int> typeAndID = TravelExtensions.GetTypeAndID(buff);
		BuffType item = typeAndID.Item1;
		int item2 = typeAndID.Item2;
		int[] buffArray = MultiLevelBuff.GetBuffArray();
		if (buffArray != null)
		{
			ValueTuple<bool, int> val = MultiLevelBuff.IsMultiLevelBuff(item, item2);
			if (val.Item1)
			{
				MultiLevelBuff.SetToolText(component, item, item2, buffArray[val.Item2] != 0);
			}
		}
	}

	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart(AlmanacBuffMenu __instance)
	{



























































		GameObject gameObject = ((Component)(object)__instance).transform.FindChild("Scroll View/Viewport/Content/curseBuffs").gameObject;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, ((Component)(object)__instance).transform.FindChild("Scroll View/Viewport/Content"));
		gameObject2.name = "customBuffs";
		((TMP_Text)gameObject2.transform.GetChild(0).GetComponent<TextMeshProUGUI>()).text = "二创词条";
		Il2CppSystem.Collections.Generic.List<AlmanacCardUI> list = new Il2CppSystem.Collections.Generic.List<AlmanacCardUI>();
		int num = 0;
		var enumerator = CustomCore.CustomBuffs.GetEnumerator();
		ValueTuple<BuffType, int> val = default(ValueTuple<BuffType, int>);
		try
		{
			ValueTuple<string, PlantType, ZombieType> val2 = default(ValueTuple<string, PlantType, ZombieType>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val, out val2);
				ValueTuple<BuffType, int> val3 = val;
				ValueTuple<string, PlantType, ZombieType> val4 = val2;
				BuffType item = val3.Item1;
				int item2 = val3.Item2;
				string item3 = val4.Item1;
				PlantType item4 = val4.Item2;
				ZombieType item5 = val4.Item3;
				Il2CppSystem.Object obj = new Il2CppSystem.Object();
				BuffType val5 = item;
				BuffType val6 = val5;
				switch ((int)val6)
				{
				case 0:
					obj = Il2CppExtensions.BoxEnumToIl2Object<TravelUnlocks>((object)item2);
					break;
				case 1:
					obj = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item2);
					break;
				case 2:
					obj = Il2CppExtensions.BoxEnumToIl2Object<UltiBuff>((object)item2);
					break;
				case 3:
					obj = Il2CppExtensions.BoxEnumToIl2Object<TravelDebuff>((object)item2);
					break;
				case 4:
					obj = Il2CppExtensions.BoxEnumToIl2Object<InvestBuff>((object)item2);
					break;
				}
				if (Lawnf.HasTravelBuff(obj) || __instance.editMode || AlmanacBuffMenu.lookBuff)
				{
					CardInfo val7 = new CardInfo
					{
						buff = obj,
						description = item3,
						isZombie = ((int)item == 3)
					};
					if ((int)item == 3)
					{
						val7.zombieType = item5;
					}
					else
					{
						val7.plantType = item4;
					}
					__instance.CreateCardUI(val7, list);
					float num2 = (Lawnf.HasTravelBuff(obj) ? 0f : 1f);
					((Component)(object)list[num]).GetComponent<Image>().color = new Color(num2, 1f, num2, 1f);
					num++;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		var enumerator2 = list.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			AlmanacCardUI current = enumerator2.Current;
			((Component)(object)current).gameObject.SetActive(value: false);
		}
		Action val8 = (Action)delegate
		{
			__instance.SetAllCards(false);
			var enumerator4 = list.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				AlmanacCardUI current2 = enumerator4.Current;
				((Component)(object)current2).gameObject.SetActive(value: true);
			}
		};
		UnityEvent unityEvent = new UnityEvent();
		unityEvent.AddListener(val8);
		gameObject2.GetComponent<UIButton>().clickEvent = unityEvent;
		var enumerator3 = CustomCore.CustomAlmanacBuffType.GetEnumerator();
		try
		{
			ValueTuple<AlmanacBuffType, PlantType, ZombieType> val9 = default(ValueTuple<AlmanacBuffType, PlantType, ZombieType>);
			while (enumerator3.MoveNext())
			{
				enumerator3.Current.Deconstruct(out val, out val9);
				ValueTuple<BuffType, int> val10 = val;
				ValueTuple<AlmanacBuffType, PlantType, ZombieType> val11 = val9;
				BuffType item6 = val10.Item1;
				int item7 = val10.Item2;
				AlmanacBuffType item8 = val11.Item1;
				PlantType item9 = val11.Item2;
				ZombieType item10 = val11.Item3;
				Il2CppSystem.Object obj2 = new Il2CppSystem.Object();
				Il2CppSystem.Collections.Generic.List<AlmanacCardUI> list2 = new Il2CppSystem.Collections.Generic.List<AlmanacCardUI>();
				switch (item8)
				{
				case AlmanacBuffType.WeakUltimate:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.weakUltiBuffs;
					break;
				case AlmanacBuffType.StrongUltimate:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<UltiBuff>((object)item7);
					list2 = __instance.strongUltiBuffs;
					break;
				case AlmanacBuffType.General:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.generalBuffs;
					break;
				case AlmanacBuffType.Random:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.randomBuffs;
					break;
				case AlmanacBuffType.Curse:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.curseBuffs;
					break;
				case AlmanacBuffType.Rogue:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.rogueBuffs;
					break;
				case AlmanacBuffType.Combo:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.comboBuffs;
					break;
				case AlmanacBuffType.Tiny:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.tinyBuffs;
					break;
				case AlmanacBuffType.Zombie:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.zombieBuffs;
					break;
				case AlmanacBuffType.Shooting:
					obj2 = Il2CppExtensions.BoxEnumToIl2Object<AdvBuff>((object)item7);
					list2 = __instance.shootingBuffs;
					break;
				}
				if (Lawnf.HasTravelBuff(obj2) || __instance.editMode || AlmanacBuffMenu.lookBuff)
				{
					CardInfo val12 = new CardInfo
					{
						buff = obj2,
						description = TravelMgr.Instance.GetText(obj2),
						plantType = item9
					};
					__instance.CreateCardUI(val12, list2);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}

	[HarmonyPatch("OnCardClick")]
	[HarmonyPostfix]
	public static void PostOnCardClick(AlmanacBuffMenu __instance, AlmanacCardUI card)
	{












		CardInfo val = __instance.cardInfos[card];
		ValueTuple<BuffType, int> typeAndID = TravelExtensions.GetTypeAndID(val.buff);
		BuffType item = typeAndID.Item1;
		int item2 = typeAndID.Item2;
		if (CustomCore.CustomBuffsBg.ContainsKey(new ValueTuple<BuffType, int>(item, item2)))
		{
			if (CustomCore.CustomBuffsBg[new ValueTuple<BuffType, int>(item, item2)].BgType == (int)BuffBgType.Day)
			{
				__instance.windowBackground.sprite = __instance.day;
			}
			else if (CustomCore.CustomBuffsBg[new ValueTuple<BuffType, int>(item, item2)].BgType == (int)BuffBgType.Night)
			{
				__instance.windowBackground.sprite = __instance.night;
			}
			else if (CustomCore.CustomBuffsBg[new ValueTuple<BuffType, int>(item, item2)].BgType == (int)BuffBgType.Night)
			{
				__instance.windowBackground.sprite = __instance.pool;
			}
		}
	}
}
