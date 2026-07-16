using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class Utils
{
	public static LevelType CustomLevelType => (LevelType)66;

	public static bool InGame()
	{




		GameStatus theGameStatus = GameAPP.theGameStatus;
		if ((int)theGameStatus <= 1)
		{
			return true;
		}
		return false;
	}

	public static bool IsCustomLevel(out CustomLevelData levelData)
	{


		if (GameAPP.theBoardType == CustomLevelType)
		{
			levelData = CustomCore.CustomLevels[GameAPP.theBoardLevel];
			return true;
		}
		levelData = default(CustomLevelData);
		return false;
	}

	public static bool IsGameRunning()
	{


		return (int)GameAPP.theGameStatus == 0;
	}

	public static bool IsNotNull<T>(this T obj)
	{
		return obj != null;
	}

	public static int ToInt(this bool value)
	{
		return value ? 1 : 0;
	}

	public static GameObject? GetColorfulCardGameObject()
	{


		if (Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			GameObject gameObject = null;
			return InGameUI.Instance.SeedBank.transform.parent.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/ColorCards/SampleGrid(Clone)").GetChild(0).gameObject;
		}
		if (Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			GameObject gameObject2 = null;
			return IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid/ColorfulCards/Page1/CattailGirl").gameObject;
		}
		return null;
	}

	public static GameObject? GetNormalCardGameObject()
	{


		if (Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			GameObject gameObject = null;
			return InGameUI.Instance.SeedBank.transform.parent.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/NormalCards/SampleGrid(Clone)").GetChild(0).gameObject;
		}
		if (Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			GameObject gameObject2 = null;
			return IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid/Main/Page1/PeaShooter").gameObject;
		}
		return null;
	}

	public static Transform? GetColorfulCardParent()
	{


		if ((Object)(object)Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			return InGameUI.Instance.SeedBank.transform.parent.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/ColorCards/SampleGrid(Clone)");
		}
		if ((Object)(object)Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			return IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid/ColorfulCards/Page1");
		}
		return null;
	}

	public static Transform? GetNormalCardParent()
	{



		if ((Object)(object)Board.Instance != null && Board.Instance.boardTag.isTowerDefence)
		{
			return InGameUI.Instance.SeedBank.transform.parent.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/TowerCards/Page1");
		}
		if ((Object)(object)Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			return InGameUI.Instance.SeedBank.transform.parent.FindChild("Bottom/SeedLibrary/Grid/CardPagesContainer/NormalCards/SampleGrid(Clone)");
		}
		if ((Object)(object)Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			return IZBottomMenu.Instance.plantLibrary.transform.FindChild("Grid/Pages/Page1");
		}
		return null;
	}

	public static bool IsCheat()
	{
		return GameAPP.developerMode;
	}

	public static bool EnableTravelPlant()
	{




		return Board.Instance.boardTag.enableAllTravelPlant || Board.Instance.boardTag.isSuperRandom || Board.Instance.boardTag.isUltimateSuperRandom || IsCheat() || Board.Instance.boardTag.isTravel;
	}
}
