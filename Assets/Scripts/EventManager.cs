using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;

public class EventManager : MonoBehaviour {

	#region Private Variables
	EventManager eventManager;
	#endregion

	#region Public Variables
	public static Queue<string> eventNames;
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
			SetEvent(name);
			return true;
		}

		return false;

	}
	
	private void SetEvent(string name){
		Event events = EventData.GetItem(name);
		string[] text = { events.guiName, events.description};
		GameManager.tooltip.SetEvent(text);
		events.InstantEffect();
	}

	public void CloseEvent()
	{
		GameManager.EventDisplayed = false;
		GameManager.tooltip.HideTooltip();
		if(!SetNextEvent())
			GameManager.gameManager.NextState();

	}
}
