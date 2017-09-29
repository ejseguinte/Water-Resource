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
		setColor(happinessValue, GetHappiness());
		if(foodValue!= null)
			foodValue.text = GetFood().ToString() + "";
		setColor(foodValue, GetFood());
		if(moneyValue!= null)
			moneyValue.text = GetMoney().ToString() + "M";
		setColor(moneyValue, GetMoney());
		if(populationValue!= null)
			populationValue.text = GetPopulation().ToString() + "M";
		setColor(populationValue, GetPopulation());
		if(farmsValue!= null)
			farmsValue.text = GetFarms().ToString() + "M";
		setColor(farmsValue, GetHappiness());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setColor(Text field, float val)
	{
		if (val < 0)
		{
			field.color = Color.red;
		}
		else
		{
			field.color = Color.green;
		}

	}

	float GetHappiness()
	{
		float val = (GameManager.Happiness + GameManager.HappinessEffect) * GameManager.HappinessMultiplier;
		val -= GameManager.Happiness;
		return Mathf.RoundToInt(val); 
	}

	float GetFood()
	{
		Debug.Log("Farms: "+ GameManager.Farms);
		Debug.Log("Food Production: "+ Difficulty.FoodProductionCoefficient());
		Debug.Log("Food Multiplier: "+ GameManager.FoodMultiplier);
		Debug.Log("Food Effect: "+ GameManager.FoodEffect);
		Debug.Log("Food: "+ GameManager.Food);
		float val = GameManager.Farms * Difficulty.FoodProductionCoefficient() * GameManager.FoodMultiplier + GameManager.FoodEffect;
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
