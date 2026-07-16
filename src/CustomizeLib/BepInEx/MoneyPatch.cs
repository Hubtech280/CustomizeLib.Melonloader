using Il2CppCore;
using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Money))]
public static class MoneyPatch
{
	[HarmonyPrefix]
	[HarmonyPatch("ReinforcePlant")]
	public static bool PreReinforcePlant(Money __instance, ref Plant plant)
	{





		if (CustomCore.SuperSkills.ContainsKey(plant.thePlantType))
		{
			int num = CustomCore.SuperSkills[plant.thePlantType].Item1.Invoke(plant);
			if (Board.Instance.theMoney < num)
			{
				InGameText.Instance.ShowText($"大招需要{num}金币", 5f, false);
				return false;
			}
			if (plant.SuperSkill())
			{
				CustomCore.SuperSkills[plant.thePlantType].Item2.Invoke(plant);
				plant.AnimSuperShoot();
				__instance.UsedEvent(plant.thePlantColumn, plant.thePlantRow, num);
				__instance.OtherSuperSkill(plant);
			}
			return false;
		}
		return true;
	}
}
