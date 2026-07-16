using System;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

public static class PlantExtensions
{
	public static void TakeDamage(this Zombie zombie, DmgType theDamageType, int theDamage, PlantType reportType = (PlantType)(-1), bool fix = false)
	{

		((Entity)zombie).TakeDamage(theDamage, CustomDamageMaker.DamageMaker, (DamageType)theDamageType, reportType, fix);
	}

	public static void TakeDamage(this Plant plant, int damage, int damageType = 0)
	{
		((Entity)plant).TakeDamage(damage, CustomDamageMaker.DamageMaker, (DamageType)damageType, (PlantType)(-1), false);
	}

	public static void DisableDisMix(this Plant plant)
	{
		plant.firstParent = (PlantType)(-1);
		plant.secondParent = (PlantType)(-1);
	}

	public static void FindShoot(this Plant plant, Transform parent)
	{
		string text = parent.name.ToLower();
		if (text == "shoot" || text == "shoot1")
		{
			plant.shoot = parent;
		}
		if (text == "shoot2")
		{
			plant.shoot2 = parent;
		}
		for (int i = 0; i < parent.childCount; i++)
		{
			plant.FindShoot(parent.GetChild(i));
		}
	}

	public static int GetTotalHealth(this Zombie zombie)
	{
		return zombie.theHealth + zombie.theFirstArmorHealth + zombie.theSecondArmorHealth;
	}

	public static TextMeshProUGUI RegisterText(this Plant plant, Color color, System.Func<string> func, Vector2? size = null)
	{
		if (func == null)
		{
			return null;
		}
		if ((UnityEngine.Object)(object)plant == null || (UnityEngine.Object)(object)plant.healthSlider == null)
		{
			return null;
		}
		CustomHealthText customHealthText = plant.healthSlider.healthTextContainer.gameObject.AddComponent<CustomHealthText>();
		TextMeshProUGUI component = ((Component)(object)UnityEngine.Object.Instantiate<TextMeshProUGUI>(plant.healthSlider.healthText, (Transform)plant.healthSlider.healthTextContainer)).GetComponent<TextMeshProUGUI>();
		((Graphic)(object)component).color = color;
		((Component)(object)component).gameObject.SetActive(value: true);
		((TMP_Text)component).text = func.Invoke();
		customHealthText.registedTexts.Add(component, func);
		if (size.HasValue)
		{
			((Component)(object)component).GetComponent<RectTransform>().sizeDelta = size.Value;
		}
		return component;
	}

	public static void ClearAllText(this Plant plant)
	{
		if (!((UnityEngine.Object)(object)plant.healthSlider == null))
		{
			var enumerator = plant.healthSlider.registedTexts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				UnityEngine.Object.Destroy(((Component)(object)current.Key).gameObject);
			}
			plant.healthSlider.registedTexts.Clear();
		}
	}
}
