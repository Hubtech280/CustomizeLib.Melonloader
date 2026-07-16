using HarmonyLib;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(TypeMgr))]
public static class TypeMgrPatch
{
	[HarmonyPrefix]
	[HarmonyPatch("BigNut")]
	public static bool PreBigNut(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.BigNut.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.BigNut.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsDriverZombie")]
	public static bool PreDriverZombie(ref ZombieType theZombieType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.DriverZombie.Contains(theZombieType))
		{
			__result = true;
			return false;
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("BigZombie")]
	public static bool PreBigZombie(ref ZombieType theZombieType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.BigZombie.Contains(theZombieType))
		{
			__result = true;
			return false;
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("DoubleBoxPlants")]
	public static bool PreDoubleBoxPlants(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.DoubleBoxPlants.Contains(thePlantType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.DoubleBoxPlants.TryGetValue(thePlantType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("FlyingPlants")]
	public static bool PreFlyingPlants(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.FlyingPlants.Contains(thePlantType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.FlyingPlants.TryGetValue(thePlantType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("GetPlantTag")]
	public static bool PreGetPlantTag(ref Plant plant)
	{








































		if (CustomCore.CustomPlantTypes.Contains(plant.thePlantType))
		{
			plant.plantTag = new PlantTag
			{
				icePlant = TypeMgr.IsIcePlant(plant.thePlantType),
				caltropPlant = TypeMgr.IsCaltrop(plant.thePlantType),
				doubleBoxPlant = TypeMgr.DoubleBoxPlants(plant.thePlantType),
				firePlant = TypeMgr.IsFirePlant(plant.thePlantType),
				flyingPlant = TypeMgr.FlyingPlants(plant.thePlantType),
				lanternPlant = TypeMgr.IsPlantern(plant.thePlantType),
				smallLanternPlant = TypeMgr.IsSmallRangeLantern(plant.thePlantType),
				magnetPlant = TypeMgr.IsMagnetPlants(plant.thePlantType),
				nutPlant = TypeMgr.IsNut(plant.thePlantType),
				tallNutPlant = TypeMgr.IsTallNut(plant.thePlantType),
				potatoPlant = TypeMgr.IsPotatoMine(plant.thePlantType),
				potPlant = TypeMgr.IsPot(plant.thePlantType),
				puffPlant = TypeMgr.IsPuff(plant.thePlantType),
				pumpkinPlant = TypeMgr.IsPumpkin(plant.thePlantType),
				spickRockPlant = TypeMgr.IsSpickRock(plant.thePlantType),
				tanglekelpPlant = TypeMgr.IsTangkelp(plant.thePlantType),
				waterPlant = TypeMgr.IsWaterPlant(plant.thePlantType)
			};
			return false;
		}
		if (CustomCore.CustomPlantsSkin.ContainsKey(plant.thePlantType))
		{
			plant.plantTag = new PlantTag
			{
				icePlant = TypeMgr.IsIcePlant(plant.thePlantType),
				caltropPlant = TypeMgr.IsCaltrop(plant.thePlantType),
				doubleBoxPlant = TypeMgr.DoubleBoxPlants(plant.thePlantType),
				firePlant = TypeMgr.IsFirePlant(plant.thePlantType),
				flyingPlant = TypeMgr.FlyingPlants(plant.thePlantType),
				lanternPlant = TypeMgr.IsPlantern(plant.thePlantType),
				smallLanternPlant = TypeMgr.IsSmallRangeLantern(plant.thePlantType),
				magnetPlant = TypeMgr.IsMagnetPlants(plant.thePlantType),
				nutPlant = TypeMgr.IsNut(plant.thePlantType),
				tallNutPlant = TypeMgr.IsTallNut(plant.thePlantType),
				potatoPlant = TypeMgr.IsPotatoMine(plant.thePlantType),
				potPlant = TypeMgr.IsPot(plant.thePlantType),
				puffPlant = TypeMgr.IsPuff(plant.thePlantType),
				pumpkinPlant = TypeMgr.IsPumpkin(plant.thePlantType),
				spickRockPlant = TypeMgr.IsSpickRock(plant.thePlantType),
				tanglekelpPlant = TypeMgr.IsTangkelp(plant.thePlantType),
				waterPlant = TypeMgr.IsWaterPlant(plant.thePlantType)
			};
			return false;
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsCaltrop")]
	public static bool PreIsCaltrop(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsCaltrop.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsCaltrop.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsFirePlant")]
	public static bool PreIsFirePlant(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsFirePlant.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsFirePlant.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsIcePlant")]
	public static bool PreIsIcePlant(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsIcePlant.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsIcePlant.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsMagnetPlants")]
	public static bool PreIsMagnetPlants(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsMagnetPlants.Contains(thePlantType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsMagnetPlants.TryGetValue(thePlantType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsNut")]
	public static bool PreIsNut(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsNut.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsNut.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPlantern")]
	public static bool PreIsPlantern(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsPlantern.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPlantern.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPot")]
	public static bool PreIsPot(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsPot.Contains(thePlantType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPot.TryGetValue(thePlantType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPotatoMine")]
	public static bool PreIsPotatoMine(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsPotatoMine.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPotatoMine.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPuff")]
	public static bool PreIsPuff(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsPuff.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPuff.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPumpkin")]
	public static bool PreIsPumpkin(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsPumpkin.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPumpkin.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsSmallRangeLantern")]
	public static bool PreIsSmallRangeLantern(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsSmallRangeLantern.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSmallRangeLantern.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsPurplePlant")]
	public static bool PreIsPurplePlant(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsSpecialPlant.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSpecialPlant.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsSpickRock")]
	public static bool PreIsSpickRock(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsSpickRock.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSpickRock.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsTallNut")]
	public static bool PreIsTallNut(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsTallNut.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsTallNut.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsTangkelp")]
	public static bool PreIsTangkelp(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsTangkelp.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsTangkelp.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("IsWaterPlant")]
	public static bool PreIsWaterPlant(ref PlantType theSeedType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.IsWaterPlant.Contains(theSeedType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsWaterPlant.TryGetValue(theSeedType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}

	[HarmonyPrefix]
	[HarmonyPatch("UmbrellaPlants")]
	public static bool PreUmbrellaPlants(ref PlantType thePlantType, ref bool __result)
	{
		if (CustomCore.TypeMgrExtra.UmbrellaPlants.Contains(thePlantType))
		{
			__result = true;
			return false;
		}
		int num = default(int);
		if (CustomCore.TypeMgrExtraSkin.UmbrellaPlants.TryGetValue(thePlantType, out num))
		{
			switch (num)
			{
			case -1:
				return true;
			case 0:
				__result = false;
				return false;
			case 1:
				__result = true;
				return false;
			}
		}
		return true;
	}
}
