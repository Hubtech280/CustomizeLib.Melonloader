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
	public override Team Team
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


		return target != null && target.Team != Team;
	}

	public static IDamageMaker GetDamageMaker()
	{
		return (IDamageMaker)(object)InterfaceCreator.GetInterfaceInstance<CustomDamageMaker>();
	}
}
