using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CustomizeLib.BepInEx;

public struct CustomClickCardOnPlant
{
	public enum TriggerType
	{
		All,
		CardOnly,
		GloveOnly
	}

	[field: CompilerGenerated]
	public bool BlockFusion
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public TriggerType Trigger
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool SaveOrigin
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public CustomClickCardOnPlant()
	{
		BlockFusion = false;
		Trigger = TriggerType.All;
		SaveOrigin = false;
		BlockFusion = false;
		Trigger = TriggerType.All;
		SaveOrigin = false;
	}
}
