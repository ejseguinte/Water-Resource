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
	public int turnCounter = 1;
	#endregion

	#region Private Variables
	private static int menuScreenBuildIndex = 1; //the menu screen's index in your Build Settings
	private LevelManager levelManager;
	private float initialFixedTimeDeltaTime;
	private GameState state = GameState.Allocate;
	
	//Resources
	private static int food = 1000;
	private static int happiness = 100;
	private static int money = 1000;
	private static int population = 1000;
	private static int farms = 1000;

	//Water
	private static float[] actualWaterArray;
	private static float[] estimatedWaterArray;
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
	void Awake()
	{
		if (gameManager != null)
		{
			Destroy(gameObject);
		}
		else
		{
			gameManager = this;
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
		estimatedWaterArray = new float[maxTurns];
		initialFixedTimeDeltaTime = Time.fixedDeltaTime;
		groups = GroupData.GetKeys();
		LoadWater();			//Loads total water data
		UpdateWater(turnCounter-1);
		LoadWaterData(); 		//Loads water Data for Groups
		
		
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
		if(CheckWaterAllocation()){
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
			UpdateWater(turnCounter-1);
			LoadWaterData();
			state = GameState.Allocate;
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

	#region Resource Management
	/*
	*	Hold all publicly availble functions.
	*/
	public int Food
	{
		get
		{
			return food;
		}

		set
		{
			food = value;
			if (food < 0) food = 0;
		}
	}

	public int Happiness
	{
		get
		{
			return happiness;
		}

		set
		{
			happiness = value;
			if (happiness < 0) happiness = 0;
			if (happiness > 100) happiness = 100;
		}
	}

	public int Money
	{
		get
		{
			return money;
		}

		set
		{
			money = value;
			if (money < 0) money = 0;
		}
	}

	public int Population
	{
		get
		{
			return population;
		}

		set
		{
			population = value;
			if (population < 0) population = 0;
		}
	}

	public int Farms
	{
		get
		{
			return farms;
		}

		set
		{
			farms = value;
			if (farms < 0) farms = 0;
		}
	}

	public int TurnCounter
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

	public float TotalWater
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

	public float ExpendedWater
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

	public float RemainingWater
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

	public float EstimateWater
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
	#endregion

	#region Water Need Equations
	//TODO Update Load Water to load from file
	private void LoadWater(){
		int year = PlayerPrefsManager.GetYear();
		actualWaterArray[0] = 1000f;
		estimatedWaterArray[0] = 1000f;
	}

	//TODO update to include Difficulty
	//TODO update to use idx instead of 0
	public void UpdateWater(int idx){
		TotalWater = actualWaterArray[0];
		EstimateWater = estimatedWaterArray[0]* Difficulty.WaterEstimateCoefficient();
		ExpendedWater = 0;	
		RemainingWater = Mathf.RoundToInt(totalWater);
	}
	/*
	*	Used to pull data from _table that holds water information
	*/
	public static GroupWater GetItem(string name){
		GroupWater temp = null;
		if(_table.TryGetValue(name, out temp)){
			return temp;
		}else{
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
				temp.waterNeeded = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).totalWater);
				temp.waterGiven = -1f;
			}
			else
			{
				temp = new GroupWater()
				{
					waterRecommended = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).recommendedWater),
					waterNeeded = Mathf.RoundToInt(totalWater * GroupData.GetItem(key).totalWater),
					waterGiven = -1f
				};
				_table.Add(key, temp);
			}
		}
	}

	/*
	*	Used to check to if water has been allocated to all groups and checks to see if too much water has been spent
	*/
	bool CheckWaterAllocation()
	{
		foreach (string key in groups)
		{
			GroupWater temp = null;
			if (_table.TryGetValue(key, out temp))
			{
				if (temp.waterGiven < 0f)
				{
					Debug.Log("Not all Groups have been Allocated Water");
					return false;

				}
			}
			else
			{
				Debug.LogError("Groups not loaded properly. Missing: " + key);
			}
		}
		if (remainingWater < 0)
		{
			Debug.Log("Too much water has been allocated.");
			return false;
		}
		return true;
	}
	#endregion	
}

[System.Serializable]
public class GroupWater
{
	public float waterRecommended; 	//Minimum water needed
	public float waterNeeded;		//Max amount of water needed
	public float waterGiven;		//Water given to group

}
