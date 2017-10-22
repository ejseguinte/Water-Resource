using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterDisplay : MonoBehaviour {

	#region Public Variables
	public GameManager gameManager;
	public Text waterReserveValue;
	public Text waterExpenditureValue;
	public Text waterRemainingValue;
	public Text waterEstimateValue;
	
	#endregion

	#region Private Variables
	private float waterUsed;
	private float waterLeft;
	public float waterReserve;
	#endregion

	#region Unity Methods
	// Use this for initialization
	void Start()
	{
		waterUsed = GameManager.ExpendedWater;
		waterLeft = GameManager.RemainingWater;
		waterReserve = GameManager.TotalWater;
		waterUsed = GameManager.ExpendedWater;
		waterLeft = GameManager.RemainingWater;
		waterReserveValue.text = GameManager.TotalWater.ToString()+"AF";
		waterExpenditureValue.text = GameManager.ExpendedWater.ToString()+"AF";
		waterRemainingValue.text = GameManager.RemainingWater.ToString()+"AF";
		waterEstimateValue.text = GameManager.EstimateWater.ToString()+"AF";

		
	}

	// Update is called once per frame
	void Update()
	{
		waterReserveValue.text = GameManager.TotalWater.ToString()+"AF";
		waterExpenditureValue.text = waterUsed.ToString()+"AF";
		waterRemainingValue.text = waterLeft.ToString()+"AF";
		waterEstimateValue.text = GameManager.EstimateWater.ToString()+"AF";
	}
	#endregion

	public void UpdateWaterUsed(float amount){ 
		waterUsed = GameManager.ExpendedWater + amount;
		waterUsed = Mathf.RoundToInt(waterUsed);
		waterLeft = GameManager.TotalWater - waterUsed;
		waterLeft = Mathf.RoundToInt(waterLeft);
	}
	
	
}
