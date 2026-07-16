using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using CustomizeLib.BepInEx.ExtensionData.Basic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizeLib.BepInEx;

public static class PatchMgr
{
	public struct CustomSkinData
	{
		[field: CompilerGenerated]
		public System.Collections.Generic.Dictionary<PlantType, int>? PlantSkinDic
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public System.Collections.Generic.Dictionary<PlantType, Il2CppSystem.Collections.Generic.List<GameObject>>? _plantPrefabs
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public System.Collections.Generic.Dictionary<PlantType, Il2CppSystem.Collections.Generic.List<GameObject>>? _plantPreviews
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public CustomSkinData()
		{
			PlantSkinDic = null;
			_plantPrefabs = null;
			_plantPreviews = null;
			PlantSkinDic = null;
			_plantPrefabs = null;
			_plantPreviews = null;
		}
	}



	public static CustomSkinData SkinData = new CustomSkinData();

	public static bool Load = false;

	public static void SaveEndlessData(int level, int id)
	{
		SaveEndlessBuffArray(level, id);
		SaveDataArray(level, id);
	}

	public static void SaveEndlessBuffArray(int level, int id)
	{
		if ((Object)(object)TravelMgr.Instance == null)
		{
			return;
		}
		int[] array = (int[])((Component)(object)TravelMgr.Instance).GetData("CustomBuffsLevel");
		if (array == null)
		{
			array = new int[CustomCore.CustomBuffsLevel.Count];
			((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", array);
		}
		else
		{
			if (Enumerable.SequenceEqual<int>((System.Collections.Generic.IEnumerable<int>)array, (System.Collections.Generic.IEnumerable<int>)new int[CustomCore.CustomBuffsLevel.Count]))
			{
				return;
			}
			string text = JsonSerializer.Serialize<int[]>(array, (JsonSerializerOptions)null);
			string path = SaveInfo.Instance.GetPath(level, id);
			string directoryName = Path.GetDirectoryName(path);
			if (directoryName != null)
			{
				string fileName = Path.GetFileName(path);
				string text2 = Path.Combine(directoryName, fileName + ".extra.json");
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				if (!File.Exists(text2))
				{
					((Stream)File.Create(text2)).Dispose();
				}
				File.WriteAllText(text2, text);
			}
		}
	}

	public static void SaveDataArray(int level, int id)
	{
	}

	public static object? GetValueByName(Component comp, string name)
	{
		if (comp == null)
		{
			return null;
		}
		PropertyInfo property = ((object)comp).GetType().GetProperty(name, (BindingFlags)60);
		if (property != (PropertyInfo)null && property.CanRead)
		{
			return (property != null) ? property.GetValue((object)comp) : null;
		}
		FieldInfo field = ((object)comp).GetType().GetField(name, (BindingFlags)60);
		if (field != (FieldInfo)null)
		{
			return field.GetValue((object)comp);
		}
		return null;
	}

	public static void SetValueByName(Component comp, string name, object? val)
	{
		if (comp == null)
		{
			return;
		}
		PropertyInfo property = ((object)comp).GetType().GetProperty(name, (BindingFlags)60);
		if (property != (PropertyInfo)null && property.CanWrite)
		{
			if (property != null)
			{
				property.SetValue((object)comp, val);
			}
			return;
		}
		FieldInfo field = ((object)comp).GetType().GetField(name, (BindingFlags)60);
		if (field != (FieldInfo)null)
		{
			field.SetValue((object)comp, val);
		}
	}

	public static void LoadEndlessData(int level, int id, int idG)
	{
		LoadEndlessBuffArray(level, idG);
	}

	public static void LoadEndlessBuffArray(int level, int id)
	{
		string path = SaveInfo.Instance.GetPath(level, id);
		string directoryName = Path.GetDirectoryName(path);
		if (directoryName != null)
		{
			string fileName = Path.GetFileName(path);
			string text = Path.Combine(directoryName, fileName + ".extra.json");
			if (!File.Exists(text))
			{
				((Stream)File.Create(text)).Dispose();
			}
			string text2 = File.ReadAllText(text);
			if (text2 == null || text2 == "")
			{
				text2 = JsonSerializer.Serialize<int[]>(new int[CustomCore.CustomAdvancedBuffs.Count], (JsonSerializerOptions)null);
			}
			int[] array = JsonSerializer.Deserialize<int[]>(text2, (JsonSerializerOptions)null);
			if (array != null)
			{
				((Component)(object)TravelMgr.Instance).SetData("CustomBuffsLevel", array);
				((Component)(object)TravelMgr.Instance).SetData("LoadByEndless", true);
				((Component)(object)SaveInfo.Instance).SetData("endlessID", null);
			}
		}
	}

	public static void OnChangeSkin(PlantType almanacType, int index)
	{

































		BulletType val2 = default(BulletType);
		List<BulletType> val3 = default(List<BulletType>);
		if (CustomCore.CustomBulletSkinReplace.ContainsKey(new ValueTuple<PlantType, int>(almanacType, index)))
		{
			Dictionary<BulletType, List<BulletType>> val = CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(almanacType, index)];
			var enumerator = val.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Deconstruct(out val2, out val3);
					BulletType val4 = val2;
					List<BulletType> val5 = val3;
					CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(almanacType, val4)] = val5;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		var enumerator2 = CustomCore.CustomBulletSkinReplace.GetEnumerator();
		try
		{
			ValueTuple<PlantType, int> val6 = default(ValueTuple<PlantType, int>);
			Dictionary<BulletType, List<BulletType>> val7 = default(Dictionary<BulletType, List<BulletType>>);
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.Deconstruct(out val6, out val7);
				ValueTuple<PlantType, int> val8 = val6;
				PlantType item = val8.Item1;
				int item2 = val8.Item2;
				Dictionary<BulletType, List<BulletType>> val9 = val7;
				var enumerator3 = val9.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						enumerator3.Current.Deconstruct(out val2, out val3);
						BulletType val10 = val2;
						if (GameAPP.resourcesManager.plantSkinDic.ContainsKey(item) && GameAPP.resourcesManager.plantSkinDic[item] != item2)
						{
							Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomCore.CustomBulletsSkinID;
							ValueTuple<PlantType, BulletType> val11 = new ValueTuple<PlantType, BulletType>(almanacType, val10);
							List<BulletType> obj = new List<BulletType>();
							obj.Add(val10);
							customBulletsSkinID[val11] = obj;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
		SetEnableSkin();
	}

	public static void UpdateSkin()
	{























		var enumerator = CustomCore.CustomBulletSkinReplace.GetEnumerator();
		try
		{
			ValueTuple<PlantType, int> val = default(ValueTuple<PlantType, int>);
			Dictionary<BulletType, List<BulletType>> val2 = default(Dictionary<BulletType, List<BulletType>>);
			BulletType val5 = default(BulletType);
			List<BulletType> val6 = default(List<BulletType>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val, out val2);
				ValueTuple<PlantType, int> val3 = val;
				PlantType item = val3.Item1;
				int item2 = val3.Item2;
				Dictionary<BulletType, List<BulletType>> val4 = val2;
				var enumerator2 = val4.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						enumerator2.Current.Deconstruct(out val5, out val6);
						BulletType val7 = val5;
						List<BulletType> val8 = val6;
						if (GameAPP.resourcesManager.plantSkinDic.ContainsKey(item))
						{
							if (GameAPP.resourcesManager.plantSkinDic[item] != item2)
							{
								Dictionary<ValueTuple<PlantType, BulletType>, List<BulletType>> customBulletsSkinID = CustomCore.CustomBulletsSkinID;
								ValueTuple<PlantType, BulletType> val9 = new ValueTuple<PlantType, BulletType>(item, val7);
								List<BulletType> obj = new List<BulletType>();
								obj.Add(val7);
								customBulletsSkinID[val9] = obj;
							}
							else
							{
								CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(item, val7)] = val8;
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		SetEnableSkin();
	}

	public static void SetEnableSkin()
	{
























		List<PlantType> val = new List<PlantType>();
		var enumerator = CustomCore.CustomPlantSkinIndex.GetEnumerator();
		PlantType val2 = default(PlantType);
		try
		{
			List<int> val3 = default(List<int>);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val2, out val3);
				PlantType val4 = val2;
				List<int> val5 = val3;
				var enumerator2 = val5.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						int current = enumerator2.Current;
						if (GameAPP.resourcesManager.plantSkinDic.ContainsKey(val4) && GameAPP.resourcesManager.plantSkinDic[val4] == current)
						{
							val.Add(val4);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		Dictionary<PlantType, bool> val6 = new Dictionary<PlantType, bool>();
		var enumerator3 = CustomCore.CustomPlantsSkin.GetEnumerator();
		try
		{
			List<CustomPlantData> val7 = default(List<CustomPlantData>);
			while (enumerator3.MoveNext())
			{
				enumerator3.Current.Deconstruct(out val2, out val7);
				PlantType val8 = val2;
				if (val.Contains(val8))
				{
					if (val6.ContainsKey(val8))
					{
						val6[val8] = true;
					}
					else
					{
						val6.Add(val8, true);
					}
				}
				else if (val6.ContainsKey(val8))
				{
					val6[val8] = false;
				}
				else
				{
					val6.Add(val8, false);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
		CustomCore.EnableSkin = val6;
	}

	public static System.Collections.Generic.Dictionary<TKey, TValue>? Clone<TKey, TValue>(this Il2CppSystem.Collections.Generic.Dictionary<TKey, TValue> dic1) where TKey : notnull
	{
		System.Collections.Generic.Dictionary<TKey, TValue> val = new System.Collections.Generic.Dictionary<TKey, TValue>();
		var enumerator = dic1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			var (val4, val5) = enumerator.Current;
			val.Add(val4, val5);
		}
		return val;
	}

	public static Il2CppSystem.Collections.Generic.Dictionary<TKey, TValue>? Clone<TKey, TValue>(this System.Collections.Generic.Dictionary<TKey, TValue> dic1) where TKey : notnull
	{




		Il2CppSystem.Collections.Generic.Dictionary<TKey, TValue> dictionary = new Il2CppSystem.Collections.Generic.Dictionary<TKey, TValue>();
		var enumerator = dic1.GetEnumerator();
		try
		{
			TKey val = default(TKey);
			TValue val2 = default(TValue);
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val, out val2);
				TKey key = val;
				TValue value = val2;
				dictionary.Add(key, value);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return dictionary;
	}

	public static void InitWithValue<T>(this List<T> list, T value)
	{
		for (int num = list.Count - 1; num >= 0; num--)
		{
			list[num] = value;
		}
	}

	public static void InitWithValue<TKey, TValue>(this Dictionary<TKey, TValue> dic, TValue value) where TKey : notnull
	{


		var enumerator = Enumerable.ToList<TKey>((System.Collections.Generic.IEnumerable<TKey>)dic.Keys).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				TKey current = enumerator.Current;
				dic[current] = value;
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public static System.Collections.IEnumerator RegisterSkin()
	{
		var enumerator = CustomCore.CustomPlantsSkin.GetEnumerator();
		int value = default(int);
		try
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<PlantType, List<CustomPlantData>> item = enumerator.Current;
				PlantType plantType = item.Key;
				if (CustomCore.CustomPlantsSkinActive[plantType])
				{
					continue;
				}
				if (!GameAPP.resourcesManager.plantSkinDic.TryGetValue(plantType, out value))
				{
					GameAPP.resourcesManager.plantSkinDic.Add(plantType, 0);
				}
				var enumerator2 = item.Value.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						CustomPlantData it = enumerator2.Current;
						GameObject prefab = it.Prefab;
						GameObject preview = it.Preview;
						if (prefab != null)
						{
							if (GameAPP.resourcesManager._plantPrefabs.ContainsKey(plantType))
							{
								GameAPP.resourcesManager._plantPrefabs[plantType].Add(prefab);
							}
							else
							{
									Il2CppSystem.Collections.Generic.List<GameObject> list = new Il2CppSystem.Collections.Generic.List<GameObject>();
								list.Add(GameAPP.resourcesManager.plantPrefabs[plantType]);
								list.Add(prefab);
								GameAPP.resourcesManager._plantPrefabs.Add(plantType, list);
							}
						}
						if (preview != null)
						{
							if (GameAPP.resourcesManager._plantPreviews.ContainsKey(plantType))
							{
								GameAPP.resourcesManager._plantPreviews[plantType].Add(preview);
							}
							else
							{
									Il2CppSystem.Collections.Generic.List<GameObject> list2 = new Il2CppSystem.Collections.Generic.List<GameObject>();
								list2.Add(GameAPP.resourcesManager.plantPreviews[plantType]);
								list2.Add(preview);
								GameAPP.resourcesManager._plantPreviews.Add(plantType, list2);
							}
						}
						int index_prefab = GameAPP.resourcesManager._plantPrefabs[plantType].IndexOf(prefab);
						int index_preview = GameAPP.resourcesManager._plantPreviews[plantType].IndexOf(preview);
						if (index_prefab == -1 || index_preview == -1 || index_prefab != index_preview)
						{
							continue;
						}
						if (CustomCore.CustomPlantSkinIndex.ContainsKey(plantType))
						{
							CustomCore.CustomPlantSkinIndex[plantType].Add(index_prefab);
						}
						else
						{
							Dictionary<PlantType, List<int>> customPlantSkinIndex = CustomCore.CustomPlantSkinIndex;
							List<int> obj = new List<int>();
							obj.Add(index_prefab);
							customPlantSkinIndex.Add(plantType, obj);
						}
						CustomCore.CustomPlantsSkinActive[plantType] = true;
						int index = GameAPP.resourcesManager._plantPrefabs[plantType].IndexOf(prefab);
						if (index == -1 || it.BulletList == null)
						{
							continue;
						}
						var enumerator3 = it.BulletList.GetEnumerator();
						try
						{
							while (enumerator3.MoveNext())
							{
								ValueTuple<BulletType, List<GameObject>> current = enumerator3.Current;
								BulletType bulletID = current.Item1;
								List<GameObject?> list3 = current.Item2;
								if ((int)bulletID == -1)
								{
									continue;
								}
								var enumerator4 = list3.GetEnumerator();
								try
								{
									while (enumerator4.MoveNext())
									{
										GameObject bullet = enumerator4.Current;
										if (!(bullet != null))
										{
											continue;
										}
										if (!CustomCore.CustomBulletSkinReplace.ContainsKey(new ValueTuple<PlantType, int>(plantType, index)))
										{
											Dictionary<ValueTuple<PlantType, int>, Dictionary<BulletType, List<BulletType>>> customBulletSkinReplace = CustomCore.CustomBulletSkinReplace;
											ValueTuple<PlantType, int> val = new ValueTuple<PlantType, int>(plantType, index);
											Dictionary<BulletType, List<BulletType>> obj2 = new Dictionary<BulletType, List<BulletType>>();
											obj2.Add(bulletID, CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(plantType, bulletID)]);
											customBulletSkinReplace.Add(val, obj2);
										}
										else if (CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType, index)].ContainsKey(bulletID))
										{
											int i = CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(plantType, bulletID)].Count - 1;
											while (i >= 0)
											{
												BulletType itb = CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(plantType, bulletID)][i];
												CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType, index)][bulletID].Add(itb);
												value = i--;
											}
										}
										else
										{
											CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType, index)].Add(bulletID, CustomCore.CustomBulletsSkinID[new ValueTuple<PlantType, BulletType>(plantType, bulletID)]);
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator4).Dispose();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator3).Dispose();
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		string fullName = global::MelonLoader.Utils.MelonEnvironment.ModsDirectory;
		if (fullName != null)
		{
			string skinPath = Path.Combine(fullName, "Skin");
			if (Directory.Exists(skinPath))
			{
				Regex regex = new Regex("^skin_(\\d+)(?!\\d).*$", (RegexOptions)1);
				string[] files = Directory.GetFiles(skinPath);
				int id = default(int);
				foreach (string path in files)
				{
					Match match = regex.Match(Path.GetFileNameWithoutExtension(path));
					if (!((Group)match).Success || !int.TryParse(((Capture)match.Groups[1]).Value, out id))
					{
						continue;
					}
					PlantType plantType2 = (PlantType)id;
					if (CustomCore.CustomPlantsSkinActive.ContainsKey(plantType2) && CustomCore.CustomPlantsSkinActive[plantType2])
					{
						continue;
					}
					AssetBundle ab = AssetBundle.LoadFromFile(path);
					SkinConfig json = new SkinConfig();
					if (ab.TryGetAsset<TextAsset>("config", out var text))
					{
						json = JsonSerializer.Deserialize<SkinConfig>(text.text, (JsonSerializerOptions)null);
					}
					CustomCore.LoadedSkinAssetBundle.Add(ab);
					List<ValueTuple<BulletType, GameObject?>> bullets = new List<ValueTuple<BulletType, GameObject>>();
					GameObject prefab2;
					try
					{
						prefab2 = ab.GetAsset<GameObject>("Prefab");
						prefab2.tag = "Plant";
					}
					catch
					{
						continue;
					}
					GameObject preview2;
					try
					{
						preview2 = ab.GetAsset<GameObject>("Preview");
						preview2.tag = "Preview";
					}
					catch
					{
						continue;
					}
					if (json.SaveMaterial)
					{
						prefab2.SetSaveMaterial();
						preview2.SetSaveMaterial();
					}
					try
					{
						Regex bulletRegex = new Regex("Bullet_(\\d+)");
						var enumerator5 = ab.GetAssetBundleAssetNames().GetEnumerator();
						try
						{
							while (enumerator5.MoveNext())
							{
								string name = enumerator5.Current;
								Match bulletMatch = bulletRegex.Match(name);
								if (!((Group)bulletMatch).Success)
								{
									continue;
								}
								BulletType bulletID2 = (BulletType)int.Parse(((Capture)bulletMatch.Groups[1]).Value);
								GameObject bullet2 = ab.GetAsset<GameObject>(name);
								System.Collections.Generic.IEnumerator<Component> enumerator6 = GameAPP.resourcesManager.bulletPrefabs[bulletID2].GetComponents<Component>().GetEnumerator();
								try
								{
									while (((System.Collections.IEnumerator)enumerator6).MoveNext())
									{
										Component comp = enumerator6.Current;
										if (!bullet2.TryGetComponent(comp.GetIl2CppType(), out var cmp) && cmp == null)
										{
											bullet2.AddComponent(comp.GetIl2CppType());
										}
										cmp = null;
									}
								}
								finally
								{
									((System.IDisposable)enumerator6)?.Dispose();
								}
								bullet2.GetComponent<Bullet>().theBulletType = bulletID2;
								bullets.Add(new ValueTuple<BulletType, GameObject>(bulletID2, bullet2));
							}
						}
						finally
						{
							((System.IDisposable)enumerator5).Dispose();
						}
					}
					catch
					{
						continue;
					}
					while (!PlantDataManager.PlantData_Default.ContainsKey(plantType2))
					{
						yield return new WaitForSeconds(0.1f);
					}
					while (!GameAPP.resourcesManager.plantPrefabs.ContainsKey(plantType2))
					{
						yield return new WaitForSeconds(0.1f);
					}
					while (!GameAPP.resourcesManager.plantPreviews.ContainsKey(plantType2))
					{
						yield return new WaitForSeconds(0.1f);
					}
					CustomPlantData data = new CustomPlantData
					{
						ID = id,
						PlantData = PlantDataManager.PlantData_Default[plantType2],
						Prefab = GameAPP.resourcesManager.plantPrefabs[plantType2],
						Preview = GameAPP.resourcesManager.plantPreviews[plantType2]
					};
					if (!GameAPP.resourcesManager.plantSkinDic.TryGetValue(plantType2, out value))
					{
						GameAPP.resourcesManager.plantSkinDic.Add(plantType2, 0);
					}
					if (prefab2 != null)
					{
						System.Collections.Generic.IEnumerator<Component> enumerator7 = GameAPP.resourcesManager.plantPrefabs[plantType2].GetComponents<Component>().GetEnumerator();
						try
						{
							while (((System.Collections.IEnumerator)enumerator7).MoveNext())
							{
								Component comp2 = enumerator7.Current;
								if (!prefab2.TryGetComponent(comp2.GetIl2CppType(), out var cmp2) && cmp2 == null)
								{
									prefab2.AddComponent(comp2.GetIl2CppType());
								}
								cmp2 = null;
							}
						}
						finally
						{
							((System.IDisposable)enumerator7)?.Dispose();
						}
						prefab2.GetComponent<Plant>().thePlantType = plantType2;
						if (GameAPP.resourcesManager._plantPrefabs.ContainsKey(plantType2))
						{
							GameAPP.resourcesManager._plantPrefabs[plantType2].Add(prefab2);
						}
						else
						{
								Il2CppSystem.Collections.Generic.List<GameObject> list4 = new Il2CppSystem.Collections.Generic.List<GameObject>();
							list4.Add(GameAPP.resourcesManager.plantPrefabs[plantType2]);
							list4.Add(prefab2);
							GameAPP.resourcesManager._plantPrefabs.Add(plantType2, list4);
						}
						prefab2.GetComponent<Plant>().FindShoot(((Component)(object)prefab2.GetComponent<Plant>()).transform);
						data.Prefab = prefab2;
					}
					if (preview2 != null)
					{
						System.Collections.Generic.IEnumerator<Component> enumerator8 = GameAPP.resourcesManager.plantPreviews[plantType2].GetComponents<Component>().GetEnumerator();
						try
						{
							while (((System.Collections.IEnumerator)enumerator8).MoveNext())
							{
								Component comp3 = enumerator8.Current;
								if (!preview2.TryGetComponent(comp3.GetIl2CppType(), out var cmp3) && cmp3 == null)
								{
									preview2.AddComponent(comp3.GetIl2CppType());
								}
								cmp3 = null;
							}
						}
						finally
						{
							((System.IDisposable)enumerator8)?.Dispose();
						}
						if (GameAPP.resourcesManager._plantPreviews.ContainsKey(plantType2))
						{
							GameAPP.resourcesManager._plantPreviews[plantType2].Add(preview2);
						}
						else
						{
								Il2CppSystem.Collections.Generic.List<GameObject> list5 = new Il2CppSystem.Collections.Generic.List<GameObject>();
							list5.Add(GameAPP.resourcesManager.plantPreviews[plantType2]);
							list5.Add(preview2);
							GameAPP.resourcesManager._plantPreviews.Add(plantType2, list5);
						}
						data.Preview = preview2;
					}
					if (CustomCore.CustomPlantsSkin.ContainsKey(plantType2))
					{
						CustomCore.CustomPlantsSkin[plantType2].Add(data);
					}
					else
					{
						Dictionary<PlantType, List<CustomPlantData>> customPlantsSkin = CustomCore.CustomPlantsSkin;
						List<CustomPlantData> obj6 = new List<CustomPlantData>();
						obj6.Add(data);
						customPlantsSkin.Add(plantType2, obj6);
					}
					int index_prefab2 = GameAPP.resourcesManager._plantPrefabs[plantType2].IndexOf(prefab2);
					int index_preview2 = GameAPP.resourcesManager._plantPreviews[plantType2].IndexOf(preview2);
					if (index_prefab2 == -1 || index_preview2 == -1 || index_prefab2 != index_preview2)
					{
						continue;
					}
					if (CustomCore.CustomPlantSkinIndex.ContainsKey(plantType2))
					{
						CustomCore.CustomPlantSkinIndex[plantType2].Add(index_prefab2);
					}
					else
					{
						Dictionary<PlantType, List<int>> customPlantSkinIndex2 = CustomCore.CustomPlantSkinIndex;
						List<int> obj7 = new List<int>();
						obj7.Add(index_prefab2);
						customPlantSkinIndex2.Add(plantType2, obj7);
					}
					int index2 = GameAPP.resourcesManager._plantPrefabs[plantType2].IndexOf(prefab2);
					var enumerator9 = bullets.GetEnumerator();
					try
					{
						while (enumerator9.MoveNext())
						{
							ValueTuple<BulletType, GameObject> current2 = enumerator9.Current;
							BulletType bulletID3 = current2.Item1;
							GameObject bullet3 = current2.Item2;
							if (bullet3 == null)
							{
								continue;
							}
							BulletType skinBulletID = (BulletType)(CustomCore.CustomBulletSkinStartID + CustomCore.RegisteredSkinBulletCount);
							CustomCore.RegisterCustomSkinBullet(bulletID3, skinBulletID, bullet3);
							if ((int)bulletID3 != -1 && bullets != null && index2 != -1)
							{
								if (!CustomCore.CustomBulletSkinReplace.ContainsKey(new ValueTuple<PlantType, int>(plantType2, index2)))
								{
									Dictionary<ValueTuple<PlantType, int>, Dictionary<BulletType, List<BulletType>>> customBulletSkinReplace2 = CustomCore.CustomBulletSkinReplace;
									ValueTuple<PlantType, int> val2 = new ValueTuple<PlantType, int>(plantType2, index2);
									Dictionary<BulletType, List<BulletType>> obj8 = new Dictionary<BulletType, List<BulletType>>();
									List<BulletType> obj9 = new List<BulletType>();
									obj9.Add(skinBulletID);
									obj8.Add(bulletID3, obj9);
									customBulletSkinReplace2.Add(val2, obj8);
								}
								else if (CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType2, index2)].ContainsKey(bulletID3))
								{
									CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType2, index2)][bulletID3].Add(skinBulletID);
								}
								else
								{
									Dictionary<BulletType, List<BulletType>> obj10 = CustomCore.CustomBulletSkinReplace[new ValueTuple<PlantType, int>(plantType2, index2)];
									List<BulletType> obj11 = new List<BulletType>();
									obj11.Add(skinBulletID);
									obj10.Add(bulletID3, obj11);
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator9).Dispose();
					}
					text = null;
				}
			}
		}
		string directory = Path.Combine(Application.persistentDataPath, "Skin");
		if (!Directory.Exists(directory))
		{
			Directory.CreateDirectory(directory);
		}
		string path2 = Path.Combine(directory, "skin.json");
		PlantType key = default(PlantType);
		if (!File.Exists(path2))
		{
			((Stream)File.Create(path2)).Dispose();
		}
		else
		{
			string content = File.ReadAllText(path2);
			try
			{
				Dictionary<PlantType, int> skinDic = JsonSerializer.Deserialize<Dictionary<PlantType, int>>(content, (JsonSerializerOptions)null);
				if (skinDic != null)
				{
					var enumerator10 = skinDic.GetEnumerator();
					try
					{
						while (enumerator10.MoveNext())
						{
							enumerator10.Current.Deconstruct(out key, out value);
							PlantType key2 = key;
							int value2 = value;
							if (!GameAPP.resourcesManager.plantSkinDic.ContainsKey(key2))
							{
								continue;
							}
							if (GameAPP.resourcesManager._plantPrefabs.ContainsKey(key2) && GameAPP.resourcesManager._plantPrefabs[key2].Count > value2 && GameAPP.resourcesManager._plantPreviews.ContainsKey(key2) && GameAPP.resourcesManager._plantPreviews[key2].Count > value2)
							{
								GameAPP.resourcesManager.plantPrefabs[key2] = GameAPP.resourcesManager._plantPrefabs[key2][value2];
								GameAPP.resourcesManager.plantPreviews[key2] = GameAPP.resourcesManager._plantPreviews[key2][value2];
								GameAPP.resourcesManager.plantSkinDic[key2] = value2;
								continue;
							}
							try
							{
								GameAPP.resourcesManager.plantPrefabs[key2] = GameAPP.resourcesManager._plantPrefabs[key2][0];
								GameAPP.resourcesManager.plantPreviews[key2] = GameAPP.resourcesManager._plantPreviews[key2][0];
								GameAPP.resourcesManager.plantSkinDic[key2] = 0;
							}
							catch (System.Exception)
							{
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator10).Dispose();
					}
				}
			}
			catch (JsonException)
			{
			}
		}
		UpdateSkin();
		SetEnableSkin();
		if (SkinData.PlantSkinDic == null)
		{
			SkinData.PlantSkinDic = GameAPP.resourcesManager.plantSkinDic.Clone();
		}
			Il2CppSystem.Collections.Generic.List<GameObject> value3;
		if (SkinData._plantPrefabs == null)
		{
				SkinData._plantPrefabs = new System.Collections.Generic.Dictionary<PlantType, Il2CppSystem.Collections.Generic.List<GameObject>>();
			var enumerator11 = GameAPP.resourcesManager._plantPrefabs.GetEnumerator();
			while (enumerator11.MoveNext())
			{
				enumerator11.Current.Deconstruct(out key, out value3);
				PlantType key3 = key;
					Il2CppSystem.Collections.Generic.List<GameObject> list6 = value3;
				SkinData._plantPrefabs.Add(key3, list6);
			}
		}
		if (SkinData._plantPreviews == null)
		{
				SkinData._plantPreviews = new System.Collections.Generic.Dictionary<PlantType, Il2CppSystem.Collections.Generic.List<GameObject>>();
			var enumerator12 = GameAPP.resourcesManager._plantPreviews.GetEnumerator();
			while (enumerator12.MoveNext())
			{
				enumerator12.Current.Deconstruct(out key, out value3);
				PlantType key4 = key;
					Il2CppSystem.Collections.Generic.List<GameObject> list7 = value3;
				SkinData._plantPreviews.Add(key4, list7);
			}
		}
	}

	public static void ShowCustomCards(MonoBehaviour mono)
	{
		mono.StartCoroutine(ShowCardCoroutine());
	}

	public static System.Collections.IEnumerator ShowCardCoroutine()
	{
		yield return new WaitForSeconds(1.5f);
		ShowCards();
	}

	public static void ShowCards()
	{


























































		GameObject colorfulCardGameObject = Utils.GetColorfulCardGameObject();
		List<PlantType> val = new List<PlantType>();
		Dictionary<PlantType, List<bool>> val2 = new Dictionary<PlantType, List<bool>>();
		GameObject gameObject = null;
		if ((Object)(object)Board.Instance != null && !Board.Instance.boardTag.isIZ)
		{
			gameObject = InGameUI.Instance.SeedBank.transform.GetChild(0).gameObject;
		}
		else if ((Object)(object)Board.Instance != null && Board.Instance.boardTag.isIZ)
		{
			gameObject = ((Component)(object)InGameUI_IZ.Instance).transform.FindChild("SeedBank/SeedGroup").gameObject;
		}
		if (gameObject == null)
		{
			return;
		}
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
			if (gameObject2.transform.childCount > 0)
			{
				val.Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType);
				if (!val2.ContainsKey(gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType))
				{
					PlantType thePlantType = gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType;
					List<bool> obj = new List<bool>();
					obj.Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().isExtra);
					val2.Add(thePlantType, obj);
				}
				else
				{
					val2[gameObject2.transform.GetChild(0).GetComponent<CardUI>().thePlantType].Add(gameObject2.transform.GetChild(0).GetComponent<CardUI>().isExtra);
				}
			}
		}
		if (colorfulCardGameObject == null)
		{
			return;
		}
		bool isIZ = Board.Instance.boardTag.isIZ;
		var enumerator = CustomCore.CustomCards.GetEnumerator();
		PlantType val3 = default(PlantType);
		ValueTuple<List<Func<Transform>>, int> val4 = default(ValueTuple<List<Func<Transform>>, int>);
		try
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Deconstruct(out val3, out val4);
				ValueTuple<List<Func<Transform>>, int> val5 = val4;
				PlantType val6 = val3;
				List<Func<Transform>> item = val5.Item1;
				int item2 = val5.Item2;
				int num = (isIZ ? item2 : (item2 + 1));
				var enumerator2 = item.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						Func<Transform> current = enumerator2.Current;
						Transform parent = current.Invoke();
						GameObject gameObject3 = Object.Instantiate(colorfulCardGameObject, parent);
						if (!(gameObject3 != null))
						{
							continue;
						}
						gameObject3.SetActive(value: true);
						gameObject3.transform.position = colorfulCardGameObject.transform.position;
						gameObject3.transform.localPosition = colorfulCardGameObject.transform.localPosition;
						gameObject3.transform.localScale = colorfulCardGameObject.transform.localScale;
						gameObject3.transform.localRotation = colorfulCardGameObject.transform.localRotation;
						Image component = gameObject3.transform.GetChild(0).GetChild(0).GetComponent<Image>();
						component.sprite = GameAPP.resourcesManager.plantPreviews[val6].GetComponent<SpriteRenderer>().sprite;
						component.SetNativeSize();
						((TMP_Text)gameObject3.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>()).text = PlantDataManager.PlantData_Default[val6].cost.ToString();
						RectTransform component2 = gameObject3.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
						for (int j = 0; j < num; j++)
						{
							Transform transform = Object.Instantiate(gameObject3.transform.GetChild(1), gameObject3.transform);
							CardUI component3 = transform.GetComponent<CardUI>();
							((Component)(object)component3).gameObject.SetActive(value: true);
							Mouse.Instance.ChangeCardSprite(val6, component3);
							transform.GetComponent<BoxCollider2D>().enabled = true;
							RectTransform component4 = transform.GetChild(0).GetComponent<RectTransform>();
							component2.localScale = component4.localScale;
							component2.sizeDelta = component4.sizeDelta;
							component3.thePlantType = val6;
							component3.theSeedType = (int)val6;
							component3.theSeedCost = PlantDataManager.PlantData_Default[val6].cost;
							component3.fullCD = PlantDataManager.PlantData_Default[val6].cd;
							component3.CD = component3.fullCD;
							component3.parent = gameObject3;
							if (val.Contains(val6))
							{
								transform.gameObject.SetActive(value: false);
							}
							CheckCardState orAddComponent = gameObject3.GetOrAddComponent<CheckCardState>();
							if (!(orAddComponent == null))
							{
								orAddComponent.card = gameObject3;
								orAddComponent.cardType = component3.thePlantType;
							}
						}
						Object.Destroy(gameObject3.transform.GetChild(1).gameObject);
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		GameObject normalCardGameObject = Utils.GetNormalCardGameObject();
		if (normalCardGameObject == null)
		{
			return;
		}
		var enumerator3 = CustomCore.CustomNormalCards.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				enumerator3.Current.Deconstruct(out val3, out val4);
				ValueTuple<List<Func<Transform>>, int> val7 = val4;
				PlantType val8 = val3;
				List<Func<Transform>> item3 = val7.Item1;
				int item4 = val7.Item2;
				int num2 = (isIZ ? item4 : (item4 + 1));
				var enumerator4 = item3.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						Func<Transform> current2 = enumerator4.Current;
						Transform parent2 = current2.Invoke();
						GameObject gameObject4 = Object.Instantiate(normalCardGameObject, parent2);
						if (!(gameObject4 != null))
						{
							continue;
						}
						gameObject4.SetActive(value: true);
						gameObject4.transform.position = normalCardGameObject.transform.position;
						gameObject4.transform.localPosition = normalCardGameObject.transform.localPosition;
						gameObject4.transform.localScale = normalCardGameObject.transform.localScale;
						gameObject4.transform.localRotation = normalCardGameObject.transform.localRotation;
						Image component5 = gameObject4.transform.GetChild(0).GetChild(0).GetComponent<Image>();
						component5.sprite = GameAPP.resourcesManager.plantPreviews[val8].GetComponent<SpriteRenderer>().sprite;
						component5.SetNativeSize();
						((TMP_Text)gameObject4.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>()).text = PlantDataManager.PlantData_Default[val8].cost.ToString();
						RectTransform component6 = gameObject4.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
						for (int k = 0; k < num2; k++)
						{
							Transform transform2 = Object.Instantiate(gameObject4.transform.GetChild(2), gameObject4.transform);
							Transform transform3 = Object.Instantiate(gameObject4.transform.GetChild(1), gameObject4.transform);
							CardUI component7 = transform2.GetComponent<CardUI>();
							((Component)(object)component7).gameObject.SetActive(value: true);
							CardUI component8 = transform3.GetComponent<CardUI>();
							((Component)(object)component8).gameObject.SetActive(value: true);
							Mouse.Instance.ChangeCardSprite(val8, component7);
							Mouse.Instance.ChangeCardSprite(val8, component8);
							transform2.GetComponent<BoxCollider2D>().enabled = true;
							transform3.GetComponent<BoxCollider2D>().enabled = true;
							RectTransform component9 = transform2.GetChild(0).GetComponent<RectTransform>();
							component6.localScale = component9.localScale;
							component6.sizeDelta = component9.sizeDelta;
							component7.thePlantType = val8;
							component7.theSeedType = (int)val8;
							component7.theSeedCost = PlantDataManager.PlantData_Default[val8].cost;
							component7.fullCD = PlantDataManager.PlantData_Default[val8].cd;
							component8.thePlantType = val8;
							component8.theSeedType = (int)val8;
							component8.theSeedCost = PlantDataManager.PlantData_Default[val8].cost * 2;
							component8.fullCD = PlantDataManager.PlantData_Default[val8].cd;
							if (val2.ContainsKey(val8) && val2[val8].Contains(true))
							{
								transform3.gameObject.SetActive(value: false);
							}
							if (val2.ContainsKey(val8) && val2[val8].Contains(false))
							{
								transform2.gameObject.SetActive(value: false);
							}
							CheckCardState checkCardState = gameObject4.AddComponent<CheckCardState>();
							checkCardState.card = gameObject4;
							checkCardState.cardType = component7.thePlantType;
							checkCardState.isNormalCard = true;
						}
						Object.Destroy(gameObject4.transform.GetChild(1).gameObject);
					}
				}
				finally
				{
					((System.IDisposable)enumerator4).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}

	public static void SaveSkin()
	{




		Dictionary<PlantType, int> val = new Dictionary<PlantType, int>();
		var enumerator = GameAPP.resourcesManager.plantSkinDic.GetEnumerator();
		while (enumerator.MoveNext())
		{
			var (val3, num2) = enumerator.Current;
			if (CustomCore.CustomPlantsSkin.ContainsKey(val3))
			{
				val.Add(val3, num2);
			}
		}
		string text = JsonSerializer.Serialize<Dictionary<PlantType, int>>(val, (JsonSerializerOptions)null);
		string text2 = Path.Combine(Application.persistentDataPath, "Skin");
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = Path.Combine(text2, "skin.json");
		if (!File.Exists(text3))
		{
			((Stream)File.Create(text3)).Dispose();
		}
		File.WriteAllText(text3, text);
	}
}
