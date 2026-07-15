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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
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
				((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
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
				((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
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
				((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
			}
		}
		finally
		{
			PatchMgr.Load = true;
		}
	}
}
