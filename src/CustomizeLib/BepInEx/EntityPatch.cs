using Il2CppCore;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(Entity))]
public static class EntityPatch
{
	[HarmonyPatch("GetSpriteRenderers")]
	[HarmonyPrefix]
	public static bool PreGetSpriteRenderers(Entity __instance)
	{
		if (((Component)(object)__instance).TryGetComponent(out SaveMaterial _))
		{
			var enumerator = Il2CppCore.Lawnf.GetChilds(((Component)(object)__instance).transform).GetEnumerator();
			while (enumerator.MoveNext())
			{
				GameObject current = enumerator.Current;
				if (current.TryGetComponent<SpriteRenderer>(out var component2) && current.name != "Shadow")
				{
					__instance.spriteRenderers.Add(component2);
				}
			}
			return false;
		}
		return true;
	}
}
