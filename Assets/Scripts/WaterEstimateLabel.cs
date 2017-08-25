using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterEstimateLabel : MonoBehaviour {

	private Water water;
	private Text myText;

	// Use this for initialization
	void Start () {
		water = GameObject.FindObjectOfType<Water>();
		myText = GetComponent<Text>();
		myText.text = water.estimatedWater.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = water.estimatedWater.ToString();
	}
}
