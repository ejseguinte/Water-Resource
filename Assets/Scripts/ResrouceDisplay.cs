using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResrouceDisplay : MonoBehaviour
{

	#region Public Variables
	public Text happinessValue;
	public Text foodValue;
	public Text moneyValue;
	public Text populationValue;
	public Text farmValue;
	#endregion

	#region Unity Methods
	// Use this for initialization
	void Start()
	{
		happinessValue.text = GameManager.Happiness.ToString()+"%";
		foodValue.text = GameManager.Food.ToString();
		moneyValue.text = "$"+GameManager.Money.ToString();
		populationValue.text = GameManager.Population.ToString()+"M";
		farmValue.text = GameManager.Farms.ToString()+"M";
	}

	// Update is called once per frame
	void Update()
	{
		happinessValue.text = GameManager.Happiness.ToString()+"%";
		foodValue.text = GameManager.Food.ToString();
		moneyValue.text = "$"+GameManager.Money.ToString()+"M";
		populationValue.text = GameManager.Population.ToString()+"M";
		farmValue.text = GameManager.Farms.ToString()+"M";
	}
	
	public void Updates(){
		Update();
	}
	#endregion 
}
