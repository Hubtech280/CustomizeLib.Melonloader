using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class GameExtensions
{
	public static void Explode(this BombCherry cherry)
	{
		cherry.Explode(CustomDamageMaker.DamageMaker);
	}

	public static void FindCardUIAndChangeSprite(this Transform parent)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			CardUI component = parent.GetChild(i).GetComponent<CardUI>();
			if ((Object)(object)component != null)
			{
				Mouse.Instance.ChangeCardSprite((PlantType)component.theSeedType, component);
			}
			parent.GetChild(i).FindCardUIAndChangeSprite();
		}
	}

	public static bool ObjectExist<T>(this Board board)
	{
		return ((Object)(object)board).GameObject().transform.GetComponentsInChildren<T>().Length > 0;
	}
}
