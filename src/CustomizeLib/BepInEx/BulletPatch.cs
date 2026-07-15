using CustomizeLib.BepInEx.ExtensionData.Basic;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Bullet))]
public static class BulletPatch
{
	[HarmonyPatch("Update")]
	[HarmonyPostfix]
	public static void PrePostionUpdate(Bullet __instance)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected I4, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected I4, but got Unknown
		if (CustomCore.CustomBulletMovingWay.ContainsKey((int)__instance.MoveWay))
		{
			CustomCore.CustomBulletMovingWay[(int)__instance.MoveWay].Invoke(__instance);
		}
	}

	[HarmonyPatch("Die")]
	[HarmonyPrefix]
	public static void PreDie(Bullet __instance)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)(object)__instance).GetData("SkinData") != null)
		{
			PositionRecorder.AddPositonToList(((Component)(object)__instance).transform.position, __instance.fromType);
			__instance.theBulletType = ((Component)(object)__instance).GetData<BulletType>("SkinData");
		}
	}
}
