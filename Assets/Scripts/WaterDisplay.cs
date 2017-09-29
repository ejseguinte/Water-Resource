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
		waterReserveValue.text = GameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = GameManager.ExpendedWater.ToString()+"M";
		waterRemainingValue.text = GameManager.RemainingWater.ToString()+"M";
		waterEstimateValue.text = GameManager.EstimateWater.ToString()+"M";

		
	}

	// Update is called once per frame
	void Update()
	{
		waterReserveValue.text = GameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = waterUsed.ToString()+"M";
		waterRemainingValue.text = waterLeft.ToString()+"M";
		waterEstimateValue.text = GameManager.EstimateWater.ToString()+"M";
	}
	#endregion

	public void UpdateWaterUsed(float amount){ 
		waterUsed = GameManager.ExpendedWater + amount;
		waterUsed = Mathf.RoundToInt(waterUsed);
		waterLeft = GameManager.TotalWater - waterUsed;
		waterLeft = Mathf.RoundToInt(waterLeft);
	}
	
	
}
