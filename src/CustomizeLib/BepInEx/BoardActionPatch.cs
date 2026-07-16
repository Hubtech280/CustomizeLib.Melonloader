using System;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(BoardAction))]
public static class BoardActionPatch
{
	[HarmonyPatch("CreateCherryExplode")]
	[HarmonyPrefix]
	public static bool PreCreateCherryExplode(Board __instance, ref Vector2 v, ref int theRow, ref CherryBombType bombType, ref int damage, ref PlantType fromType, ref Action<Zombie> action, ref bool immediately, ref BombCherry __result)
	{


		if (CustomCore.CustomCherrys.ContainsKey(bombType) && (UnityEngine.Object)(object)__instance != null)
		{
			CreateParticle.SetParticle(CustomCore.CustomCherryStartID + (int)bombType, (Vector3)v, 11, true);
			ScreenShake.TriggerShake(0.15f);
			GameAPP.PlaySound(40, 0.5f, 1f);
			BombCherry val = new BombCherry();
			val.board = __instance;
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
			__result = val;
			return false;
		}
		return true;
	}
}
