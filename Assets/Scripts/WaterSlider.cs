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
	
	private GameManager gameManager;
	private LevelManager levelManager;
	private Group group;
	private GroupWater water;
	private Slider waterSlider;
	private float offset;
	
	void Awake () {
		gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
			effect1Title.text = "Happiness";
			effect2Title.text = "Population";
			effect3Title.text = "Food Growth";
			effect4Title.text = "Income";
		}
		
	}
	
	// Use this for initialization
	void Start () {
		water = GameManager.GetItem(LevelManager.groupAttribute);
		if (water == null)
		{
			water = GameManager.GetItem("TEST");
		}
		
		if (water.waterGiven > 0)
		{
			gameManager.ExpendedWater -= water.waterGiven;
		}
		gameManager.RemainingWater = gameManager.TotalWater - gameManager.ExpendedWater;
		
		maxWater.text = water.waterNeeded.ToString() + "M";
		waterDescription.text = "Minimum water needed: " + water.waterRecommended.ToString() + "M\n" + "Total water needed: "  + water.waterNeeded.ToString() + "M";
		offset = water.waterRecommended / water.waterNeeded;
		if (water.waterGiven < 0)
		{
			waterSlider.value = offset;
		}else{
			waterSlider.value = water.waterGiven / water.waterNeeded;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSliders();
		display.UpdateWaterUsed(waterSlider.value * water.waterNeeded); //TODO convert
	}

	private void UpdateSliders(){
		effect1.value = (waterSlider.value - offset) * group.effectMultiplier1;
		effect2.value = (waterSlider.value - offset) * group.effectMultiplier2;
		effect3.value = (waterSlider.value - offset) * group.effectMultiplier3;
		effect4.value = (waterSlider.value - offset) * group.effectMultiplier4;
	}

	public void Save()
	{
		water.waterGiven = waterSlider.value * water.waterNeeded;
		gameManager.ExpendedWater += water.waterGiven;
		gameManager.RemainingWater = gameManager.TotalWater - gameManager.ExpendedWater;
		Debug.Log(gameManager.ExpendedWater);
		levelManager.LoadPreviousLevel();
	}

	public void Reset()
	{
		waterSlider.value = offset;
	}
}
