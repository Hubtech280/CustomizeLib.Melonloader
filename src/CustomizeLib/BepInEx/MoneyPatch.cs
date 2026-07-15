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
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
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
