using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterResults : MonoBehaviour {

	public Text RemainingWater;
	public Text EstimatedWater;
	public Text ActualAmount;
	public Text TotalAmount;
	// Use this for initialization
	void Start () {
		float[] waterArray = GameManager.ActualWaterArray;
		RemainingWater.text = GameManager.RemainingWater.ToString() + "M";
		EstimatedWater.text = GameManager.EstimateWater.ToString() + "M";
		ActualAmount.text = waterArray[GameManager.turnCounter].ToString() + "M";
		setColor(ActualAmount, waterArray[GameManager.turnCounter], GameManager.EstimateWater);
		TotalAmount.text = (waterArray[GameManager.turnCounter] + GameManager.RemainingWater).ToString() + "M";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void setColor(Text field, float actualValue, float estimateValue)
	{
		if (actualValue < estimateValue)
		{
			field.color = Color.red;
		}
		else
		{
			field.color = Color.green;
		}

	}
}
