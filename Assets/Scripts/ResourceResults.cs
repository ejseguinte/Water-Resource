using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceResults : MonoBehaviour {
	public Text happinessValue;
	public Text foodValue;
	public Text moneyValue;
	public Text populationValue;
	public Text farmsValue;

	// Use this for initialization
	void Start () {
		if(happinessValue!= null)
			happinessValue.text = GetHappiness().ToString() + "%";
		if(foodValue!= null)
			foodValue.text = GetFood().ToString() + "";
		if(moneyValue!= null)
			moneyValue.text = GetMoney().ToString() + "M";
		if(populationValue!= null)
			populationValue.text = GetPopulation().ToString() + "M";
		if(farmsValue!= null)
			farmsValue.text = GetFarms().ToString() + "M";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	float GetHappiness()
	{
		float val = (GameManager.Happiness + GameManager.HappinessEffect) * GameManager.HappinessMultiplier;
		val -= GameManager.Happiness;
		return Mathf.RoundToInt(val); 
	}

	float GetFood()
	{
		float val = GameManager.Farms * Difficulty.FoodProductionCoefficient() * GameManager.FoodMultiplier + GameManager.FoodEffect;
		val -= GameManager.Food;
		return Mathf.RoundToInt(val); 
	}

	float GetMoney()
	{
		float val = (GameManager.Money + GameManager.MoneyEffect) * GameManager.MoneyMultiplier;
		val -= GameManager.Money;
		return Mathf.RoundToInt(val); 
	}

	float GetPopulation()
	{
		float val = (GameManager.Population + GameManager.PopulationEffect) * GameManager.PopulationMultiplier;
		val -= GameManager.Population;
		return Mathf.RoundToInt(val); 
	}
	
	float GetFarms()
	{
		float val = (GameManager.Farms + GameManager.FarmsEffect) * GameManager.FarmsMultiplier;
		val -= GameManager.Farms;
		return Mathf.RoundToInt(val); 
	}
}
