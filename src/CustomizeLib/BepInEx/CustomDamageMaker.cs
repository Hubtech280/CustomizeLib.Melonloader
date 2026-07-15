using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CustomizeLib.BepInEx;

public class CustomDamageMaker : IDamageMaker
{
	private static Dictionary<Team, InterfaceBehaviour> DamageMakerObjs = new Dictionary<Team, InterfaceBehaviour>();

	public static IDamageMaker DamageMaker => GetDamageMaker();

	[field: CompilerGenerated]
	public Team Team
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public CustomDamageMaker(System.IntPtr ptr)
		: base(ptr)
	{
	}

	public override bool CanAttack(IDamageable target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return target != null && target.Team != Team;
	}

	public static IDamageMaker GetDamageMaker()
	{
		return (IDamageMaker)(object)InterfaceCreator.GetInterfaceInstance<CustomDamageMaker>();
	}
}
