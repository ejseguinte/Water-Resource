using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class Water : MonoBehaviour {

	public float actualWater;
	public float estimatedWater;

	private float[] actualWaterArray;
	private float[] estimatedWaterArray;

	// Use this for initialization
	void Start () {
		actualWaterArray = new float[GameManager.maxTurns];
		estimatedWaterArray = new float[GameManager.maxTurns];

		LoadWater();
		UpdateWater(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//TODO Update Load Water to load from file
	private void LoadWater(){
		int year = PlayerPrefsManager.GetYear();
		actualWaterArray[0] = 1000f;
		estimatedWaterArray[0] = 1000f;
	}

	//TODO update to include Difficulty
	//TODO update to use idx instead of 0
	public void UpdateWater(int idx){
		actualWater = actualWaterArray[0];
		estimatedWater = estimatedWaterArray[0];
		estimatedWater = estimatedWater * Difficulty.WaterEstimateCoefficient();
	}



}
