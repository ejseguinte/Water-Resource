using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

	#region Static
	public static int maxTurns = 12;
	public static GameManager gameManager = null;
	public Text helper;
	#endregion

	#region Public Variables
	public static int turnCounter = 1;
	#endregion

	#region Private Variables
	private static int menuScreenBuildIndex = 1; //the menu screen's index in your Build Settings
	private LevelManager levelManager;
	private float initialFixedTimeDeltaTime;
	private GameState state = GameState.Allocate;

	//Resources
	private static float food 					= 2000;
	private static float happiness 				= 100;
	private static float money 					= 100;
	private static float population				= 40;
	private static float farms 					= 40;
	private static float foodMultiplier 		= 1.0f;
	private static float happinessMultiplier 	= 1.0f;
	private static float moneyMultiplier 		= 1.0f;
	private static float populationMultiplier 	= 1.0f;
	private static float farmsMultiplier		= 1.0f;
	private static float foodEffect 			= 0;
	private static float happinessEffect 		= 0;
	private static float moneyEffect			= 0;
	private static float populationEffect 		= 0;
	private static float farmsEffect 			= 0;


	//Water
	private static float[] actualWaterArray;
	private static float totalWater;
	private static float expendedWater;
	private static float remainingWater;
	private static float estimateWater;

	//Group Water Needs
	private static Array groups;
	private static Dictionary<string, GroupWater> _table = new Dictionary<string, GroupWater>();
	#endregion

	#region Enums
	public enum GameState { Allocate, Event, End, Pause };
	#endregion

	#region Unity Methods
	void OnEnable()
	{
		turnCounter = 1;
	}

	void Awake()
	{
		if (gameManager != null)
		{
			Destroy(gameObject);
		}
		else
		{
			gameManager = this;
			ResetResources();
			GameObject.DontDestroyOnLoad(gameObject);
		}
		SceneManager.activeSceneChanged += DestroyOnMenuScreen;
	}

	void DestroyOnMenuScreen(Scene oldScene, Scene newScene)
	{

		if (newScene.buildIndex == menuScreenBuildIndex) //could compare Scene.name instead
		{
			gameManager = null;
			Destroy(gameObject); //change as appropriate
		}
	}

	// Use this for initialization
	void Start()
	{
		actualWaterArray = new float[maxTurns];
		initialFixedTimeDeltaTime = Time.fixedDeltaTime;
		groups = GroupData.GetKeys();
		LoadWater();            //Loads total water data
		UpdateWater(turnCounter - 1);
		LoadWaterData();        //Loads water Data for Groups


		//helper.text = " ";

	}

	// Update is called once per frame
	void Update()
	{

	}
	#endregion

	#region State Control

	public string GetState()
	{
		switch (state)
		{
			case GameState.Allocate:
				return "Allocation";
			case GameState.Event:
				return "Event";
			case GameState.End:
				return "Results";
			default:
				Debug.Log(state);
				return "Error";
		}
	}

	public void NextState()
	{
		if (CheckAllWaterAllocation())
		{
			switch (state)
			{
				case GameState.Allocate:
					EndAllocation();
					break;
				case GameState.Event:
					EndEvent();
					break;
				case GameState.End:
					NextTurn();
					break;
				default:
					levelManager = GameObject.FindObjectOfType<LevelManager>() as LevelManager;
					levelManager.LoadLevel("01a Start Menu");
					break;
			}
		}
	}

	private void EndAllocation()
	{
		state = GameState.Event;
		ResourceBeforeEffects();
	}

	private void EndEvent()
	{
		state = GameState.End;
		levelManager = GameObject.FindObjectOfType<LevelManager>() as LevelManager;
		levelManager.LoadLevel("02b Game Report");
	}

	private void NextTurn()
	{
		if (turnCounter >= maxTurns)
		{
			levelManager = GameObject.FindObjectOfType<LevelManager>() as LevelManager;
			levelManager.LoadLevel("03 Final Results");
		}
		else
		{
			turnCounter++;
			
			ResourceAfterEffects();
			UpdateResources();
			ResetResources();
			
			state = GameState.Allocate;
			UpdateWater(turnCounter - 1);
			LoadWaterData();
			
			levelManager = GameObject.FindObjectOfType<LevelManager>() as LevelManager;
			levelManager.LoadLevel("02a Game");
		}
	}

	#endregion

	#region Pause Methods

	public void pause()
	{
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	public void resume()
	{
		Time.timeScale = 1;
		Time.fixedDeltaTime = initialFixedTimeDeltaTime;
	}
	#endregion

	#region Resource Variables
	/*
	*	Hold all publicly availble functions.
	*/
	public static float Food
	{
		get
		{
			return Mathf.RoundToInt(food);
		}

		set
		{
			food = value;
		}
	}

	public static float Happiness
	{
		get
		{
			return Mathf.RoundToInt(happiness);
		}

		set
		{
			happiness = value;
			if (happiness < 0) happiness = 0;
			if (happiness > 100) happiness = 100;
		}
	}

	public static float Money
	{
		get
		{
			return Mathf.RoundToInt(money);
		}

		set
		{
			money = value;
			if (money < 0) money = 0;
		}
	}

	public static float Population
	{
		get
		{
			return Mathf.RoundToInt(population);
		}

		set
		{
			population = value;
			if (population < 0) population = 0;
		}
	}

	public static float Farms
	{
		get
		{
			return Mathf.RoundToInt(farms);
		}

		set
		{
			farms = value;
			if (farms < 0) farms = 0;
		}
	}

	public static int TurnCounter
	{
		get
		{
			return turnCounter;
		}

		set
		{
			turnCounter = value;
		}
	}

	public static float TotalWater
	{
		get
		{
			return Mathf.RoundToInt(totalWater);
		}

		set
		{
			totalWater = Mathf.RoundToInt(value);
		}
	}

	public static float ExpendedWater
	{
		get
		{

			return Mathf.RoundToInt(expendedWater);
		}

		set
		{
			expendedWater = Mathf.RoundToInt(value);
		}
	}

	public static float RemainingWater
	{
		get
		{
			return Mathf.RoundToInt(remainingWater);
		}

		set
		{
			remainingWater = Mathf.RoundToInt(value);
		}
	}

	public static float EstimateWater
	{
		get
		{
			return Mathf.RoundToInt(estimateWater);
		}

		set
		{
			estimateWater = Mathf.RoundToInt(value);
		}
	}

	public static float FoodMultiplier
	{
		get
		{
			return foodMultiplier;
		}

		set
		{
			foodMultiplier = value;
		}
	}

	public static float HappinessMultiplier
	{
		get
		{
			return happinessMultiplier;
		}

		set
		{
			happinessMultiplier = value;
		}
	}

	public static float MoneyMultiplier
	{
		get
		{
			return moneyMultiplier;
		}

		set
		{
			moneyMultiplier = value;
		}
	}

	public static float PopulationMultiplier
	{
		get
		{
			return populationMultiplier;
		}

		set
		{
			populationMultiplier = value;
		}
	}

	public static float FarmsMultiplier
	{
		get
		{
			return farmsMultiplier;
		}

		set
		{
			farmsMultiplier = value;
		}
	}

	public static float FoodEffect
	{
		get
		{
			return foodEffect;
		}

		set
		{
			foodEffect = value;
		}
	}

	public static float HappinessEffect
	{
		get
		{
			return happinessEffect;
		}

		set
		{
			happinessEffect = value;
		}
	}

	public static float MoneyEffect
	{
		get
		{
			return moneyEffect;
		}

		set
		{
			moneyEffect = value;
		}
	}

	public static float PopulationEffect
	{
		get
		{
			return populationEffect;
		}

		set
		{
			populationEffect = value;
		}
	}

	public static float FarmsEffect
	{
		get
		{
			return farmsEffect;
		}

		set
		{
			farmsEffect = value;
		}
	}

	public static float[] ActualWaterArray
	{
		get
		{
			return actualWaterArray;
		}

		set
		{
			actualWaterArray = value;
		}
	}
	#endregion

	#region Water Need Functions
	private void LoadWater()
	{
		actualWaterArray = WaterData.GetItem(PlayerPrefsManager.GetYear().ToString());
	}

	public void UpdateWater(int idx)
	{
		TotalWater = actualWaterArray[idx] + RemainingWater;
		if (idx < 11)
			EstimateWater = actualWaterArray[idx + 1] * Difficulty.WaterEstimateCoefficient();
		else
		{
			EstimateWater = actualWaterArray[0] * Difficulty.WaterEstimateCoefficient();
		}
		EstimateWater = Mathf.RoundToInt(EstimateWater);
		ExpendedWater = 0;
		RemainingWater = Mathf.RoundToInt(totalWater);
	}
	/*
	*	Used to pull data from _table that holds water information
	*/
	public static GroupWater GetItem(string name)
	{
		GroupWater temp = null;
		if (_table.TryGetValue(name, out temp))
		{
			return temp;
		}
		else
		{
			return null;
		}

	}

	/*
	*	Either creates GroupWater entries in _table or edits the currents ones with update information.
	*	Also resets expendedWater to 0 and sets remainingWater to totalWater
	* 	waterGiven = -1f is used to see if the group has been given any water
	*/
	void LoadWaterData()
	{
		foreach (string key in groups)
		{
			GroupWater temp = null;
			if (_table.TryGetValue(key, out temp))
			{
				temp.waterRecommended = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).recommendedWater);
				temp.waterNeeded = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).waterNeed);
				temp.waterGiven = -1f;
			}
			else
			{
				temp = new GroupWater()
				{
					waterRecommended = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).recommendedWater),
					waterNeeded = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).waterNeed),
					waterGiven = -1f
				};
				_table.Add(key, temp);
			}
			if (temp.waterRecommended == 0)
			{
				temp.waterGiven = 0f;
				temp.waterNeeded = TotalWater;
			}
		}
	}

	/*
	*	Used to check to if water has been allocated to all groups and checks to see if too much water has been spent
	*/
	bool CheckAllWaterAllocation()
	{
		foreach (string key in groups)
		{
			if (!CheckWaterAllocation(key))
			{
				Debug.Log("Not all Groups have been Allocated Water");
				return false;
			}
		}
		if (remainingWater < 0)
		{
			Debug.Log("Too much water has been allocated.");
			return false;
		}
		return true;
	}

	public bool CheckWaterAllocation(string key)
	{
		GroupWater temp = null;
		if (_table.TryGetValue(key, out temp))
		{
			if (temp.waterGiven < 0f)
			{
				//Debug.Log(key + " has not been Allocated Water");
				return false;

			}
		}
		else
		{
			//Debug.LogError("Groups not loaded properly. Missing: " + key);
		}
		return true;
	}
	#endregion

	#region Resource Management
	private static void ResetResources()
	{
		FoodMultiplier 				= 1;
		HappinessMultiplier 		= Difficulty.HappinessCoefficient();
		MoneyMultiplier	 			= 1;
		PopulationMultiplier 		= Difficulty.PopulationGrowthCoefficient();
		FarmsMultiplier 			= 1.1f;

		FoodEffect 					= 0;
		HappinessEffect 			= 0;
		MoneyEffect 				= 0;
		PopulationEffect 			= 0;
		FarmsEffect 				= 0;

	}
	
	//Called after ResourceAfterEffects
	private static void UpdateResources()
	{
		//if (happiness == 0) happiness = 1;
		happiness *= happinessMultiplier;
		//if (money == 0) money = 1;
		money *= moneyMultiplier;
		//if (population == 0) population = 1;
		population *= populationMultiplier;
		//if (farms == 0) farms = 1;
		farms *= farmsMultiplier;
	}

	private static void ResourceBeforeEffects()
	{
		food += (Population * Difficulty.FoodRequriedCoefficient()) * -1;
		//Checks to see if there is enough food
		if (food < 0)
		{
			NotEnoughFood();
			food = 0;
		}
	}

	private static void ResourceAfterEffects()
	{
		food += farms * Difficulty.FoodProductionCoefficient() * foodMultiplier + foodEffect;
		happiness += happinessEffect;
		money += moneyEffect;
		population += populationEffect;
		farms += farmsEffect;
		
	}

	private static void NotEnoughFood()
	{

		populationEffect += (food / Difficulty.FoodRequriedCoefficient());
		HappinessEffect += (food/ Difficulty.FoodRequriedCoefficient());
		Debug.Log("Starvation has Occured. Population reduced by: " + populationEffect);
	}

	
	#endregion
}

[System.Serializable]
public class GroupWater
{
	public float waterRecommended;  //Minimum water needed
	public float waterNeeded;       //Max amount of water needed
	public float waterGiven;        //Water given to group

}
