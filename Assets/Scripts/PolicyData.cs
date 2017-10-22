using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Security.Permissions;

public class PolicyData{

	private static Dictionary<string, Policy> _table = new Dictionary<string, Policy>(); //Key  is Year and Month ie 201701: January of 2017

	public static void LoadItemsData(){
		Policy policy = new Policy()
		{
			nameID = "test",
			guiName = "Test",
			description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam maximus erat sed elit tristique hendrerit. Fusce dictum tortor neque, id vulputate erat tristique at. Aliquam vestibulum tincidunt odio a ultrices. Nullam id iaculis nisl. Ut placerat pharetra vestibulum. Vestibulum quis pharetra magna. Vivamus dapibus mauris quis nisi eleifend hendrerit ac at nulla. Sed et magna eget mauris vehicula finibus. Donec nec venenatis erat."
		};
		_table.Add(policy.nameID, policy);
		
		Policy policy1 = new Policy()
		{
			nameID = "test1",
			guiName = "Test",
			description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam maximus erat sed elit tristique hendrerit. Fusce dictum tortor neque, id vulputate erat tristique at. Aliquam vestibulum tincidunt odio a ultrices. Nullam id iaculis nisl. Ut placerat pharetra vestibulum. Vestibulum quis pharetra magna. Vivamus dapibus mauris quis nisi eleifend hendrerit ac at nulla. Sed et magna eget mauris vehicula finibus. Donec nec venenatis erat."
		};
		_table.Add(policy1.nameID, policy1);
		
		Policy policy2 = new Policy()
		{
			nameID = "test2",
			guiName = "Test",
			description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam maximus erat sed elit tristique hendrerit. Fusce dictum tortor neque, id vulputate erat tristique at. Aliquam vestibulum tincidunt odio a ultrices. Nullam id iaculis nisl. Ut placerat pharetra vestibulum. Vestibulum quis pharetra magna. Vivamus dapibus mauris quis nisi eleifend hendrerit ac at nulla. Sed et magna eget mauris vehicula finibus. Donec nec venenatis erat."
		};
		_table.Add(policy2.nameID, policy2);
		
		
	}

	public static Policy GetItem(string name){
		if (_table.Count == 0){
			LoadItemsData();
		}
		Policy temp = null;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
			return null;
		}

	}
	
	public static Array GetKeys()
	{
		if (_table.Count == 0){
			LoadItemsData();
		}
		return _table.Keys.ToArray();
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
