namespace CustomizeLib.BepInEx;

public class ZombieAttrTimers
{
	public Zombie zombie;

	public float butterTimer
	{
		get
		{
			ButterEffect val = default(ButterEffect);
			return ((Entity)zombie).TryGetEffect<ButterEffect>((EffectType)6, out val) ? val.duration : (-1f);
		}
		set
		{
			ButterEffect val = default(ButterEffect);
			if (((Entity)zombie).TryGetEffect<ButterEffect>((EffectType)6, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isButter => butterTimer > 0f;

	public float coldTimer
	{
		get
		{
			ColdEffect val = default(ColdEffect);
			return ((Entity)zombie).TryGetEffect<ColdEffect>((EffectType)0, out val) ? val.duration : (-1f);
		}
		set
		{
			ColdEffect val = default(ColdEffect);
			if (((Entity)zombie).TryGetEffect<ColdEffect>((EffectType)0, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isCold => coldTimer > 0f;

	public float freezeTimer
	{
		get
		{
			FreezeEffect val = default(FreezeEffect);
			return ((Entity)zombie).TryGetEffect<FreezeEffect>((EffectType)2, out val) ? val.duration : (-1f);
		}
		set
		{
			FreezeEffect val = default(FreezeEffect);
			if (((Entity)zombie).TryGetEffect<FreezeEffect>((EffectType)2, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isFreeze => freezeTimer > 0f;

	public float immuneTimer
	{
		get
		{
			ImmuneEffect val = default(ImmuneEffect);
			return ((Entity)zombie).TryGetEffect<ImmuneEffect>((EffectType)8, out val) ? val.duration : (-1f);
		}
		set
		{
			ImmuneEffect val = default(ImmuneEffect);
			if (((Entity)zombie).TryGetEffect<ImmuneEffect>((EffectType)8, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isImmune => immuneTimer > 0f;

	public float kelpTimer
	{
		get
		{
			KelpEffect val = default(KelpEffect);
			return ((Entity)zombie).TryGetEffect<KelpEffect>((EffectType)7, out val) ? val.duration : (-1f);
		}
		set
		{
			KelpEffect val = default(KelpEffect);
			if (((Entity)zombie).TryGetEffect<KelpEffect>((EffectType)7, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isKelp => kelpTimer > 0f;

	public float poisonTimer
	{
		get
		{
			PoisonEffect val = default(PoisonEffect);
			return ((Entity)zombie).TryGetEffect<PoisonEffect>((EffectType)4, out val) ? val.duration : (-1f);
		}
		set
		{
			PoisonEffect val = default(PoisonEffect);
			if (((Entity)zombie).TryGetEffect<PoisonEffect>((EffectType)4, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isPoison => poisonTimer > 0f;

	public float portaledTimer
	{
		get
		{
			PortalEffect val = default(PortalEffect);
			return ((Entity)zombie).TryGetEffect<PortalEffect>((EffectType)5, out val) ? val.duration : (-1f);
		}
		set
		{
			PortalEffect val = default(PortalEffect);
			if (((Entity)zombie).TryGetEffect<PortalEffect>((EffectType)5, out val))
			{
				val.duration = value;
			}
		}
	}

	public bool isPortaled => portaledTimer > 0f;

	public bool isJalaed
	{
		get
		{
			JalaEffect val = default(JalaEffect);
			return ((Entity)zombie).TryGetEffect<JalaEffect>((EffectType)1, out val);
		}
	}

	public bool isEmbered
	{
		get
		{
			EmberEffect val = default(EmberEffect);
			return ((Entity)zombie).TryGetEffect<EmberEffect>((EffectType)3, out val);
		}
	}
}
