namespace CustomizeLib.BepInEx;

public static class SkinExtensions
{
	public static void AddValueToTypeMgrExtraSkinBackup(this CustomTypeMgrExtraSkin typeMgrExtraSkinFromJson, PlantType plantType)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		CustomCore.TypeMgrExtraSkinBackup.BigNut.Add(plantType, typeMgrExtraSkinFromJson.BigNut);
		CustomCore.TypeMgrExtraSkinBackup.DoubleBoxPlants.Add(plantType, typeMgrExtraSkinFromJson.DoubleBoxPlants);
		CustomCore.TypeMgrExtraSkinBackup.FlyingPlants.Add(plantType, typeMgrExtraSkinFromJson.FlyingPlants);
		CustomCore.TypeMgrExtraSkinBackup.IsCaltrop.Add(plantType, typeMgrExtraSkinFromJson.IsCaltrop);
		CustomCore.TypeMgrExtraSkinBackup.IsCustomPlant.Add(plantType, typeMgrExtraSkinFromJson.IsCustomPlant);
		CustomCore.TypeMgrExtraSkinBackup.IsFirePlant.Add(plantType, typeMgrExtraSkinFromJson.IsFirePlant);
		CustomCore.TypeMgrExtraSkinBackup.IsIcePlant.Add(plantType, typeMgrExtraSkinFromJson.IsIcePlant);
		CustomCore.TypeMgrExtraSkinBackup.IsMagnetPlants.Add(plantType, typeMgrExtraSkinFromJson.IsMagnetPlants);
		CustomCore.TypeMgrExtraSkinBackup.IsNut.Add(plantType, typeMgrExtraSkinFromJson.IsNut);
		CustomCore.TypeMgrExtraSkinBackup.IsPlantern.Add(plantType, typeMgrExtraSkinFromJson.IsPlantern);
		CustomCore.TypeMgrExtraSkinBackup.IsPot.Add(plantType, typeMgrExtraSkinFromJson.IsPot);
		CustomCore.TypeMgrExtraSkinBackup.IsPotatoMine.Add(plantType, typeMgrExtraSkinFromJson.IsPotatoMine);
		CustomCore.TypeMgrExtraSkinBackup.IsPuff.Add(plantType, typeMgrExtraSkinFromJson.IsPuff);
		CustomCore.TypeMgrExtraSkinBackup.IsPumpkin.Add(plantType, typeMgrExtraSkinFromJson.IsPumpkin);
		CustomCore.TypeMgrExtraSkinBackup.IsSmallRangeLantern.Add(plantType, typeMgrExtraSkinFromJson.IsSmallRangeLantern);
		CustomCore.TypeMgrExtraSkinBackup.IsSpecialPlant.Add(plantType, typeMgrExtraSkinFromJson.IsSpecialPlant);
		CustomCore.TypeMgrExtraSkinBackup.IsSpickRock.Add(plantType, typeMgrExtraSkinFromJson.IsSpickRock);
		CustomCore.TypeMgrExtraSkinBackup.IsTallNut.Add(plantType, typeMgrExtraSkinFromJson.IsTallNut);
		CustomCore.TypeMgrExtraSkinBackup.IsTangkelp.Add(plantType, typeMgrExtraSkinFromJson.IsTangkelp);
		CustomCore.TypeMgrExtraSkinBackup.IsWaterPlant.Add(plantType, typeMgrExtraSkinFromJson.IsWaterPlant);
		CustomCore.TypeMgrExtraSkinBackup.UmbrellaPlants.Add(plantType, typeMgrExtraSkinFromJson.UmbrellaPlants);
	}

	public static void SwapTypeMgrExtraSkinAndBackup(PlantType plantType)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0778: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		int num = default(int);
		int num2 = default(int);
		if (CustomCore.TypeMgrExtraSkin.BigNut.TryGetValue(plantType, out num))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.BigNut.TryAdd(plantType, num))
			{
				CustomCore.TypeMgrExtraSkin.BigNut.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.BigNut.TryGetValue(plantType, out num2) && CustomCore.TypeMgrExtraSkin.BigNut.TryAdd(plantType, num2))
		{
			CustomCore.TypeMgrExtraSkinBackup.BigNut.Remove(plantType);
		}
		int num3 = default(int);
		int num4 = default(int);
		if (CustomCore.TypeMgrExtraSkin.DoubleBoxPlants.TryGetValue(plantType, out num3))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.DoubleBoxPlants.TryAdd(plantType, num3))
			{
				CustomCore.TypeMgrExtraSkin.DoubleBoxPlants.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.DoubleBoxPlants.TryGetValue(plantType, out num4) && CustomCore.TypeMgrExtraSkin.DoubleBoxPlants.TryAdd(plantType, num4))
		{
			CustomCore.TypeMgrExtraSkinBackup.DoubleBoxPlants.Remove(plantType);
		}
		int num5 = default(int);
		int num6 = default(int);
		if (CustomCore.TypeMgrExtraSkin.FlyingPlants.TryGetValue(plantType, out num5))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.FlyingPlants.TryAdd(plantType, num5))
			{
				CustomCore.TypeMgrExtraSkin.FlyingPlants.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.FlyingPlants.TryGetValue(plantType, out num6) && CustomCore.TypeMgrExtraSkin.FlyingPlants.TryAdd(plantType, num6))
		{
			CustomCore.TypeMgrExtraSkinBackup.FlyingPlants.Remove(plantType);
		}
		int num7 = default(int);
		int num8 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsCaltrop.TryGetValue(plantType, out num7))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsCaltrop.TryAdd(plantType, num7))
			{
				CustomCore.TypeMgrExtraSkin.IsCaltrop.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsCaltrop.TryGetValue(plantType, out num8) && CustomCore.TypeMgrExtraSkin.IsCaltrop.TryAdd(plantType, num8))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsCaltrop.Remove(plantType);
		}
		int num9 = default(int);
		int num10 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsCustomPlant.TryGetValue(plantType, out num9))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsCustomPlant.TryAdd(plantType, num9))
			{
				CustomCore.TypeMgrExtraSkin.IsCustomPlant.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsCustomPlant.TryGetValue(plantType, out num10) && CustomCore.TypeMgrExtraSkin.IsCustomPlant.TryAdd(plantType, num10))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsCustomPlant.Remove(plantType);
		}
		int num11 = default(int);
		int num12 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsFirePlant.TryGetValue(plantType, out num11))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsFirePlant.TryAdd(plantType, num11))
			{
				CustomCore.TypeMgrExtraSkin.IsFirePlant.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsFirePlant.TryGetValue(plantType, out num12) && CustomCore.TypeMgrExtraSkin.IsFirePlant.TryAdd(plantType, num12))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsFirePlant.Remove(plantType);
		}
		int num13 = default(int);
		int num14 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsIcePlant.TryGetValue(plantType, out num13))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsIcePlant.TryAdd(plantType, num13))
			{
				CustomCore.TypeMgrExtraSkin.IsIcePlant.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsIcePlant.TryGetValue(plantType, out num14) && CustomCore.TypeMgrExtraSkin.IsIcePlant.TryAdd(plantType, num14))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsIcePlant.Remove(plantType);
		}
		int num15 = default(int);
		int num16 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsMagnetPlants.TryGetValue(plantType, out num15))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsMagnetPlants.TryAdd(plantType, num15))
			{
				CustomCore.TypeMgrExtraSkin.IsMagnetPlants.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsMagnetPlants.TryGetValue(plantType, out num16) && CustomCore.TypeMgrExtraSkin.IsMagnetPlants.TryAdd(plantType, num16))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsMagnetPlants.Remove(plantType);
		}
		int num17 = default(int);
		int num18 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsNut.TryGetValue(plantType, out num17))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsNut.TryAdd(plantType, num17))
			{
				CustomCore.TypeMgrExtraSkin.IsNut.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsNut.TryGetValue(plantType, out num18) && CustomCore.TypeMgrExtraSkin.IsNut.TryAdd(plantType, num18))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsNut.Remove(plantType);
		}
		int num19 = default(int);
		int num20 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPlantern.TryGetValue(plantType, out num19))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsPlantern.TryAdd(plantType, num19))
			{
				CustomCore.TypeMgrExtraSkin.IsPlantern.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsPlantern.TryGetValue(plantType, out num20) && CustomCore.TypeMgrExtraSkin.IsPlantern.TryAdd(plantType, num20))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsPlantern.Remove(plantType);
		}
		int num21 = default(int);
		int num22 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPot.TryGetValue(plantType, out num21))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsPot.TryAdd(plantType, num21))
			{
				CustomCore.TypeMgrExtraSkin.IsPot.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsPot.TryGetValue(plantType, out num22) && CustomCore.TypeMgrExtraSkin.IsPot.TryAdd(plantType, num22))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsPot.Remove(plantType);
		}
		int num23 = default(int);
		int num24 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPotatoMine.TryGetValue(plantType, out num23))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsPotatoMine.TryAdd(plantType, num23))
			{
				CustomCore.TypeMgrExtraSkin.IsPotatoMine.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsPotatoMine.TryGetValue(plantType, out num24) && CustomCore.TypeMgrExtraSkin.IsPotatoMine.TryAdd(plantType, num24))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsPotatoMine.Remove(plantType);
		}
		int num25 = default(int);
		int num26 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPuff.TryGetValue(plantType, out num25))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsPuff.TryAdd(plantType, num25))
			{
				CustomCore.TypeMgrExtraSkin.IsPuff.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsPuff.TryGetValue(plantType, out num26) && CustomCore.TypeMgrExtraSkin.IsPuff.TryAdd(plantType, num26))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsPuff.Remove(plantType);
		}
		int num27 = default(int);
		int num28 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsPumpkin.TryGetValue(plantType, out num27))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsPumpkin.TryAdd(plantType, num27))
			{
				CustomCore.TypeMgrExtraSkin.IsPumpkin.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsPumpkin.TryGetValue(plantType, out num28) && CustomCore.TypeMgrExtraSkin.IsPumpkin.TryAdd(plantType, num28))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsPumpkin.Remove(plantType);
		}
		int num29 = default(int);
		int num30 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSmallRangeLantern.TryGetValue(plantType, out num29))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsSmallRangeLantern.TryAdd(plantType, num29))
			{
				CustomCore.TypeMgrExtraSkin.IsSmallRangeLantern.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsSmallRangeLantern.TryGetValue(plantType, out num30) && CustomCore.TypeMgrExtraSkin.IsSmallRangeLantern.TryAdd(plantType, num30))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsSmallRangeLantern.Remove(plantType);
		}
		int num31 = default(int);
		int num32 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSpecialPlant.TryGetValue(plantType, out num31))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsSpecialPlant.TryAdd(plantType, num31))
			{
				CustomCore.TypeMgrExtraSkin.IsSpecialPlant.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsSpecialPlant.TryGetValue(plantType, out num32) && CustomCore.TypeMgrExtraSkin.IsSpecialPlant.TryAdd(plantType, num32))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsSpecialPlant.Remove(plantType);
		}
		int num33 = default(int);
		int num34 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsSpickRock.TryGetValue(plantType, out num33))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsSpickRock.TryAdd(plantType, num33))
			{
				CustomCore.TypeMgrExtraSkin.IsSpickRock.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsSpickRock.TryGetValue(plantType, out num34) && CustomCore.TypeMgrExtraSkin.IsSpickRock.TryAdd(plantType, num34))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsSpickRock.Remove(plantType);
		}
		int num35 = default(int);
		int num36 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsTallNut.TryGetValue(plantType, out num35))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsTallNut.TryAdd(plantType, num35))
			{
				CustomCore.TypeMgrExtraSkin.IsTallNut.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsTallNut.TryGetValue(plantType, out num36) && CustomCore.TypeMgrExtraSkin.IsTallNut.TryAdd(plantType, num36))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsTallNut.Remove(plantType);
		}
		int num37 = default(int);
		int num38 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsTangkelp.TryGetValue(plantType, out num37))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsTangkelp.TryAdd(plantType, num37))
			{
				CustomCore.TypeMgrExtraSkin.IsTangkelp.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsTangkelp.TryGetValue(plantType, out num38) && CustomCore.TypeMgrExtraSkin.IsTangkelp.TryAdd(plantType, num38))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsTangkelp.Remove(plantType);
		}
		int num39 = default(int);
		int num40 = default(int);
		if (CustomCore.TypeMgrExtraSkin.IsWaterPlant.TryGetValue(plantType, out num39))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.IsWaterPlant.TryAdd(plantType, num39))
			{
				CustomCore.TypeMgrExtraSkin.IsWaterPlant.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.IsWaterPlant.TryGetValue(plantType, out num40) && CustomCore.TypeMgrExtraSkin.IsWaterPlant.TryAdd(plantType, num40))
		{
			CustomCore.TypeMgrExtraSkinBackup.IsWaterPlant.Remove(plantType);
		}
		int num41 = default(int);
		int num42 = default(int);
		if (CustomCore.TypeMgrExtraSkin.UmbrellaPlants.TryGetValue(plantType, out num41))
		{
			if (CustomCore.TypeMgrExtraSkinBackup.UmbrellaPlants.TryAdd(plantType, num41))
			{
				CustomCore.TypeMgrExtraSkin.UmbrellaPlants.Remove(plantType);
			}
		}
		else if (CustomCore.TypeMgrExtraSkinBackup.UmbrellaPlants.TryGetValue(plantType, out num42) && CustomCore.TypeMgrExtraSkin.UmbrellaPlants.TryAdd(plantType, num42))
		{
			CustomCore.TypeMgrExtraSkinBackup.UmbrellaPlants.Remove(plantType);
		}
	}
}
