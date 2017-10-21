using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterData
{

	private static Dictionary<string, float[]> _table = new Dictionary<string, float[]>(); //Key is Year and Month ie 2017: January of 2017

	public static void LoadItemsData()
	{
		float[] water = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water[i] = Mathf.RoundToInt(Random.Range(227122, 326625));
			water[i] = Mathf.RoundToInt(water[i] * Random.Range(.8f, 1.2f));
			Debug.Log(water[i]);
		}
		_table.Add("0", water);

		int amount = 326625;
		float[] water1 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water1[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("1", water1);
		
		amount = 305956;
		float[] water2 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water2[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("2", water2);
		
		amount = 301169;
		float[] water3 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water3[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("3", water3);
		
		amount = 286607;
		float[] water4 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water4[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("4", water4);
		
		amount = 258228;
		float[] water5 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water5[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("5", water5);
		
		amount = 227122;
		float[] water6 = new float[13];
		for (int i = 0; i < water.Length; i++)
		{
			water6[i] = Mathf.RoundToInt(amount * Random.Range(.8f, 1.2f));
		}
		_table.Add("6", water6);
	}

	public static float[] GetItem(string name)
	{
		if (_table.Count == 0)
		{
			LoadItemsData();
		}
		float[] temp = new float[13];
		if (_table.TryGetValue(name, out temp))
		{
			return temp;
		}
		else
		{
			return GetItem("0");
		}

	}
}


