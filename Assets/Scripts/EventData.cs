using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Permissions;

public class EventData{

	private static Dictionary<string, Event> _table = new Dictionary<string, Event>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Event newGroup = new Event()
		{
			//This Event is set in GameManager
			nameID = "Starvation",
			guiName = "Starvation",
			description = "Population has starved.",
			turn = 0,
			happinessEffect = 0,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 0,
			populationMultiplier = 0
			
		};

		_table.Add(newGroup.nameID, newGroup);
		
		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "Consume",
			guiName = "Consume Food",
			description = "Population has starved.",
			turn = 0,
			happinessEffect = 0,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 0,
			populationMultiplier = 0
			
		};

		_table.Add(newGroup.nameID, newGroup);

		// Events that get triggered update after resources get allocated

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "GolfCoursePositive",
			guiName = "New Golf Course Opening!",
			description = "New golf courses open in Folsom and Sonoma, causing golfers from other states to move in! More freshly watered Golf courses are now accessible for the citizens.",
			turn = 0,
			happinessEffect = 2,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 5000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "GolfCourseNegative",
			guiName = "Donald Trump angry over news of golf course closures and tournament cancellations.",
			description = "Donald Trump is reportedly furious over the closing of several golf courses statewide due to a water shortage. He described it as 'sad', and 'Unamerican'.",
			turn = 0,
			happinessEffect = -2,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = -1000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "LivestockPositive",
			guiName = "California Cows Win Best in Show!",
			description = "Great news for the dairy industry of California. Due to abundance of clean water and healthy breeding, the cows in California are thriving.",
			turn = 0,
			happinessEffect = 3,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 1.2f,
			populationEffect = 10000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "LivestockNegative",
			guiName = "Winter Dysentery",
			description = "Dysentery kills a large portion of the cattle population. Farmers cite possibility of stillwater contamination. Public health officials are concerned.",
			turn = 0,
			happinessEffect = -5,
			happinessMultiplier = 0,
			foodEffect = -250,
			foodMultiplier = 0,
			populationEffect = -1000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "CommercialPositive",
			guiName = "New WaterPark Opening!",
			description = "Brand new themed water parks have opened in California. People from all over the world are flocking to California to experience the waves.",
			turn = 0,
			happinessEffect = 5,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 1000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "CommercialNegative",
			guiName = "E. Coli Outbreak!",
			description = "An E.Coli outbreak has hit a California waterpark. Stillwater is likely the cause, as internal leaks have indicated the park was experiencing water woes.",
			turn = 0,
			happinessEffect = -10,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 0,
			//TODO : This currently reduces 10% of the population growth on medium difficulty according to EJ
			populationMultiplier = -.3f

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "DomesticPositive",
			guiName = "Local Pool Party!",
			description = "Local popular kid Jimmy invites everyone to come to his pool party. People from all over the nation wants to hang with Jimmy.",
			turn = 0,
			happinessEffect = 3,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 50,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "DomesticNegative",
			guiName = "Community Pool Closes!",
			description = "Community pools across the state are shutting down due to a lack of residential water supply. Angry hownowners are now complaing about skateboarding in the dry pools.",
			turn = 0,
			happinessEffect = -5,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = -2000,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "IndustrialPositive",
			guiName = "State Wins New Battery Plant Contract!",
			description = "State officials and corporate executives announced today in a joint press conference that a new battery manufacturing plant is being developed near Sacramento. Lots of jobs available.",
			turn = 0,
			happinessEffect = 3,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = 750,
			populationMultiplier = 0

		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "IndustrialNegative",
			guiName = "Factory Closures Sweep the State.",
			description = "Several factories including those that manufacture waterguns and hoses have announced they are shutting down this month. They cite a lack of water and interest in their products.",
			turn = 0,
			happinessEffect = -5,
			happinessMultiplier = 0,
			foodEffect = 0,
			foodMultiplier = 0,
			populationEffect = -500,
			populationMultiplier = 0
		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "CropsPositive",
			guiName = "Corn Maze Sets Record for Highest Walls.",
			description = "A Davis corn maze has set the world record for highest corn walls. The manager cites healthy watering and good weather as reasons for his success.",
			turn = 0,
			happinessEffect = 3,
			happinessMultiplier = 0,
			foodEffect = 250,
			foodMultiplier = 0,
			populationEffect = 1000,
			populationMultiplier = 0
		};

		_table.Add(newGroup.nameID, newGroup);

		newGroup = new Event()
		{	
			//This Event is set in GameManager
			nameID = "CropsNegative",
			guiName = "Tragic Crop Fires Sweep Northern California",
			description = "Several fires in the Central Valley have decimated large swaths of farmland. Many crops were dry and dying due to a lack of water. Farmers are furious at state officials.",
			turn = 0,
			happinessEffect = -10,
			happinessMultiplier = 0,
			foodEffect = -500,
			foodMultiplier = 0,
			populationEffect = -200,
			populationMultiplier = 0
		};

		_table.Add(newGroup.nameID, newGroup);
		
	}

	public static Event GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		Event temp = null;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return null;
		}

	}
}

[System.Serializable]
public class Event 
{

	public enum EventType{Agriculture,Urban,Recreational,Ecology};
	public string nameID;
	public string guiName;
	public string description;
	public int turn;					//Used to let the game know when the Event was used
	public float happinessEffect;
	public float happinessMultiplier;
	public float foodEffect;
	public float foodMultiplier;
	public float populationEffect;
	public float populationMultiplier;

	public void InstantEffect()
	{
		GameManager.Happiness += happinessEffect;
		GameManager.HappinessMultiplier += happinessMultiplier;
		GameManager.Food += foodEffect;
		GameManager.FoodMultiplier += foodMultiplier;
		GameManager.PopulationEffect += populationEffect;
		GameManager.PopulationMultiplier += populationMultiplier;
	}

	public Event Clone()
	{
		Event newGroup = new Event()
		{
			nameID = this.nameID,
			guiName = this.guiName,
			description = this.description,
			turn = this.turn,
			happinessEffect = this.happinessEffect,
			happinessMultiplier = this.happinessMultiplier,
			foodEffect = this.foodEffect,
			foodMultiplier = this.foodMultiplier,
			populationEffect = this.populationEffect,
			populationMultiplier = this.populationMultiplier
			
		};
		return newGroup;
	}

}
