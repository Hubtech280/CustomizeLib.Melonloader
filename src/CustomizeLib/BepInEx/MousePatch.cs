using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Unity.VisualScripting;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Mouse))]
public static class MousePatch
{
	[HarmonyPostfix]
	[HarmonyPatch("GetPlantsOnMouse")]
	public static void PostGetPlantsOnMouse(ref Il2CppSystem.Collections.Generic.List<Plant> __result)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		for (int num = __result.Count - 1; num >= 0; num--)
		{
			if ((Object)(object)__result.ToArray()[num] != null && TypeMgr.BigNut(__result.ToArray()[num].thePlantType))
			{
				__result.RemoveAt(num);
			}
		}
	}

	[HarmonyPatch("Update")]
	[HarmonyPrefix]
	public static bool PreMouseClick(Mouse __instance)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		if (!Input.GetMouseButtonDown(0))
		{
			return true;
		}
		if (__instance.theItemOnMouse == null)
		{
			return true;
		}
		List<Plant> val = new List<Plant>();
		Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 origin = new Vector2(vector.x, vector.y);
		System.Collections.Generic.IEnumerator<RaycastHit2D> enumerator = Physics2D.RaycastAll(origin, Vector2.zero).GetEnumerator();
		try
		{
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				RaycastHit2D current = enumerator.Current;
				if (!(current.collider == null) && !(current.collider.gameObject == null) && !current.collider.gameObject.IsDestroyed() && current.collider.gameObject.TryGetComponent<Plant>(out var component) && !((Object)(object)component == null))
				{
					val.Add(component);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (val.Count <= 0)
		{
			return true;
		}
		bool flag = false;
		bool flag2 = false;
		List<Action<Plant>> val2 = new List<Action<Plant>>();
		var enumerator2 = val.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				Plant current2 = enumerator2.Current;
				if ((Object)(object)current2 == null || ((Object)(object)__instance.thePlantOnGlove != null && (Object)(object)current2 == (Object)(object)__instance.thePlantOnGlove) || !CustomCore.CustomClickCardOnPlantEvents.ContainsKey(new ValueTuple<PlantType, PlantType>(current2.thePlantType, __instance.thePlantTypeOnMouse)))
				{
					continue;
				}
				bool flag3 = false;
				bool flag4 = false;
				var enumerator3 = CustomCore.CustomClickCardOnPlantEvents[new ValueTuple<PlantType, PlantType>(current2.thePlantType, __instance.thePlantTypeOnMouse)].GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						ValueTuple<Action<Plant>, Func<Plant, bool>, CustomClickCardOnPlant> current3 = enumerator3.Current;
						Action<Plant> item = current3.Item1;
						Func<Plant, bool> item2 = current3.Item2;
						CustomClickCardOnPlant item3 = current3.Item3;
						if (!val2.Contains(item) && (item2 == null || item2.Invoke(current2)) && (item3.Trigger != CustomClickCardOnPlant.TriggerType.CardOnly || !((Object)(object)__instance.thePlantOnGlove != null)) && (item3.Trigger != CustomClickCardOnPlant.TriggerType.GloveOnly || !((Object)(object)__instance.thePlantOnGlove == null)))
						{
							item.Invoke(current2);
							val2.Add(item);
							if (item3.BlockFusion)
							{
								flag3 = true;
							}
							if (!item3.SaveOrigin)
							{
								flag4 = true;
							}
							flag = true;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
				}
				if (flag3)
				{
					return false;
				}
				if (flag4)
				{
					flag2 = true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
		if (flag && flag2)
		{
			if ((Object)(object)__instance.theCardOnMouse != null)
			{
				if (((Component)(object)__instance.theCardOnMouse).TryGetComponent(out DroppedCard component2) && (Object)(object)component2 != null)
				{
					DroppedCard obj = component2;
					int usedTimes = ((CardUI)obj).usedTimes;
					((CardUI)obj).usedTimes = usedTimes + 1;
					if ((Object)(object)Board.Instance != null)
					{
						Board.Instance.UseSun((float)((CardUI)component2).theSeedCost);
						if (Lawnf.TravelAdvanced((AdvBuff)5004))
						{
							Board.Instance.UseSun((float)(Board.Instance.theSun / 2));
						}
					}
				}
				else
				{
					__instance.theCardOnMouse.CD = 0f;
					__instance.theCardOnMouse.isPickUp = false;
					if ((Object)(object)Board.Instance != null)
					{
						Board.Instance.UseSun((float)__instance.theCardOnMouse.theSeedCost);
						if (Lawnf.TravelAdvanced((AdvBuff)5004))
						{
							Board.Instance.UseSun((float)(Board.Instance.theSun / 2));
						}
					}
				}
			}
			if ((Object)(object)__instance.thePlantOnGlove != null)
			{
				__instance.thePlantOnGlove.Die((DieReason)7);
				Glove instance = Glove.Instance;
				if ((Object)(object)instance != null)
				{
					float gloveCD = Lawnf.GetGloveCD();
					((InGameTool)instance).fullCD = gloveCD;
					((InGameTool)instance).CD = 0f;
					if (TypeMgr.IsPuff(__instance.thePlantTypeOnMouse) || TypeMgr.IsPot(__instance.thePlantTypeOnMouse) || TypeMgr.IsLily(__instance.thePlantTypeOnMouse) || TypeMgr.FlyingPlants(__instance.thePlantTypeOnMouse))
					{
						((InGameTool)instance).CD = (((InGameTool)instance).fullCD + ((InGameTool)instance).fullCD) / 3f;
					}
				}
			}
			Object.Destroy(__instance.theItemOnMouse);
			__instance.ClearItemOnMouse(false);
		}
		if (!flag2)
		{
			return true;
		}
		return !flag;
	}

	[HarmonyPostfix]
	[HarmonyPatch("LeftClickWithNothing")]
	public static void PostLeftClickWithNothing()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = Enumerable.ToList<GameObject>(Enumerable.Select<RaycastHit2D, GameObject>(Enumerable.Cast<RaycastHit2D>((System.Collections.IEnumerable)(object)(RaycastHit2D[]?)Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero)), (Func<RaycastHit2D, GameObject>)delegate(RaycastHit2D raycastHit2D)
		{
			RaycastHit2D raycastHit2D2 = raycastHit2D;
			return raycastHit2D2.collider.gameObject;
		})).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				if (current.TryGetComponent<Plant>(out var component) && CustomCore.CustomPlantClicks.ContainsKey(component.thePlantType))
				{
					CustomCore.CustomPlantClicks[component.thePlantType].Invoke(component);
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
	}
}
