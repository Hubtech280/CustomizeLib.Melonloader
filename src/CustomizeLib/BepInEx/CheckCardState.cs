using System.Collections.Generic;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public class CheckCardState : MonoBehaviour
{
	public GameObject? card = null;

	public PlantType cardType = (PlantType)(-1);

	public CardUI? movingCardUI = null;

	public bool isNormalCard = false;

	public void Start()
	{
		CustomCore.checkBehaviours.Add(this);
	}

	public void CheckState()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		List<PlantType> val = new List<PlantType>();
		Dictionary<PlantType, List<bool>> val2 = new Dictionary<PlantType, List<bool>>();
		GameObject gameObject = null;
		if ((Object)(object)Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			gameObject = InGameUI.Instance.SeedBank.transform.GetChild(0).gameObject;
		}
		else if ((Object)(object)Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			gameObject = ((Component)(object)InGameUI_IZ.Instance).transform.FindChild("SeedBank/SeedGroup").gameObject;
		}
		if (gameObject == null)
		{
			return;
		}
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
			if (gameObject2.transform.childCount > 0)
			{
				val.Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType);
				if (!val2.ContainsKey(gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType))
				{
					PlantType thePlantType = gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType;
					List<bool> obj = new List<bool>();
					obj.Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().isExtra);
					val2.Add(thePlantType, obj);
				}
				else
				{
					val2[gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType].Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().isExtra);
				}
			}
		}
		if (card != (Object)(object)movingCardUI && card.transform.childCount >= 2 && movingCardUI.thePlantType == cardType && !isNormalCard)
		{
			if (val.Contains(cardType))
			{
				card.transform.GetChild(1).gameObject.SetActive(value: false);
			}
			else
			{
				card.transform.GetChild(1).gameObject.SetActive(value: true);
			}
		}
		if (card != (Object)(object)movingCardUI && card.transform.childCount >= 3 && movingCardUI.thePlantType == cardType && isNormalCard)
		{
			if (val2.ContainsKey(cardType) && val2[cardType].Contains(true))
			{
				card.transform.GetChild(1).gameObject.SetActive(value: false);
			}
			else
			{
				card.transform.GetChild(1).gameObject.SetActive(value: true);
			}
			if (val2.ContainsKey(cardType) && val2[cardType].Contains(false))
			{
				card.transform.GetChild(2).gameObject.SetActive(value: false);
			}
			else
			{
				card.transform.GetChild(2).gameObject.SetActive(value: true);
			}
		}
	}
}
