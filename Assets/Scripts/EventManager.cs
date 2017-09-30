using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

	#region Private Variables
	EventManager eventManager;
	public delegate void CurrentDelegate();
	CurrentDelegate currentDelegate;
	#endregion

	#region Public Variables

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
		}
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetEvent(string name){
		Event events = EventData.GetItem(name);
		string[] text = { events.guiName, events.description};
		GameManager.tooltip.SetEvent(text);
		events.InstantEffect();
	}

	public void CloseEvent()
	{
		GameManager.EventDisplayed = false;
		GameManager.tooltip.HideTooltip();

	}
}
