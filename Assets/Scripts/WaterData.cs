using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterData {

	private static Dictionary<string, float> _table = new Dictionary<string, float>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){

	}

	public static float GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		float temp = 0f;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return 0f;
		}
			
	}
}


