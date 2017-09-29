using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterData
{

	private static Dictionary<string, float[]> _table = new Dictionary<string, float[]>(); //Key is Year and Month ie 201701: January of 2017

	public static void LoadItemsData()
	{
		float[] water = new float[12];
		for (int i = 0; i < water.Length; i++)
		{
			water[i] = Mathf.RoundToInt(Random.Range(800, 1200));
		}
		_table.Add("Test", water);
	}

	public static float[] GetItem(string name)
	{
		if (_table.Count == 0)
		{
			LoadItemsData();
		}
		float[] temp = new float[12];
		if (_table.TryGetValue(name, out temp))
		{
			return temp;
		}
		else
		{
			return new float[] { 0 };
		}

	}
}


