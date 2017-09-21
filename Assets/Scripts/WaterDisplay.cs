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
		waterUsed = gameManager.ExpendedWater;
		waterLeft = gameManager.RemainingWater;
		waterReserve = gameManager.TotalWater;
		waterUsed = gameManager.ExpendedWater;
		waterLeft = gameManager.RemainingWater;
		waterReserveValue.text = gameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = gameManager.ExpendedWater.ToString()+"M";
		waterRemainingValue.text = gameManager.RemainingWater.ToString()+"M";
		waterEstimateValue.text = gameManager.EstimateWater.ToString()+"M";

		
	}

	// Update is called once per frame
	void Update()
	{
		waterReserveValue.text = gameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = waterUsed.ToString()+"M";
		waterRemainingValue.text = waterLeft.ToString()+"M";
		waterEstimateValue.text = gameManager.EstimateWater.ToString()+"M";
	}
	#endregion

	public void UpdateWaterUsed(float amount){ 
		waterUsed = gameManager.ExpendedWater + amount;
		waterUsed = Mathf.RoundToInt(waterUsed);
		waterLeft = gameManager.TotalWater - waterUsed;
		waterLeft = Mathf.RoundToInt(waterLeft);
	}
	
	
}
