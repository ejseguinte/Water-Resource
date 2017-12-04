using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterSlider : MonoBehaviour {
	
	public Slider effect1;
	public Text effect1Title;
	public Slider effect2;
	public Text effect2Title;
	public Slider effect3;
	public Text effect3Title;
	public Slider effect4;
	public Text effect4Title;
	public WaterDisplay display;
	public Text waterDescription;
	public Text maxWater;
	public Text waterAmount;
	
	private LevelManager levelManager;
	private Group group;
	private GroupWater water;
	private Slider waterSlider;
	private float offset;
	
	void Awake () {
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		waterSlider = GetComponent<Slider>();
		group = GroupData.GetItem(LevelManager.groupAttribute);
		if (group == null)
		{
			group = GroupData.GetItem("TEST");
		}
		if (group == null)
		{
			effect1Title.text = "NULL";
			effect2Title.text = "NULL";
			effect3Title.text = "NULL";
			effect4Title.text = "NULL";
		}else{
			effect1Title.text = group.effectID1;
			effect2Title.text = group.effectID2;
			effect3Title.text = group.effectID3;
			effect4Title.text = group.effectID4;
		}
		if (group.recommendedWater <= 0)
		{
			group.effectMultiplier4 = Difficulty.MarketCostCoefficient();
		}
		
	}
	
	// Use this for initialization
	void Start () {
		water = GameManager.GetItem(LevelManager.groupAttribute);
		//Debug.Log(LevelManager.groupAttribute);
		if (water == null)
		{
			water = GameManager.GetItem("TEST");
		}
		
		if (water.waterGiven > 0)
		{
			GameManager.ExpendedWater = GameManager.ExpendedWater - water.waterGiven;
		}
		GameManager.RemainingWater = GameManager.TotalWater - GameManager.ExpendedWater;
		float temp = (GroupData.GetItem(LevelManager.groupAttribute).waterNeed + 1) * 100;
		maxWater.text = temp + "%";
		if (group.recommendedWater <= 0)
		{
			//Seperate Text for the Market 
			float money = Mathf.RoundToInt(GameManager.Money * effect4.value);
			waterDescription.text = "Max Sellable Water: "  + water.waterNeeded.ToString() + "AF\n" + "Money gained: " + money + "AF";
		}	
		else
		{
			waterDescription.text = "Minimum water needed: " + water.waterRecommended.ToString() + "AF\n" + "Total water needed: "  + water.waterNeeded.ToString() + "AF";
		}
		
		offset = water.waterRecommended / water.waterNeeded;
		if (water.waterGiven < 0)		//If the water has been allocated yet
		{
			waterSlider.value = offset;
			waterAmount.text = water.waterRecommended.ToString()+"AF";
		}else{
			waterSlider.value = water.waterGiven / water.waterNeeded;
			waterAmount.text = water.waterGiven.ToString()+"AF";
			if (Mathf.RoundToInt(waterSlider.value * water.waterNeeded) < water.waterRecommended)
			{
				waterAmount.color = Color.red;
			}else{
				waterAmount.color = Color.black;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSliders();
		display.UpdateWaterUsed(waterSlider.value * water.waterNeeded); //TODO convert
		if (group.recommendedWater <= 0)
		{
			//Seperate Text for the Market 
			float money = Mathf.RoundToInt(GameManager.Money * effect4.value);
			waterDescription.text = "Max Sellable Water: "  + water.waterNeeded.ToString() + "AF\n" + "Money gained: " + money + "M";
		}
	}

	private void UpdateSliders(){
		effect1.value = (waterSlider.value - offset) * group.effectMultiplier1;
		effect2.value = (waterSlider.value - offset) * group.effectMultiplier2;
		effect3.value = (waterSlider.value - offset) * group.effectMultiplier3;
		effect4.value = (waterSlider.value - offset) * group.effectMultiplier4;
		waterAmount.text = Mathf.RoundToInt(waterSlider.value * water.waterNeeded).ToString()+"AF";
		if (Mathf.RoundToInt(waterSlider.value * water.waterNeeded) < water.waterRecommended)
		{
			waterAmount.color = Color.red;
		}
		else
		{
			waterAmount.color = Color.black;
		}
	}

	public void Save()
	{
		//Update Water
		water.waterGiven = Mathf.RoundToInt(waterSlider.value * water.waterNeeded);
		GameManager.ExpendedWater += Mathf.RoundToInt(water.waterGiven);
		GameManager.RemainingWater = Mathf.RoundToInt(GameManager.TotalWater - GameManager.ExpendedWater);

		//Update Resource Multipliers
		GameManager.HappinessMultiplier += (effect1.value / 10); //Divided by 10 to make happiness move slower;
		GameManager.PopulationMultiplier += (effect2.value / 1);
		GameManager.FoodMultiplier += (effect3.value / 10);
		GameManager.MoneyMultiplier += (effect4.value / 1);
		levelManager.LoadPreviousLevel();
	}

	public void Reset()
	{
		waterSlider.value = offset;
	}
}
