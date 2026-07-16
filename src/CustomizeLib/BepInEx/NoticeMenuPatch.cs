using System;
using System.Reflection;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(UIMgr), "EnterMainMenu")]
public static class NoticeMenuPatch
{
	[HarmonyPostfix]
	public static void Postfix()
	{


















		try
		{
			if (PatchMgr.Load)
			{
				return;
			}
			GameObject gameObject = new GameObject("CustomCore Behaviour");
			gameObject.AddComponent<CoreBehaviour>();
			gameObject.AddComponent<PositionRecorder>();
			gameObject.transform.SetParent(null);
			Object.DontDestroyOnLoad(gameObject);
			PropertyInfo property = typeof(TypeMgr).GetProperty("RedPlant", (BindingFlags)24);
			object value = property.GetValue((object)null);
			HashSet<PlantType> hashSet = (HashSet<PlantType>)value;
			var enumerator = CustomCore.TypeMgrExtra.LevelPlants.GetEnumerator();
			try
			{
				PlantType val = default(PlantType);
				CardLevel val2 = default(CardLevel);
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out val, out val2);
					PlantType item = val;
					CardLevel val3 = val2;
					if ((int)val3 == 5)
					{
						hashSet.Add(item);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			property.SetValue((object)null, (object)hashSet);
			PropertyInfo property2 = typeof(TypeMgr).GetProperty("UncrashablePlants", (BindingFlags)24);
			if (property2 == null)
			{
				return;
			}
			object value2 = property2.GetValue((object)null);
			if (value2 == null)
			{
				return;
			}
			HashSet<PlantType> hashSet2 = (HashSet<PlantType>)value2;
			var enumerator2 = CustomCore.TypeMgrExtra.UncrashablePlants.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					PlantType current = enumerator2.Current;
					hashSet2.Add(current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			property2.SetValue((object)null, (object)hashSet2);
			PatchMgr.Load = true;
			var enumerator3 = CorePlugin.OnGameInitAction.GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					Action current2 = enumerator3.Current;
					current2.Invoke();
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
		}
		finally
		{
			PatchMgr.Load = true;
		}
	}
}
