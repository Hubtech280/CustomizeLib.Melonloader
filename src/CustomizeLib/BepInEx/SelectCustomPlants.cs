using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Il2CppInterop.Runtime;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

public class SelectCustomPlants : MonoBehaviour
{
	public static SelectCustomPlants Instance;

	public static GameObject CustomButton;

	public static GameObject CustomPage;

	public bool init = false;

	public static int PageCardMax => 54;

	public static Board board => Board.Instance;

	public static List<PlantType> GetPlants()
	{
		return Enumerable.ToList<PlantType>(Enumerable.Where<PlantType>((System.Collections.Generic.IEnumerable<PlantType>)GameAPP.resourcesManager.allPlants.ToArray(), (Func<PlantType, bool>)((PlantType t) => !System.Enum.IsDefined<PlantType>(t))));
	}

	public static void InitButton()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Console.OutputEncoding = Encoding.UTF8;
		if (!((Object)(object)board == null))
		{
			GameObject gameObject = null;
			gameObject = (board.boardTag.isIZ ? Object.Instantiate(IZBottomMenu.Instance.plantLibrary.transform.FindChild("Buttons/NextPage"), IZBottomMenu.Instance.plantLibrary.transform.FindChild("Buttons")).gameObject : Object.Instantiate(((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/ShowCardLayout/ColorCards"), ((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/ShowCardLayout")).gameObject);
			gameObject.name = "SelectCustom";
			gameObject.SetActive(value: true);
			((TMP_Text)gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>()).text = "二创植物";
			Object.Destroy((Object)(object)gameObject.GetComponent<UIButton>());
			Instance = gameObject.AddComponent<SelectCustomPlants>();
			CustomButton = gameObject;
		}
	}

