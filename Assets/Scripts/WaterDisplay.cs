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

	#region Unity Methods
	// Use this for initialization
	void Start()
	{
		waterReserveValue.text = gameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = gameManager.ExpendedWater.ToString()+"M";
		waterRemainingValue.text = gameManager.RemainingWater.ToString()+"M";
		waterEstimateValue.text = gameManager.EstimateWater.ToString()+"M";
	}

	// Update is called once per frame
	void Update()
	{
		waterReserveValue.text = gameManager.TotalWater.ToString()+"M";
		waterExpenditureValue.text = gameManager.ExpendedWater.ToString()+"M";
		waterRemainingValue.text = gameManager.RemainingWater.ToString()+"M";
		waterEstimateValue.text = gameManager.EstimateWater.ToString()+"M";
	}
	#endregion 
}
