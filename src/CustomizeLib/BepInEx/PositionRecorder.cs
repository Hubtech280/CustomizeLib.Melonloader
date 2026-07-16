using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomizeLib.BepInEx;

public class PositionRecorder : MonoBehaviour
{
	public struct RecordPosition
	{
		public Vector2 position;

		public float time;

		public PlantType plantType;

		public int index;

		public bool remove;

		public RecordPosition(Vector2 position, PlantType plantType)
		{



			time = 0.05f;
			this.plantType = (PlantType)(-1);
			index = -1;
			remove = false;
			this.position = position;
			this.plantType = plantType;
			remove = true;
		}
	}

	public static List<RecordPosition> positions = new List<RecordPosition>();

	public static void AddPositonToList(Vector2 position, PlantType fromType)
	{

		RecordPosition recordPosition = new RecordPosition(position, fromType);
		recordPosition.index = positions.Count;
		positions.Add(recordPosition);
	}

	public static void RemovePosition(int index)
	{
		if (index >= 0 && index < positions.Count)
		{
			RecordPosition recordPosition = positions[index];
			recordPosition.remove = true;
			positions[index] = recordPosition;
		}
	}

	public void Update()
	{
		for (int num = positions.Count - 1; num >= 0; num--)
		{
			RecordPosition recordPosition = positions[num];
			recordPosition.time -= Time.deltaTime;
			positions[num] = recordPosition;
			if (recordPosition.time <= 0f)
			{
				positions.Remove(recordPosition);
			}
			if (recordPosition.remove)
			{
				positions.Remove(recordPosition);
			}
		}
	}

	public static List<RecordPosition> GetRecordPositions(Vector2 center, float radius)
	{


		List<RecordPosition> val = new List<RecordPosition>();
		var enumerator = positions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				RecordPosition current = enumerator.Current;
				if (Vector2.Distance(center, current.position) < radius)
				{
					val.Add(current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return val;
	}
}
