using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GroupData{

	private static Dictionary<string, Group> _table = new Dictionary<string, Group>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Group newGroup = new Group()
		{
			nameID = "TEST",
			guiName = "Test",
			waterNeed = .25f,
			description = "test",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f,
			recommendedWater = .25f,
			totalWater = .3f
			
		};

		_table.Add(newGroup.nameID, newGroup);
	}

	public static Group GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		Group temp = null;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return null;
		}

	}

	public static Array GetKeys()
	{
		if (_table.Count == 0){
			LoadItemsData();
		}
		return _table.Keys.ToArray();
	}
}

[System.Serializable]
public class Group
{

	public enum PolicyType{Agriculture,Urban,Recreational,Ecology};
	public string nameID;
	public string guiName;
	public float waterNeed;
	public string description;
	public string effectID1;
	public float effectMultiplier1;
	public string effectID2;
	public float effectMultiplier2;
	public string effectID3;
	public float effectMultiplier3;
	public string effectID4;
	public float effectMultiplier4;
	public float recommendedWater;
	public float totalWater;

}
