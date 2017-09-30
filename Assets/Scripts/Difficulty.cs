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
	public static float HappinessCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
				return 1.01f;
			case 2:
				return 1f;
			case 3:
				return .95f;
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
				return 20f;
			case 2:
				return 15;
			case 3:
				return 10f;
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
				return 25f;
			case 2:
				return 30f;
			case 3:
				return 35f;
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
				return 1.1f;
			case 2:
				return 1.2f;
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
				return 2f;
			case 2:
				return 1.5f;
			case 3:
				return 1.1f;
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion

	#region Water Estimate

	public static float WaterEstimateCoefficient(){
		switch(PlayerPrefsManager.GetDifficulty()){
			case 1:
				return Random.Range(.9f, 1.1f);
			case 2:
				return Random.Range(.8f, 1.2f);
			case 3:
				return Random.Range(.7f, 1.3f);
			default:
				Debug.LogError("Difficulty not set correctly: " + PlayerPrefsManager.GetDifficulty());
				return 0f;
		}
	}
	#endregion
}