	public unsafe void OpenPlantsCard()
	{
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Expected I4, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected I4, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)(object)board == null)
			{
				return;
			}
			if (init && CustomPage != null)
			{
				if (!board.boardTag.isIZ)
				{
					for (int i = 0; i < ((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer").childCount; i++)
					{
						((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer").GetChild(i).gameObject.SetActive(value: false);
					}
				}
				else
				{
					for (int j = 0; j < IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid").childCount; j++)
					{
						IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid").GetChild(j).gameObject.SetActive(value: false);
					}
				}
				CustomPage.SetActive(value: true);
				return;
			}
			if (!board.boardTag.isIZ)
			{
				for (int k = 0; k < ((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer").childCount; k++)
				{
					((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer").GetChild(k).gameObject.SetActive(value: false);
				}
				GameObject gameObject = (CustomPage = Object.Instantiate(((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/ColorCards"), ((Component)(object)InGameUI.Instance).transform.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer")).gameObject);
				gameObject.name = "CustomCards";
				gameObject.SetActive(value: true);
				List<PlantType> plants = GetPlants();
				int count = plants.Count;
				int num = count / PageCardMax + ((count % PageCardMax > 0) ? 1 : 0);
				for (int num2 = gameObject.transform.childCount - 1; num2 >= 1; num2--)
				{
					Object.Destroy(gameObject.transform.GetChild(num2).gameObject);
				}
				for (int num3 = gameObject.transform.GetChild(0).childCount - 1; num3 >= 1; num3--)
				{
					Object.Destroy(gameObject.transform.GetChild(0).GetChild(num3).gameObject);
				}
				GameObject gameObject2 = gameObject.transform.GetChild(0).GetChild(0).gameObject;
				int num4 = count;
				gameObject.transform.GetChild(0).gameObject.name = "SampleGrid_1";
				for (int l = 1; l < num; l++)
				{
					GameObject gameObject3 = Object.Instantiate(gameObject.transform.GetChild(0).gameObject, gameObject.transform);
					gameObject3.name = $"SampleGrid_{l + 1}";
				}
				int num5 = 0;
				for (int m = 0; m < num; m++)
				{
					Transform child = gameObject.transform.GetChild(m);
					for (int n = 0; n < PageCardMax; n++)
					{
						PlantType val = plants[num5];
						GameObject gameObject4 = Object.Instantiate(gameObject2, child);
						CardUI component = gameObject4.transform.GetChild(1).GetComponent<CardUI>();
						Transform child2 = gameObject4.transform.GetChild(0);
						child2.localPosition = ((Component)(object)component).transform.localPosition;
						child2.localRotation = ((Component)(object)component).transform.localRotation;
						child2.localScale = ((Component)(object)component).transform.localScale;
						gameObject4.SetActive(value: true);
						Mouse.Instance.ChangeCardSprite(val, component);
						Image component2 = ((Component)(object)component).transform.GetChild(0).GetComponent<Image>();
						component2.sprite = GameAPP.resourcesManager.plantPreviews[val].GetComponent<SpriteRenderer>().sprite;
						child2.GetChild(0).GetComponent<Image>().sprite = component2.sprite;
						child2.GetChild(0).GetComponent<RectTransform>().sizeDelta = ((Component)(object)component).transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
						((TMP_Text)((Component)(object)component).transform.GetChild(1).GetComponent<TextMeshProUGUI>()).text = PlantDataManager.PlantData_Default[val].cost.ToString();
						((TMP_Text)child2.GetChild(1).GetComponent<TextMeshProUGUI>()).text = PlantDataManager.PlantData_Default[val].cost.ToString();
						gameObject4.gameObject.SetActive(value: true);
						((Component)(object)component).GetComponent<BoxCollider2D>().enabled = true;
						component.thePlantType = val;
						component.theSeedType = (int)val;
						component.theSeedCost = PlantDataManager.PlantData_Default[val].cost;
						component.fullCD = PlantDataManager.PlantData_Default[val].cd;
						gameObject4.name = ((object)(*(PlantType*)(&val))/*cast due to constrained. prefix*/).ToString();
						num5++;
						num4--;
						if (num4 == 0)
						{
							break;
						}
					}
				}
				Object.Destroy(gameObject2);
			}
			else
			{
				for (int num6 = 0; num6 < IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid").childCount; num6++)
				{
					IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid").GetChild(num6).gameObject.SetActive(value: false);
				}
				GameObject gameObject5 = (CustomPage = Object.Instantiate(IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid/全部植物"), IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid")).gameObject);
				gameObject5.name = "二创植物";
				gameObject5.SetActive(value: true);
				List<PlantType> plants2 = GetPlants();
				int count2 = plants2.Count;
				int num7 = count2 / PageCardMax + ((count2 % PageCardMax > 0) ? 1 : 0);
				for (int num8 = gameObject5.transform.childCount - 1; num8 >= 1; num8--)
				{
					Object.Destroy(gameObject5.transform.GetChild(num8).gameObject);
				}
				for (int num9 = gameObject5.transform.GetChild(0).childCount - 1; num9 >= 1; num9--)
				{
					Object.Destroy(gameObject5.transform.GetChild(0).GetChild(num9).gameObject);
				}
				GameObject gameObject6 = gameObject5.transform.GetChild(0).GetChild(0).gameObject;
				int num10 = count2;
				gameObject5.transform.GetChild(0).gameObject.name = "PlantCardPage_1";
				for (int num11 = 1; num11 < num7; num11++)
				{
					GameObject gameObject7 = Object.Instantiate(gameObject5.transform.GetChild(0).gameObject, gameObject5.transform);
					gameObject7.name = $"PlantCardPage_{num11 + 1}";
				}
				int num12 = 0;
				for (int num13 = 0; num13 < num7; num13++)
				{
					Transform child3 = gameObject5.transform.GetChild(num13);
					for (int num14 = 0; num14 < PageCardMax; num14++)
					{
						PlantType val2 = plants2[num12];
						GameObject gameObject8 = Object.Instantiate(gameObject6, child3);
						CardUI component3 = gameObject8.transform.GetChild(0).GetComponent<CardUI>();
						gameObject8.SetActive(value: true);
						Image component4 = ((Component)(object)component3).transform.GetChild(0).GetComponent<Image>();
						component4.sprite = GameAPP.resourcesManager.plantPreviews[val2].GetComponent<SpriteRenderer>().sprite;
						component4.SetNativeSize();
						((TMP_Text)((Component)(object)component3).transform.GetChild(1).GetComponent<TextMeshProUGUI>()).text = PlantDataManager.PlantData_Default[val2].cost.ToString();
						((Component)(object)component3).gameObject.SetActive(value: true);
						Mouse.Instance.ChangeCardSprite(val2, component3);
						((Component)(object)component3).GetComponent<BoxCollider2D>().enabled = true;
						component3.thePlantType = val2;
						component3.theSeedType = (int)val2;
						component3.theSeedCost = 0;
						component3.fullCD = 0f;
						gameObject8.name = ((object)(*(PlantType*)(&val2))/*cast due to constrained. prefix*/).ToString();
						num12++;
						num10--;
						if (num10 == 0)
						{
							break;
						}
					}
				}
				Object.Destroy(gameObject6);
			}
			init = true;
		}
		catch (Il2CppException)
		{
		}
	}

	public void Update()
	{
		Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, Vector2.zero);
		if (Input.GetMouseButtonDown(0) && CustomButton != null && raycastHit2D.collider != null && raycastHit2D.collider.gameObject == CustomButton)
		{
			OpenPlantsCard();
		}
		if (CustomButton != null && raycastHit2D.collider != null && raycastHit2D.collider.gameObject == CustomButton)
		{
			CursorChange.SetClickCursor();
		}
	}
}
