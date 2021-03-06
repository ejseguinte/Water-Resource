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
			waterNeed = .25f,
			recommendedWater = 370278.7f,
			description = "Domestic use includes all water used for residential purposes (lawns, showers, drinking, laundry, etc. Also includes things like community pools and parks. An average American can use as much as 80-100 gallons of water a day, mostly with showers and the toilet!)",
			effectID1 = "Happiness",
			effectMultiplier1 = .8f,
			effectID2 = "Population",
			effectMultiplier2 = .005f,
			effectID3 = "Food Growth",
			effectMultiplier3 = -.05f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f
			
		};

		_table.Add(newGroup.nameID, newGroup);
		
		Group newGroup1 = new Group()
		{
			nameID = "Commercial",
			guiName = "Commercial",
			waterNeed = .25f,
			recommendedWater = 115552.8333f,
			description = "Commercial use includes any water used for commercially-zoned properties, like water parks, restaurants, fountains, and more. Businesses need water, just like everyone else!",
			effectID1 = "Happiness",
			effectMultiplier1 = .85f,
			effectID2 = "Population",
			effectMultiplier2 = .0f,
			effectID3 = "Food Growth",
			effectMultiplier3 = -.15f,
			effectID4 = "Income",
			effectMultiplier4 = .09f
			
		};

		_table.Add(newGroup1.nameID, newGroup1);
		
		Group newGroup2 = new Group()
		{
			nameID = "Industrial",
			guiName = "Industrial",
			waterNeed = .25f,
			recommendedWater = 74789.66667f,
			description = "Industrial use includes water used by industrially-zoned properties, such as in manufacturing. It takes nearly 10 gallons of water to make a single computer chip! Thankfully, manufacturing can often recycle water, so costs aren't as high as they could be.",
			effectID1 = "Happiness",
			effectMultiplier1 = -.75f,
			effectID2 = "Population",
			effectMultiplier2 = .2f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .0f,
			effectID4 = "Income",
			effectMultiplier4 = .09f
			
		};

		_table.Add(newGroup2.nameID, newGroup2);
		
		Group newGroup3 = new Group()
		{
			nameID = "Livestock",
			guiName = "Livestock",
			waterNeed = .25f,
			recommendedWater = 31423.16667f,
			description = "Livestock use is all the water it takes to feed and raise animals for human consumption. A single pound of beef can take as much as 440 gallons of water to produce!",
			effectID1 = "Happiness",
			effectMultiplier1 = -.8f,
			effectID2 = "Population",
			effectMultiplier2 = -.2f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .4f,
			effectID4 = "Income",
			effectMultiplier4 = .0f
			
			
		};

		_table.Add(newGroup3.nameID, newGroup3);
		
		newGroup3 = new Group()
		{
			nameID = "Crops",
			guiName = "Crops",
			waterNeed = .25f,
			recommendedWater = 2804821.167f,
			description = "Water use for the growing of crops. Other than required environmental upkeep and natural water flow, such as wetlands and the California Delta, this is the largest use of water in the state, usually by 3-5X any other single category (depending on if the year is a 'wet' year (lots of rain), or a 'dry' year (drought)).",
			effectID1 = "Happiness",
			effectMultiplier1 = -.75f,
			effectID2 = "Population",
			effectMultiplier2 = -.15f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .85f,
			effectID4 = "Income",
			effectMultiplier4 = -.09f

			
		};

		_table.Add(newGroup3.nameID, newGroup3);
		
		newGroup3 = new Group()
		{
			nameID = "Golf Courses",
			guiName = "Golf Courses",
			waterNeed = .3f,
			recommendedWater = 14554.16667f,
			description = "A golf course can hundreds of thousands of gallons of water to maintain every week, which seems like a ton! But will cutting all water from golf courses solve California's water problems? Try and find out...",
			effectID1 = "Happiness",
			effectMultiplier1 = .8f,
			effectID2 = "Population",
			effectMultiplier2 = -.005f,
			effectID3 = "Food Growth",
			effectMultiplier3 = .0f,
			effectID4 = "Income",
			effectMultiplier4 = .18f
			
			
		};

		_table.Add(newGroup3.nameID, newGroup3);

		Group newGroup4 = new Group()
		{
			nameID = "Market",
			guiName = "Market",
			waterNeed = 0f,
			recommendedWater = 0f,
			description = "Need a quick buck? Want to get a high score? Sell your extra water on the open market! It's not like you might need that water later...",
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
	public float waterNeed;				//Total Water the group needs
	public float recommendedWater;		//multiplier to add to 1 to decide Max water
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
