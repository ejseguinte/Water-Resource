using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;
using System.Linq;

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
		//Event events = EventData.GetItem(name);
		DisplayEvent(events);
		events.InstantEffect();
	}

	private void DisplayEvent(Event events)
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
}
