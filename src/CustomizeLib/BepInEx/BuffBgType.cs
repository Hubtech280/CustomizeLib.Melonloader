namespace CustomizeLib.BepInEx;

public struct BuffBgType
{
	public int BgType;

	public static BuffBgType Day;

	public static BuffBgType Night;

	public static BuffBgType Pool;

	public BuffBgType()
	{
		BgType = 0;
		BgType = 0;
	}

	public BuffBgType(int bgType)
	{
		BgType = 0;
		BgType = bgType;
	}

	public BuffBgType(TravelBuffOptionButton.BgType bgType)
	{


		BgType = 0;
		BgType = (int)bgType;
	}

	public BuffBgType(TravelStoreWindow.BgType bgType)
	{


		BgType = 0;
		BgType = (int)bgType;
	}

	public static implicit operator int(BuffBgType bgType)
	{
		return bgType.BgType;
	}

	public static implicit operator TravelBuffOptionButton.BgType(BuffBgType bgType)
	{
		return (TravelBuffOptionButton.BgType)bgType.BgType;
	}

	public static implicit operator TravelStoreWindow.BgType(BuffBgType bgType)
	{
		return (TravelStoreWindow.BgType)bgType.BgType;
	}

	public static implicit operator BuffBgType(int bgType)
	{
		return new BuffBgType(bgType);
	}

	public static implicit operator BuffBgType(TravelBuffOptionButton.BgType bgType)
	{

		return new BuffBgType(bgType);
	}

	public static implicit operator BuffBgType(TravelStoreWindow.BgType bgType)
	{

		return new BuffBgType(bgType);
	}

	static BuffBgType()
	{
		Day = new BuffBgType(0);
		Night = new BuffBgType(1);
		Pool = new BuffBgType(2);
	}
}
