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




		if (CustomCore.CustomBulletMovingWay.ContainsKey((int)__instance.MoveWay))
		{
			CustomCore.CustomBulletMovingWay[(int)__instance.MoveWay].Invoke(__instance);
		}
	}

	[HarmonyPatch("Die")]
	[HarmonyPrefix]
	public static void PreDie(Bullet __instance)
	{


		if (((Component)(object)__instance).GetData("SkinData") != null)
		{
			PositionRecorder.AddPositonToList(((Component)(object)__instance).transform.position, __instance.fromType);
			__instance.theBulletType = ((Component)(object)__instance).GetData<BulletType>("SkinData");
		}
	}
}
