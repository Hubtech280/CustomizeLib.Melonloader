using UnityEngine;

namespace CustomizeLib.BepInEx;

public static class Utils
{
	public static LevelType CustomLevelType => (LevelType)66;

	public static bool InGame()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		GameStatus theGameStatus = GameAPP.theGameStatus;
		if ((int)theGameStatus <= 1)
		{
			return true;
		}
		return false;
	}

	public static bool IsCustomLevel(out CustomLevelData levelData)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
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
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
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
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		return Board.Instance.boardTag.enableAllTravelPlant || Board.Instance.boardTag.isSuperRandom || Board.Instance.boardTag.isUltimateSuperRandom || IsCheat() || Board.Instance.boardTag.isTravel;
	}
}
