namespace CustomizeLib.BepInEx;

public class SkinMgr
{
	public static bool IsPlantSkinEnable(PlantType plantType)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (CustomCore.EnableSkin.ContainsKey(plantType))
		{
			return CustomCore.EnableSkin[plantType];
		}
		CustomCore.EnableSkin.Add(plantType, false);
		return false;
	}
}
