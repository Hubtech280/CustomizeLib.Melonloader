using System;
using System.Collections;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UltimateIceDoom))]
public static class UltimateIceDoomPatch
{
	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart(UltimateIceDoom __instance)
	{

		if (!SkinMgr.IsPlantSkinEnable(((Plant)__instance).thePlantType))
		{
			return;
		}
		__instance.targetPrefab = Resources.Load<GameObject>("plants/doomshroom/ultimateicedoom/Target");
		__instance.portalIn = ((Component)(object)__instance).transform.FindChild("PortalIn").gameObject;
		__instance.portalOut = ((Component)(object)__instance).transform.FindChild("PortalOut").gameObject;
		System.Collections.Generic.IEnumerator<Transform> enumerator = ((Component)(object)__instance).transform.GetComponentsInChildren<Transform>(includeInactive: true).GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				Transform current = enumerator.Current;
				if (current.gameObject.name.StartsWith("bodies_"))
				{
					__instance.bodies.Add(current.gameObject);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
	}
}
