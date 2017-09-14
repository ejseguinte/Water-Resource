using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyData{

	private static Dictionary<string, Policy> _table; //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){

	}

	public static Policy GetItem(string name){
		Policy temp = null;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return null;
		}

	}
}

[System.Serializable]
public class Policy
{

	public enum PolicyType{Agriculture,Urban,Recreational,Ecology};
	public string nameID;
	public string guiName;
	public string description;

}
