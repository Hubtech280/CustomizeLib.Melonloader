using System;
using System.Collections;
using System.Collections.Generic;
using HarmonyLib;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(AlmanacZombieMenu))]
public class AlmanacZombieMenuPatch
{
	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void Postfix(AlmanacZombieMenu __instance)
	{


		if (!(((Component)(object)__instance).transform.Find("LoolAll_Other") == null))
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(((Component)(object)__instance).transform.Find("LookAll_1").gameObject, ((Component)(object)__instance).transform);
		gameObject.transform.localPosition = new Vector2(10f, 0f);
		gameObject.name = "LoolAll_Other";
		gameObject.transform.localPosition = new Vector2(440f, -499f);
		System.Collections.Generic.IEnumerator<TextMeshProUGUI> enumerator = gameObject.GetComponentsInChildren<TextMeshProUGUI>().GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				TextMeshProUGUI current = enumerator.Current;
				if ((UnityEngine.Object)(object)current != null)
				{
					((TMP_Text)current).text = "二创僵尸";
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		UIButton component = gameObject.GetComponent<UIButton>();
		UnityEvent unityEvent = new UnityEvent();
		Action val = (Action)delegate
		{
			Func<ZombieType, bool> val2 = (ZombieType zt) => !System.Enum.IsDefined<ZombieType>(zt);
			__instance.ShowZombieCards((Func<ZombieType, bool>)val2);
		};
		unityEvent.AddListener(val);
		gameObject.GetComponent<UIButton>().clickEvent = unityEvent;
	}
}
