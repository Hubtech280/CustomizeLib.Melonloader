namespace CustomizeLib.BepInEx;

public struct BuffID
{
	public int id;

	public BuffID(int id)
	{
		this.id = 0;
		this.id = id;
	}

	public BuffID(AdvBuff id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(UltiBuff id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(TravelDebuff id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(TravelUnlocks id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public static implicit operator AdvBuff(BuffID id)
	{
		return (AdvBuff)id.id;
	}

	public static implicit operator UltiBuff(BuffID id)
	{
		return (UltiBuff)id.id;
	}

	public static implicit operator TravelDebuff(BuffID id)
	{
		return (TravelDebuff)id.id;
	}

	public static implicit operator TravelUnlocks(BuffID id)
	{
		return (TravelUnlocks)id.id;
	}

	public static implicit operator int(BuffID id)
	{
		return id.id;
	}

	public static implicit operator BuffID(AdvBuff i)
	{

		return new BuffID(i);
	}

	public static implicit operator BuffID(UltiBuff id)
	{

		return new BuffID(id);
	}

	public static implicit operator BuffID(TravelDebuff id)
	{

		return new BuffID(id);
	}

	public static implicit operator BuffID(TravelUnlocks id)
	{

		return new BuffID(id);
	}

	public static implicit operator BuffID(int id)
	{
		return new BuffID(id);
	}
}
