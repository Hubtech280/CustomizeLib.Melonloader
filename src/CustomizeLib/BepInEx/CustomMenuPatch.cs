using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(CustomMenu))]
public static class CustomMenuPatch
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action _003C_003E9__0_0;

		internal void _003CPostAwake_003Eb__0_0()
		{
			if (GameAPP.canvas.IsObjExist() && GameAPP.canvas.GetChild(0).FindChild("Levels").IsObjExist())
			{
				Transform transform = GameAPP.canvas.GetChild(0).FindChild("Levels").FindChild("FirstBtns")
					.FindChild("CustomLevels");
				if (transform.IsObjExist())
				{
					transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
				}
			}
		}
	}

	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	public static void PostAwake(CustomMenu __instance)
	{



		if (!GameAPP.canvas.IsObjExist() || GameAPP.canvas.childCount <= 0 || !(GameAPP.canvas.GetChild(0).name == "ChallengeMenu(Clone)") || !GameAPP.canvas.GetChild(0).FindChild("Levels").IsObjExist())
		{
			return;
		}
		Transform transform = GameAPP.canvas.GetChild(0).FindChild("Levels").FindChild("FirstBtns")
			.FindChild("CustomLevels");
		if (transform.IsObjExist())
		{
			transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
		}
		object obj = _003C_003Ec._003C_003E9__0_0;
		if (obj == null)
		{
			Action val = delegate
			{
				if (GameAPP.canvas.IsObjExist() && GameAPP.canvas.GetChild(0).FindChild("Levels").IsObjExist())
				{
					Transform transform2 = GameAPP.canvas.GetChild(0).FindChild("Levels").FindChild("FirstBtns")
						.FindChild("CustomLevels");
					if (transform2.IsObjExist())
					{
						transform2.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
					}
				}
			};
			_003C_003Ec._003C_003E9__0_0 = val;
			obj = (object)val;
		}
		Action val2 = (Action)obj;
		((Component)(object)__instance).transform.FindChild("LowerButtons/Exit").GetComponent<UIButton>().clickEvent.AddListener(val2);
	}
}
