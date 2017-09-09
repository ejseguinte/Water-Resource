using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResrouceDisplay : MonoBehaviour
{

	#region Public Variables
	public GameManager gameManager;
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
		happinessValue.text = gameManager.Happiness.ToString()+"%";
		foodValue.text = gameManager.Food.ToString();
		moneyValue.text = "$"+gameManager.Money.ToString();
		populationValue.text = gameManager.Population.ToString()+"M";
		farmValue.text = gameManager.Farms.ToString()+"M";
	}

	// Update is called once per frame
	void Update()
	{
		happinessValue.text = gameManager.Happiness.ToString()+"%";
		foodValue.text = gameManager.Food.ToString();
		moneyValue.text = "$"+gameManager.Money.ToString()+"M";
		populationValue.text = gameManager.Population.ToString()+"M";
		farmValue.text = gameManager.Farms.ToString()+"M";
	}
	#endregion 
}
