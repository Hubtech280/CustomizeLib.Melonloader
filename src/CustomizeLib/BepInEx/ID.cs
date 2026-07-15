namespace CustomizeLib.BepInEx;

public struct ID
{
	public int id;

	public ID(int id)
	{
		this.id = 0;
		this.id = id;
	}

	public ID(PlantType id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public ID(ZombieType id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public ID(ParticleType id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public ID(BulletType id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public ID(CherryBombType id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected I4, but got Unknown
		this.id = 0;
		this.id = (int)id;
	}

	public static implicit operator int(ID id)
	{
		return id.id;
	}

	public static implicit operator PlantType(ID id)
	{
		return (PlantType)id.id;
	}

	public static implicit operator ZombieType(ID id)
	{
		return (ZombieType)id.id;
	}

	public static implicit operator ParticleType(ID id)
	{
		return (ParticleType)id.id;
	}

	public static implicit operator BulletType(ID id)
	{
		return (BulletType)id.id;
	}

	public static implicit operator CherryBombType(ID id)
	{
		return (CherryBombType)id.id;
	}

	public static implicit operator ID(int i)
	{
		return new ID(i);
	}

	public static implicit operator ID(PlantType id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new ID(id);
	}

	public static implicit operator ID(ZombieType id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new ID(id);
	}

	public static implicit operator ID(ParticleType id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new ID(id);
	}

	public static implicit operator ID(BulletType id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new ID(id);
	}

	public static implicit operator ID(CherryBombType id)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new ID(id);
	}

	public string ToString()
	{
		return id.ToString();
	}
}
