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
		return previousEvents.ToArray();
	}

	public void GetEvents()
	{
		float domBadProb = (GameManager.GetItem ("Domestic").waterNeeded - GameManager.GetItem ("Domestic").waterGiven) / GameManager.GetItem ("Domestic").waterNeeded;
		float domGoodProb = (GameManager.GetItem ("Domestic").waterGiven - GameManager.GetItem ("Domestic").waterNeeded) / GameManager.GetItem ("Domestic").waterNeeded;
		Debug.Log (domBadProb);
		Debug.Log (domGoodProb);

		float cropBadProb = (GameManager.GetItem ("Crops").waterNeeded - GameManager.GetItem ("Crops").waterGiven) / GameManager.GetItem ("Crops").waterNeeded;
		float cropGoodProb = (GameManager.GetItem ("Crops").waterGiven - GameManager.GetItem ("Crops").waterNeeded) / GameManager.GetItem ("Crops").waterNeeded;

		float livestockBadProb = (GameManager.GetItem ("Livestock").waterNeeded - GameManager.GetItem ("Livestock").waterGiven) / GameManager.GetItem ("Livestock").waterNeeded;
		float livestockGoodProb = (GameManager.GetItem ("Livestock").waterGiven - GameManager.GetItem ("Livestock").waterNeeded) / GameManager.GetItem ("Livestock").waterNeeded;

		float comBadProb = (GameManager.GetItem ("Commercial").waterNeeded - GameManager.GetItem ("Commercial").waterGiven) / GameManager.GetItem ("Commercial").waterNeeded;
		float comGoodProb = (GameManager.GetItem ("Commercial").waterGiven - GameManager.GetItem ("Commercial").waterNeeded) / GameManager.GetItem ("Commercial").waterNeeded;

		float indBadProb = (GameManager.GetItem ("Industrial").waterNeeded - GameManager.GetItem ("Industrial").waterGiven) / GameManager.GetItem ("Industrial").waterNeeded;
		float indGoodProb = (GameManager.GetItem ("Industrial").waterGiven - GameManager.GetItem ("Industrial").waterNeeded) / GameManager.GetItem ("Industrial").waterNeeded;

		float golfBadProb = (GameManager.GetItem ("Golf Courses").waterNeeded - GameManager.GetItem ("Golf Courses").waterGiven) / GameManager.GetItem ("Golf Courses").waterNeeded;
		float golfGoodProb = (GameManager.GetItem ("Golf Courses").waterGiven - GameManager.GetItem ("Golf Courses").waterNeeded) / GameManager.GetItem ("Golf Courses").waterNeeded;

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
