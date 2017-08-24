using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region Happiness
	//TODO Set all diffculties
	public static float HappinessCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
			case 2:
			case 3:
				return 1f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

	#region Food Production

	public static float FoodProductionCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
			case 2:
			case 3:
				return 1f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

	#region Food Required

	public static float FoodRequriedCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
			case 2:
			case 3:
				return 1f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

	#region Population Growth

	public static float PopulationGrowthCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
			case 2:
			case 3:
				return 1.3f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

	#region Market Cost

	public static float MarketCostCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
			case 2:
			case 3:
				return 1.3f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

}
