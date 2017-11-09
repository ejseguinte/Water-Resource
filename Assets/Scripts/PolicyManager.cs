using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;
using System.Linq;
using System;

public class PolicyManager : MonoBehaviour {

	#region Private Variables
	PolicyManager policyManager;
	#endregion

	#region Public Variables
	private static Queue<Policy> policyNames;
	#endregion
	// Use this for initialization
	void Start()
	{
		if (policyManager != null)
		{
			Destroy(gameObject);
		}
		else
		{
			GameManager.policyManager = this;
			policyManager = this;
			if(policyNames == null)
				policyNames = new Queue<Policy>();
		}
		
		
		
	}

	public static void AddPolicy(Policy currentPolicy)
	{
		if (currentPolicy.purchased == false)
		{
			GameManager.Money -= currentPolicy.cost;
			currentPolicy.purchased = true;
			policyNames.Enqueue(currentPolicy);
			Debug.Log("Added: " + currentPolicy.guiName);
		}else if(currentPolicy.purchased == true && currentPolicy.counter == 0){
			RemovePolicy(currentPolicy);
			GameManager.Money += currentPolicy.cost;
			currentPolicy.purchased = false;
			Debug.Log("Removed: " + currentPolicy.guiName);
		}
		GameObject.FindObjectOfType<ResrouceDisplay>().Updates();
	}
	
	public static void RemovePolicy(Policy currentPolicy){
		Queue<Policy> temp = new Queue<Policy>();
		while(policyNames.Count > 0){
			Policy current = policyNames.Dequeue();
			if(current != currentPolicy){
				temp.Enqueue(current);
			}
		}

		policyNames = temp;
	}
	
	public static void ApplyPolicy(){
		foreach (Policy current in policyNames){
			current.InstantEffect();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
