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
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(UltiBuff id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(TravelDebuff id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public BuffID(TravelUnlocks id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new BuffID(i);
	}

	public static implicit operator BuffID(UltiBuff id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new BuffID(id);
	}

	public static implicit operator BuffID(TravelDebuff id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new BuffID(id);
	}

	public static implicit operator BuffID(TravelUnlocks id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new BuffID(id);
	}

	public static implicit operator BuffID(int id)
	{
		return new BuffID(id);
	}
}
