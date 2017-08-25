using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterActualLabel: MonoBehaviour {

	private Water water;
	private Text myText;

	// Use this for initialization
	void Start () {
		water = GameObject.FindObjectOfType<Water>();
		myText = GetComponent<Text>();
		myText.text = water.actualWater.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = water.actualWater.ToString();
	}
}
