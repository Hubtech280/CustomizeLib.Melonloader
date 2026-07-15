using System;
using System.Collections.Generic;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;

namespace CustomizeLib.BepInEx;

public class CorePlugin : BasePlugin
{
	public static List<Action> OnGameInitAction = new List<Action>();

	public ManualLogSource Logger;

	public override void Load()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		Logger = ((BasePlugin)this).Log;
		Tools.InitMod(((object)this).GetType().Assembly);
		OnStart();
		OnGameInitAction.Add(new Action(OnGameInit));
	}

	public virtual void OnStart()
	{
	}

	public virtual void OnGameInit()
	{
	}
}
