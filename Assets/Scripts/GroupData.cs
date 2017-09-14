using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupData{

	private static Dictionary<string, Group> _table; //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){

	}

	public static Group GetItem(string name){
		Group temp = null;
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
