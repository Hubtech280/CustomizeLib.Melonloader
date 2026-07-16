namespace CustomizeLib.BepInEx;

public class SkinMgr
{
	public static bool IsPlantSkinEnable(PlantType plantType)
	{



		if (CustomCore.EnableSkin.ContainsKey(plantType))
		{
			return CustomCore.EnableSkin[plantType];
		}
		CustomCore.EnableSkin.Add(plantType, false);
		return false;
	}
}
