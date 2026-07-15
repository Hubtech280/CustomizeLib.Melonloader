using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class InterfaceExtensions
{
	public static bool IsPlant(this IDamageable damageable, out Plant plant)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Plant>() != null)
		{
			plant = ((Il2CppObjectBase)(object)damageable).TryCast<Plant>();
			return true;
		}
		plant = null;
		return false;
	}

	public static bool IsPlant(this IDamageMaker damageable, out Plant plant)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Plant>() != null)
		{
			plant = ((Il2CppObjectBase)(object)damageable).TryCast<Plant>();
			return true;
		}
		plant = null;
		return false;
	}

	public static bool IsZombie(this IDamageable damageable, out Zombie zombie)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Zombie>() != null)
		{
			zombie = ((Il2CppObjectBase)(object)damageable).TryCast<Zombie>();
			return true;
		}
		zombie = null;
		return false;
	}

	public static bool IsZombie(this IDamageMaker damageable, out Zombie zombie)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Zombie>() != null)
		{
			zombie = ((Il2CppObjectBase)(object)damageable).TryCast<Zombie>();
			return true;
		}
		zombie = null;
		return false;
	}

	public static bool IsBullet(this IDamageable damageable, out Bullet bullet)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Bullet>() != null)
		{
			bullet = ((Il2CppObjectBase)(object)damageable).TryCast<Bullet>();
			return true;
		}
		bullet = null;
		return false;
	}

	public static bool IsBullet(this IDamageMaker damageable, out Bullet bullet)
	{
		if ((Object)(object)((Il2CppObjectBase)(object)damageable).TryCast<Bullet>() != null)
		{
			bullet = ((Il2CppObjectBase)(object)damageable).TryCast<Bullet>();
			return true;
		}
		bullet = null;
		return false;
	}

	public static IDamageable ToIDamageable(this Entity entity)
	{
		return ((Il2CppObjectBase)(object)entity).Cast<IDamageable>();
	}

	public static IDamageMaker ToIDamageMaker(this Entity entity)
	{
		return ((Il2CppObjectBase)(object)entity).Cast<IDamageMaker>();
	}

	public static IDamageMaker ToIDamageMaker(this Bullet entity)
	{
		return ((Il2CppObjectBase)(object)entity).Cast<IDamageMaker>();
	}

	public static void TakeDamage(this Zombie zombie, int theDamage, Entity damageFrom, DamageType theDamageType, PlantType reportType = (PlantType)(-1), bool fix = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((Entity)zombie).TakeDamage(theDamage, damageFrom.ToIDamageMaker(), theDamageType, reportType, fix);
	}

	public static void TakeDamage(this Zombie zombie, int theDamage, Bullet damageFrom, DamageType theDamageType, PlantType reportType = (PlantType)(-1), bool fix = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((Entity)zombie).TakeDamage(theDamage, damageFrom.ToIDamageMaker(), theDamageType, reportType, fix);
	}

	public static void TakeDamage(this Plant plant, int damage, Entity damageFrom, DamageType damageType = (DamageType)0, PlantType reportType = (PlantType)(-1), bool fix = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((Entity)plant).TakeDamage(damage, damageFrom.ToIDamageMaker(), damageType, reportType, fix);
	}

	public static void TakeDamage(this Plant plant, int damage, Bullet damageFrom, DamageType damageType = (DamageType)0, PlantType reportType = (PlantType)(-1), bool fix = false)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((Entity)plant).TakeDamage(damage, damageFrom.ToIDamageMaker(), damageType, reportType, fix);
	}
}
