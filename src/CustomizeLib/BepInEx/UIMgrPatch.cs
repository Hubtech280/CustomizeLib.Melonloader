using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Il2CppTMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UIMgr))]
public static class UIMgrPatch
{

	private static Vector3 CalculatePosition(int col, int row)
	{
		return new Vector3(-300f + (float)(col * 150), 160f - (float)(row * 130));
	}

	[HarmonyPatch("EnterChallengeMenu")]
	[HarmonyPostfix]
	public static void PostEnterChallengeMenu()
	{
		((MonoBehaviour)(object)GameAPP.Instance).StartCoroutine(init());
		[CompilerGenerated]
		static System.Collections.IEnumerator init()
		{
			yield return null;
			Transform levels = GameAPP.canvas.GetChild(0).FindChild("Levels");
			Transform firstBtns = levels.FindChild("FirstBtns");
			if (firstBtns.FindChild("CustomLevels") == null || firstBtns.FindChild("CustomLevels").IsDestroyed())
			{
				GameObject custom = Object.Instantiate(firstBtns.GetChild(0).gameObject, firstBtns);
				custom.name = "CustomLevels";
				custom.transform.localPosition = CalculatePosition((firstBtns.childCount - 1) % 6, (firstBtns.childCount - 1) / 6);
				Transform window = custom.transform.FindChild("Window");
				((TMP_Text)window.FindChild("Name").GetComponent<TextMeshProUGUI>()).text = "二创关卡";
				Transform adv = levels.FindChild("PageAdvantureLevel");
				GameObject customLevels = Object.Instantiate(adv.gameObject, levels);
				customLevels.active = false;
				customLevels.name = "PageCustomLevel";
				Transform pages = customLevels.transform.FindChild("Pages");
				GameObject levelSample = Object.Instantiate(pages.FindChild("Page1").FindChild("Lv1").gameObject);
				System.Collections.Generic.IEnumerator<Transform> enumerator = pages.FindChild("Page1").GetComponentsInChildren<Transform>(includeInactive: true).GetEnumerator();
				try
				{
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						Transform l = enumerator.Current;
						Object.Destroy(l.gameObject);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				GameObject pageSample = Object.Instantiate(pages.FindChild("Page1").gameObject);
				Object.Destroy(pages.FindChild("Page1").gameObject);
				Object.Destroy(pages.FindChild("Page2").gameObject);
				Object.Destroy(pages.FindChild("Page3").gameObject);
				int levelIndex = 0;
				var enumerator2 = CustomCore.CustomLevels.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						CustomLevelData level = enumerator2.Current;
						if (levelIndex % 18 == 0)
						{
							Object.Instantiate(pageSample, pages).name = $"Pages{levelIndex / 18 + 1}";
						}
						int columnIndex = levelIndex % 6;
						int rowIndex = levelIndex / 6;
						_ = rowIndex / 3;
						GameObject levelBtn = Object.Instantiate(levelSample, pages.FindChild($"Pages{levelIndex / 18 + 1}"));
						levelBtn.transform.localPosition = new Vector3(-50 + 150 * columnIndex, 60 - 130 * rowIndex, 0f);
						levelBtn.transform.GetChild(0).GetComponent<Image>().sprite = level.Logo;
						levelBtn.transform.GetChild(1).GetComponent<Advanture_Btn>().levelType = (LevelType)66;
						levelBtn.transform.GetChild(1).GetComponent<Advanture_Btn>().buttonNumber = level.ID;
						((TMP_Text)levelBtn.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>()).text = level.Name.Invoke();
						levelIndex++;
					}
				}
				finally
				{
					((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
				}
				window.GetComponent<FirstBtns>().pageToOpen = customLevels;
				((UIBtn)window.GetComponent<FirstBtns>()).originPosition = custom.transform.localPosition;
				Object.Destroy(pageSample);
				Object.Destroy(levelSample);
			}
		}
	}

	[HarmonyPatch("EnterGame")]
	[HarmonyPrefix]
	public static bool PreEnterGame(ref LevelType levelType, ref int levelNumber, ref int id, ref string name)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		if ((int)levelType != 66)
		{
			return true;
		}
		CustomLevelData customLevelData = CustomCore.CustomLevels[levelNumber];
		SynergyManager.Instance.ClearAllSynergies();
		EventManager.ClearAllEvents();
		GameAPP.UIManager.PopAll();
		CamaraFollowMouse.Instance.ResetCamera();
		Time.timeScale = GameAPP.config.gameSpeed;
		GameAPP.theBoardType = levelType;
		GameAPP.theBoardLevel = levelNumber;
		RogueManager.Instance.Clear();
		if ((Object)(object)TravelMgr.Instance != null)
		{
			Object.Destroy((Object)(object)TravelMgr.Instance);
			TravelMgr._instance = null;
		}
		GameObject gameObject = (GameAPP.board = new GameObject("Board"));
		Board val = gameObject.AddComponent<Board>();
		BoardTag boardTag = customLevelData.BoardTag;
		boardTag.disableSelectCard = !customLevelData.NeedSelectCard;
		val.boardTag = boardTag;
		val.rowNum = customLevelData.RowCount;
		val.theMaxWave = customLevelData.WaveCount.Invoke();
		val.theSun = customLevelData.Sun.Invoke();
		val.config.zombieHealthMultiplier = customLevelData.ZombieHealthRate.Invoke();
		val.seedPool = customLevelData.SeedRainPlantTypes.Invoke().ToIl2CppList<PlantType>();
		customLevelData.PostBoard.Invoke(val);
		GameObject map = MapData_cs.GetMap(customLevelData.SceneType, val);
		InitZombieList.InitZombie(levelType, levelNumber, (SceneType)0, 0);
		GameAPP.Instance.PlayMusic((MusicType)1);
		GameAPP.theGameStatus = (GameStatus)2;
		customLevelData.PreInitBoard.Invoke();
		customLevelData.PostInitBoard.Invoke(((Component)(object)val).gameObject.AddComponent<InitBoard>());
		var enumerator = customLevelData.PrePlants.Invoke().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ValueTuple<int, int, PlantType> current = enumerator.Current;
				CreatePlant.Instance.SetPlant(current.Item1, current.Item2, current.Item3, (Plant)null, default(Vector2), false, true, (Plant)null);
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		for (int i = 0; i < val.rowNum; i++)
		{
			Transform transform = map.transform.FindChild($"floor{i}");
			val.plane.Add(transform);
			if (val.boardTag.isRoof)
			{
				GameObject gameObject3 = new GameObject("floor_roof");
				gameObject3.transform.SetParent(transform);
				gameObject3.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			IceRoad component = Object.Instantiate((Object)(GameObject)GamePrefabs.IceRoad, new Vector3(19.7f, 0.8f, 0f), Quaternion.identity, transform).GetComponent<IceRoad>();
			component.theRow = i;
			float roadStartX = (component.x = 19.7f);
			component.roadStartX = roadStartX;
			((Component)(object)component).transform.localPosition = new Vector3(19.7f, 0.8f, 0f);
			val.iceRoads.Add(component);
		}
		return false;
	}
}
