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
			nameID = "Domestic",
			guiName = "Domestic",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Urban Youth need water to live.",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
		};

		_table.Add(newGroup.nameID, newGroup);
		
		Group newGroup1 = new Group()
		{
			nameID = "Commercial",
			guiName = "Commercial",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Water has what plants crave.",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
		};

		_table.Add(newGroup1.nameID, newGroup1);
		
		Group newGroup2 = new Group()
		{
			nameID = "Industrial",
			guiName = "Industrial",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Hikers need water to raft and to live.",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
		};

		_table.Add(newGroup2.nameID, newGroup2);
		
		Group newGroup3 = new Group()
		{
			nameID = "Livestock",
			guiName = "Livestock",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Test",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
			
		};

		_table.Add(newGroup3.nameID, newGroup3);
		
		newGroup3 = new Group()
		{
			nameID = "Crops",
			guiName = "Crops",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Test",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
			
		};

		_table.Add(newGroup3.nameID, newGroup3);
		
		newGroup3 = new Group()
		{
			nameID = "Golf Courses",
			guiName = "Golf Courses",
			waterNeed = .35f,
			recommendedWater = .25f,
			description = "Test",
			effectID1 = "Happiness",
			effectMultiplier1 = .4f,
			effectID2 = "Population",
			effectMultiplier2 = -.1f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .3f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
			
		};

		_table.Add(newGroup3.nameID, newGroup3);

		Group newGroup4 = new Group()
		{
			nameID = "Market",
			guiName = "Market",
			waterNeed = 0f,
			recommendedWater = 0f,
			description = "Test",
			effectID1 = "Happiness",
			effectMultiplier1 = -.9f,
			effectID2 = "Population",
			effectMultiplier2 = 0f,
			effectID3 = "Food Growth",
			effectMultiplier3 = 0f,
			effectID4 = "Income",
			effectMultiplier4 = .9f
			
		};

		_table.Add(newGroup4.nameID, newGroup4);
		
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
	public float waterNeed;				//How much of the Total water for the turn they need Maximum
	public float recommendedWater;		//How much of the Total water for the turn they need minimum with no adverse effects
	public string description;
	public string effectID1;
	public float effectMultiplier1;
	public string effectID2;
	public float effectMultiplier2;
	public string effectID3;
	public float effectMultiplier3;
	public string effectID4;
	public float effectMultiplier4;
	
}
