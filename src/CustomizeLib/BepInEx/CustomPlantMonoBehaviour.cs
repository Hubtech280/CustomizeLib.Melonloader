using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public class CustomPlantMonoBehaviour : MonoBehaviour
{
	public static Dictionary<PlantType, Dictionary<int, int>> BulletTypes = new Dictionary<PlantType, Dictionary<int, int>>();

	public Plant ThisPlant => base.gameObject.GetComponent<Plant>();

	public void CustomAnimHeal(float num)
	{
		if (ThisPlant.thePlantHealth < ThisPlant.thePlantMaxHealth)
		{
			try
			{
				ThisPlant.Recover((float)(int)((float)ThisPlant.thePlantMaxHealth * num), (DamageType)0, true, false);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine((object)ex);
			}
		}
	}

	public void CustomAnimShoot()
	{














		Dictionary<int, int> val = BulletTypes[ThisPlant.thePlantType];
		List<int> val2 = Enumerable.ToList<int>((System.Collections.Generic.IEnumerable<int>)val.Keys);
		BulletType val3 = (BulletType)val2[new System.Random().Next(0, val2.Count)];
		BulletMoveWay val4 = (BulletMoveWay)val[(int)val3];
		Bullet val5 = ((Component)(object)Board.Instance).GetComponent<CreateBullet>().SetBullet(ThisPlant.shoot.position.x + 0.1f, ThisPlant.shoot.position.y, ThisPlant.thePlantRow, val3, val4, false);
		val5.Damage = ThisPlant.attackDamage;
		if ((int)val4 == 13 || (int)val4 == 17)
		{
			val5.targetPlant = ThisPlant;
			val5.targetZombie = SearchZombieInSameRow(ThisPlant);
			if ((Object)(object)val5.targetZombie != null)
			{
				Vector2 vector = new Vector2(((Component)(object)ThisPlant).transform.position.x, ((Component)(object)ThisPlant).transform.position.y);
				float num = Time.time - 0.5f;
				Vector2 vector2 = new Vector2(((Component)(object)val5.targetZombie).transform.position.x, ((Component)(object)val5.targetZombie).transform.position.y);
				float time = Time.time;
				Vector2 vector3 = vector2;
				float num2 = 1.5f;
			}
			else
			{
				val5.Die();
			}
		}
		if ((int)val4 == 14)
		{
			val5.targetZombie = SearchZombieInSameRow(ThisPlant);
			if ((Object)(object)val5.targetZombie != null)
			{
				val5.cannonPos = ((Component)(object)val5.targetZombie).transform.position;
			}
			else
			{
				val5.Die();
			}
		}
	}

	public void CustomAnimSuperShoot()
	{
	}

	public Zombie? SearchZombieInSameRow(Plant plant)
	{
		var enumerator = Board.Instance.zombieArray.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Zombie current = enumerator.Current;
			if ((Object)(object)current != null && ((Component)(object)current).gameObject.activeInHierarchy && current.theZombieRow == plant.thePlantRow && plant.vision > ((Component)(object)current).transform.position.x && ((Component)(object)current).transform.position.x > ((Component)(object)plant).transform.position.x && plant.SearchUniqueZombie(current) && !current.isMindControlled)
			{
				return current;
			}
		}
		return null;
	}
}
