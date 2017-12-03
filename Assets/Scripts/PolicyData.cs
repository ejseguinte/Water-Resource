using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Security.Permissions;

public class PolicyData{

	private static Dictionary<string, Policy> _table = new Dictionary<string, Policy>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Policy policy = new Policy()
		{
			nameID = "HappinessEvent",
			guiName = "Middle School Water Conservation Art Contest",
			description = "Provide funding for an arts contest soliciting public middle school students to submit art related to water conservation. Winning submissions will be distributed in calendars and printed on billboards. Should produce positive effects on favorability polls, offestting some negativity from water cuts.",
			cost = 10F,
			duration = 3,
			happinessEffect = 2,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 0,
			populationMultiplier = 0,
			moneyEffect = 0
			
		};
		_table.Add(policy.nameID, policy);
		
		Policy policy1 = new Policy()
		{
			nameID = "PopulationEvent",
			guiName = "Subsidies for Out-of-State Home Buyers",
			description = "Offer subsidies for highly educated individuals to move to California. Will increase revenue over time after initial investment, but could displease some people in-state.",
			cost = 20F,
			duration = 5,
			happinessEffect = -1,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 0.5f,
			populationMultiplier = 0,
			moneyEffect = 5
		};
		_table.Add(policy1.nameID, policy1);
		
		Policy policy2 = new Policy()
		{
			nameID = "AgriculturalEvent",
			guiName = "Subsidies for Nutritional Agricultural Production",
			description = "Financially incentivize farmers to produce food to feed the state over less nutritional or other 'cash crops'.",
			cost = 30F,
			duration = 3,
			happinessEffect = 0,
			happinessMultiplier = 0,
			foodEffect = 200,
			foodMultiplier = 0,
			populationEffect = 0,
			populationMultiplier = 0,
			moneyEffect = 0

		};
		_table.Add(policy2.nameID, policy2);
		
		
	}

	public static Policy GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		Policy temp = null;
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
public class Policy
{

	public enum PolicyType{Agriculture,Urban,Recreational,Ecology};
	public string nameID;
	public string guiName;
	public string description;
	public Boolean purchased = false;
	public float cost;
	public int duration;		//How long the policy will last
	public int counter = 0;         //Amount of turns it has been used
	public float happinessEffect;
	public float happinessMultiplier;
	public float foodEffect;
	public float foodMultiplier;
	public float populationEffect;
	public float populationMultiplier;
	public float moneyEffect;

	public void InstantEffect()
	{
		Debug.Log("Applying " + guiName);
		GameManager.Happiness += happinessEffect;
		GameManager.HappinessMultiplier += happinessMultiplier;
		GameManager.Food += foodEffect;
		GameManager.FoodMultiplier += foodMultiplier;
		GameManager.PopulationEffect += populationEffect;
		GameManager.PopulationMultiplier += populationMultiplier;
		GameManager.Money += moneyEffect;
	}

}
