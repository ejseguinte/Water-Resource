using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GroupData{

	private static Dictionary<string, Group> _table = new Dictionary<string, Group>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Group newGroup = new Group(){
			nameID = "TEST",
			guiName = "Test",
			description = "test"
		};

		_table.Add(newGroup.nameID, newGroup);
	}

	public static Group GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		Group temp = null;
		Debug.Log(name);
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return null;
		}

	}
}

[System.Serializable]
public class Group
{

	public enum PolicyType{Agriculture,Urban,Recreational,Ecology};
	public string nameID;
	public string guiName;
	public string description;

}
