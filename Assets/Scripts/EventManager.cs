using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;
using System.Linq;
using System;

public class EventManager : MonoBehaviour {

	#region Private Variables
	EventManager eventManager;
	#endregion

	#region Public Variables
	private static Queue<string> eventNames;
	private static Stack<Event> previousEvents;
	private float[,] realWaterData;
	#endregion
	// Use this for initialization
	void Start()
	{
		if (eventManager != null)
		{
			Destroy(gameObject);
		}
		else
		{
			GameManager.eventManager = this;
			eventManager = this;
			eventNames = new Queue<string>();
			if(previousEvents == null)
				previousEvents = new Stack<Event>();
			//real water data for event predictions
			//first index is random data
			//rest are real world in ascending year order
			//order is Domestic Commercial Industrial Livestock Crops GolfCourses
			realWaterData = new float[7,6] {{370278 + UnityEngine.Random.Range(-20000f,20000f),115552 + UnityEngine.Random.Range(-7500f,7500f),74789 + UnityEngine.Random.Range(-5000f,5000f),31423 + UnityEngine.Random.Range(-3000f,3000f),2804821 + UnityEngine.Random.Range(-200000.0f,200000f),14554 + UnityEngine.Random.Range(-2000f,2000f)},
				{315402,144864,110795,38164,3299029,11248},
				{378807,95635,60322,38164,3085925,12630},
				{357603,128765,80007,38164,2996314,13180},
				{375766,108255,70331,38164,2832779,13997},
				{417207,98407,65836,18354,2482553,16382},
				{376887,117391,61447,17529,2132327,19888}};

		}
		
		
		
	}

	public static void AddEvent(string name)
	{	
		eventNames.Enqueue(name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool SetNextEvent()
	{
		if (eventNames.Count > 0)
		{
			string name = eventNames.Dequeue();
			Event events = EventData.GetItem(name);
			SetEvent(events);
			Event copy = events.Clone();
			copy.turn = GameManager.turnCounter;
			previousEvents.Push(copy);
			return true;
		}

		return false;

	}
	
	private void SetEvent(Event events){
		DisplayEvent(events);
		events.InstantEffect();
	}

	public void DisplayEvent(Event events)
	{
		string[] text = { events.guiName, events.description};
		GameManager.tooltip.SetEvent(text);
	}
	
	public void DisplayEvent(string name)
	{
		Event events = EventData.GetItem(name);
		DisplayEvent(events);
	}

	public void CloseEvent()
	{
		GameManager.EventDisplayed = false;
		GameManager.tooltip.HideTooltip();
		if(!SetNextEvent() && GameManager.State == GameManager.GameState.Event)
			GameManager.gameManager.NextState();

	}

	public static Event[] GetPreviousEvents()
	{
		if(previousEvents == null){
			previousEvents = new Stack<Event>();
			Event test = new Event()
			{	
				//This Event is set in GameManager
				nameID = "TestCropsNegative",
				guiName = "(TEST)Tragic Crop Fires Sweep Northern California(TEST)",
				description = "Several fires in the Central Valley have decimated large swaths of farmland. Many crops were dry and dying due to a lack of water. Farmers are furious at state officials.",
				turn = 0,
				happinessEffect = -10,
				happinessMultiplier = 0,
				foodEffect = -500,
				foodMultiplier = 0,
				populationEffect = -1f,
				populationMultiplier = 0
			};
			previousEvents.Push(test);
		}
			return previousEvents.ToArray();
		
	}

	public void GetEvents()
	{
		//determine the year
		int year = PlayerPrefsManager.GetYear();

		float domBadProb = (realWaterData[year,0] - GameManager.GetItem ("Domestic").waterGiven) / realWaterData[year,0];
		float domGoodProb = (GameManager.GetItem ("Domestic").waterGiven - realWaterData[year,0]) / realWaterData[year,0];
		Debug.Log(domBadProb);
		Debug.Log(domGoodProb);

		float comBadProb = (realWaterData[year,1] - GameManager.GetItem ("Commercial").waterGiven) / realWaterData[year,1];
		float comGoodProb = (GameManager.GetItem ("Commercial").waterGiven - realWaterData[year,1]) / realWaterData[year,1];
		Debug.Log(comBadProb);
		Debug.Log(comGoodProb);

		float indBadProb = (realWaterData[year,2] - GameManager.GetItem ("Industrial").waterGiven) / realWaterData[year,2];
		float indGoodProb = (GameManager.GetItem ("Industrial").waterGiven - realWaterData[year,2]) / realWaterData[year,2];
		Debug.Log(indBadProb);
		Debug.Log(indGoodProb);

		float livestockBadProb = (realWaterData[year,3] - GameManager.GetItem ("Livestock").waterGiven) / realWaterData[year,3];
		float livestockGoodProb = (GameManager.GetItem ("Livestock").waterGiven - realWaterData[year,3]) / realWaterData[year,3];
		Debug.Log(livestockBadProb);
		Debug.Log(livestockGoodProb);

		float cropBadProb = (realWaterData[year,4] - GameManager.GetItem ("Crops").waterGiven) / realWaterData[year,4];
		float cropGoodProb = (GameManager.GetItem ("Crops").waterGiven - realWaterData[year,4]) / realWaterData[year,4];
		Debug.Log(cropBadProb);
		Debug.Log(cropGoodProb);

		float golfBadProb = (realWaterData[year,5] - GameManager.GetItem ("Golf Courses").waterGiven) / realWaterData[year,5];
		float golfGoodProb = (GameManager.GetItem ("Golf Courses").waterGiven - realWaterData[year,5]) / realWaterData[year,5];
		Debug.Log(golfBadProb);
		Debug.Log(golfGoodProb);

		float diceRoll;

		if (domGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= domGoodProb)
				AddEvent ("DomesticPositive");
		}
		if (domBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= domBadProb)
				AddEvent ("DomesticNegative");
		}

		if (cropGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= cropGoodProb)
				AddEvent ("CropsPositive");
		}
		if (cropBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= cropBadProb)
				AddEvent ("CropsNegative");
		}

		if (livestockGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= livestockGoodProb)
				AddEvent ("LivestockPositive");
		}
		if (livestockBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= livestockBadProb)
				AddEvent ("LivestockNegative");
		}

		if (comGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= comGoodProb)
				AddEvent ("CommercialPositive");
		}
		if (comBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= comBadProb)
				AddEvent ("CommercialNegative");
		}

		if (indGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= indGoodProb)
				AddEvent ("IndustrialPositive");
		}
		if (indBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= indBadProb)
				AddEvent ("IndustrialNegative");
		}

		if (golfGoodProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= golfGoodProb)
				AddEvent ("GolfCoursePositive");
		}
		if (golfBadProb > 0f) {
			diceRoll = UnityEngine.Random.Range(0.0f,1.0f);
			if (diceRoll <= golfBadProb)
				AddEvent ("GolfCourseNegative");
		}

		//TODO Pick how Events are Added
		//AddEvent("ExtraFood");
		//AddEvent("ExtraFood");
		//AddEvent("ExtraFood");
		//AddEvent("ExtraFood");
	}
}
