using CustomizeLib.BepInEx.ExtensionData.Basic;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class ZombieExtensions
{
	public static void UnCold(this Zombie zombie)
	{
		zombie.GetAttrTimers().coldTimer = 0f;
	}

	public static void TakeDamage(this Zombie zombie, DamageType theDamageType, int theDamage, PlantType reportType = (PlantType)(-1), bool fix = false)
	{


		((Entity)zombie).TakeDamage(theDamage, CustomDamageMaker.DamageMaker, theDamageType, reportType, fix);
	}

	public static ZombieAttrTimers GetAttrTimers(this Zombie zombie)
	{
		if (((Component)(object)zombie).GetData("CustomizeLib_AttrTimers") == null)
		{
			ZombieAttrTimers zombieAttrTimers = new ZombieAttrTimers
			{
				zombie = zombie
			};
			((Component)(object)zombie).SetData("CustomizeLib_AttrTimers", zombieAttrTimers);
			return zombieAttrTimers;
		}
		return ((Component)(object)zombie).GetData<ZombieAttrTimers>("CustomizeLib_AttrTimers");
	}

	public static ZombieAttrTimers GetAttrTimers(this Zombie zombie, out ZombieAttrTimers timers)
	{
		if (((Component)(object)zombie).GetData("CustomizeLib_AttrTimers") == null)
		{
			ZombieAttrTimers zombieAttrTimers = new ZombieAttrTimers
			{
				zombie = zombie
			};
			((Component)(object)zombie).SetData("CustomizeLib_AttrTimers", zombieAttrTimers);
			timers = zombieAttrTimers;
			return zombieAttrTimers;
		}
		timers = ((Component)(object)zombie).GetData<ZombieAttrTimers>("CustomizeLib_AttrTimers");
		return ((Component)(object)zombie).GetData<ZombieAttrTimers>("CustomizeLib_AttrTimers");
	}
}
