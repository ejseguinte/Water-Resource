using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Permissions;

public class EventData{

	private static Dictionary<string, Event> _table = new Dictionary<string, Event>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Event newGroup = new Event()
		{
			nameID = "ExtraFood",
			guiName = "Extra Food",
			description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam maximus erat sed elit tristique hendrerit. Fusce dictum tortor neque, id vulputate erat tristique at. Aliquam vestibulum tincidunt odio a ultrices. Nullam id iaculis nisl. Ut placerat pharetra vestibulum. Vestibulum quis pharetra magna. Vivamus dapibus mauris quis nisi eleifend hendrerit ac at nulla. Sed et magna eget mauris vehicula finibus. Donec nec venenatis erat.",
			turn = 0,
			foodMultiplier = 1
			
			
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
	public int turn;
	public float foodEffect;
	public float foodMultiplier;

	public void InstantEffect()
	{
		GameManager.Food += foodEffect;
		GameManager.FoodMultiplier += foodMultiplier;
	}

	public Event Clone()
	{
		Event newGroup = new Event()
		{
			nameID = this.nameID,
			guiName = this.guiName,
			description = this.description,
			turn = this.turn,
			foodMultiplier = this.foodMultiplier
			
		};
		return newGroup;
	}

}
