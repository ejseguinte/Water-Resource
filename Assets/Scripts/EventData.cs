using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData{

	private static Dictionary<string, Event> _table; //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){

	}

	public static Event GetItem(string name){
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

}
