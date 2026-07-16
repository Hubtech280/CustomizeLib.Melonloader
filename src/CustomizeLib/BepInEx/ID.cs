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


		this.id = 0;
		this.id = (int)id;
	}

	public ID(ZombieType id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public ID(ParticleType id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public ID(BulletType id)
	{


		this.id = 0;
		this.id = (int)id;
	}

	public ID(CherryBombType id)
	{


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

		return new ID(id);
	}

	public static implicit operator ID(ZombieType id)
	{

		return new ID(id);
	}

	public static implicit operator ID(ParticleType id)
	{

		return new ID(id);
	}

	public static implicit operator ID(BulletType id)
	{

		return new ID(id);
	}

	public static implicit operator ID(CherryBombType id)
	{

		return new ID(id);
	}

	public override string ToString()
	{
		return id.ToString();
	}
}
