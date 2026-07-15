using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;

namespace CustomizeLib.BepInEx;

[HarmonyPatch(typeof(GameAPP))]
public static class GameAPPPatch
{
	[HarmonyPatch("Awake")]
	[HarmonyPostfix]
	public static void PostAwake()
	{
		InterfaceCreator.InitInstance();
	}

	[HarmonyPatch("Start")]
	[HarmonyPostfix]
	public static void PostStart(GameAPP __instance)
	{
		((MonoBehaviour)(object)__instance).StartCoroutine(CoreTools.Init());
	}

	[HarmonyPatch("LoadResources")]
	[HarmonyPrefix]
	public static void Prefix()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected I4, but got Unknown
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (CustomCore.CustomParticles.Count > 0 && (int)Enumerable.Max<ParticleType>(Enumerable.DefaultIfEmpty<ParticleType>((System.Collections.Generic.IEnumerable<ParticleType>)CustomCore.CustomParticles.Keys)) + 1 >= GameAPP.particlePrefab.Length)
			{
				long num = (long)Enumerable.Max<ParticleType>(Enumerable.DefaultIfEmpty<ParticleType>((System.Collections.Generic.IEnumerable<ParticleType>)CustomCore.CustomParticles.Keys));
				Il2CppReferenceArray<GameObject> particlePrefab = new Il2CppReferenceArray<GameObject>(num + 1);
				GameAPP.particlePrefab = particlePrefab;
			}
			if (CustomCore.CustomSprites.Count > 0 && Enumerable.Max(Enumerable.DefaultIfEmpty<int>((System.Collections.Generic.IEnumerable<int>)CustomCore.CustomSprites.Keys)) + 1 >= GameAPP.spritePrefab.Length)
			{
				long num2 = Enumerable.Max((System.Collections.Generic.IEnumerable<int>)CustomCore.CustomSprites.Keys);
				Il2CppReferenceArray<Sprite> spritePrefab = new Il2CppReferenceArray<Sprite>(num2 + 1);
				GameAPP.spritePrefab = spritePrefab;
			}
		}
		catch (InvalidOperationException)
		{
		}
		var enumerator = CustomCore.CustomPlants.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<PlantType, CustomPlantData> current = enumerator.Current;
				GameAPP.resourcesManager.plantPrefabs[current.Key] = current.Value.Prefab;
				GameAPP.resourcesManager.plantPrefabs[current.Key].tag = "Plant";
				if (!GameAPP.resourcesManager.allPlants.Contains(current.Key))
				{
					GameAPP.resourcesManager.allPlants.Add(current.Key);
				}
				if (current.Value.PlantData != null)
				{
					PlantDataManager.PlantData_Default.Add(current.Key, current.Value.PlantData);
				}
				GameAPP.resourcesManager.plantPreviews[current.Key] = current.Value.Preview;
				GameAPP.resourcesManager.plantPreviews[current.Key].tag = "Preview";
			}
		}
		finally
		{
			((System.IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator2 = CustomCore.CustomFusions.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				ValueTuple<int, int, int> current2 = enumerator2.Current;
				MixData.AddOrderedRecipe((PlantType)current2.Item2, (PlantType)current2.Item3, (PlantType)current2.Item1);
			}
		}
		finally
		{
			((System.IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator3 = CustomCore.CustomZombies.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				KeyValuePair<ZombieType, ValueTuple<GameObject, Sprite, ZombieData>> current3 = enumerator3.Current;
				if (!GameAPP.resourcesManager.allZombieTypes.Contains(current3.Key))
				{
					GameAPP.resourcesManager.allZombieTypes.Add(current3.Key);
				}
				GameAPP.resourcesManager.zombiePrefabs[current3.Key] = current3.Value.Item1;
				GameAPP.resourcesManager.zombiePrefabs[current3.Key].layer = LayerMask.NameToLayer("Zombie");
				GameAPP.resourcesManager.zombiePrefabs[current3.Key].tag = "Zombie";
				InitZombieList.allowAllzombies.Add(current3.Key);
				if (current3.Value.Item2 != null)
				{
					GameAPP.resourcesManager.zombieSprites[current3.Key] = current3.Value.Item2;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator4 = CustomCore.CustomBullets.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				KeyValuePair<BulletType, GameObject> current4 = enumerator4.Current;
				GameAPP.resourcesManager.bulletPrefabs[current4.Key] = current4.Value;
				if (!GameAPP.resourcesManager.allBullets.Contains(current4.Key))
				{
					GameAPP.resourcesManager.allBullets.Add(current4.Key);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator4/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator5 = CustomCore.CustomSkinBullet.GetEnumerator();
		try
		{
			BulletType val = default(BulletType);
			List<ValueTuple<BulletType, GameObject>> val2 = default(List<ValueTuple<BulletType, GameObject>>);
			while (enumerator5.MoveNext())
			{
				enumerator5.Current.Deconstruct(out val, out val2);
				BulletType val3 = val;
				List<ValueTuple<BulletType, GameObject>> val4 = val2;
				var enumerator6 = val4.GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						ValueTuple<BulletType, GameObject> current5 = enumerator6.Current;
						BulletType item = current5.Item1;
						GameObject item2 = current5.Item2;
						if (item2 == null)
						{
							continue;
						}
						System.Collections.Generic.IEnumerator<Component> enumerator7 = GameAPP.resourcesManager.bulletPrefabs[val3].GetComponents<Component>().GetEnumerator();
						try
						{
							while (((System.Collections.IEnumerator)enumerator7).MoveNext())
							{
								Component current6 = enumerator7.Current;
								if (item2 != null && !item2.TryGetComponent(current6.GetIl2CppType(), out var component) && component == null)
								{
									item2.AddComponent(current6.GetIl2CppType());
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator7)?.Dispose();
						}
						item2.GetComponent<Bullet>().theBulletType = val3;
						GameAPP.resourcesManager.bulletPrefabs[item] = item2;
						if (!GameAPP.resourcesManager.allBullets.Contains(item))
						{
							GameAPP.resourcesManager.allBullets.Add(item);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator6/*cast due to constrained. prefix*/).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator5/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator8 = CustomCore.CustomParticles.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				KeyValuePair<ParticleType, GameObject> current7 = enumerator8.Current;
				GameAPP.particlePrefab[(int)current7.Key] = current7.Value;
				GameAPP.resourcesManager.particlePrefabs[current7.Key] = current7.Value;
				if (!GameAPP.resourcesManager.allParticles.Contains(current7.Key))
				{
					GameAPP.resourcesManager.allParticles.Add(current7.Key);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator8/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator9 = CustomCore.CustomSprites.GetEnumerator();
		try
		{
			while (enumerator9.MoveNext())
			{
				KeyValuePair<int, Sprite> current8 = enumerator9.Current;
				GameAPP.spritePrefab[current8.Key] = current8.Value;
			}
		}
		finally
		{
			((System.IDisposable)enumerator9/*cast due to constrained. prefix*/).Dispose();
		}
		var enumerator10 = CustomCore.CustomSounds.GetEnumerator();
		try
		{
			while (enumerator10.MoveNext())
			{
				KeyValuePair<int, AudioClip> current9 = enumerator10.Current;
				GameAPP.soundManager.sounds[(SoundType)current9.Key] = current9.Value;
			}
		}
		finally
		{
			((System.IDisposable)enumerator10/*cast due to constrained. prefix*/).Dispose();
		}
		((MonoBehaviour)(object)GameAPP.Instance).StartCoroutine(PatchMgr.RegisterSkin());
	}
}
