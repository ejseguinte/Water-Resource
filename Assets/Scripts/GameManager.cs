using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class GameManager : MonoBehaviour
{

	#region Static
	public static int maxTurns = 12;
	public static GameManager gameManager = null;
	#endregion

	#region Public Variables
	public int turnCounter = 1;
	#endregion

	#region Private Variables
	private static int menuScreenBuildIndex = 1; //the menu screen's index in your Build Settings
	private LevelManager levelManager;
	private float initialFixedTimeDeltaTime;
	private GameState state = GameState.Allocate;                 
	private int food = 1000;
	private int happiness = 100;
	private int money = 1000;
	private int population = 1000;
	private int farms = 1000;

	//Water
	private int totalWater = 1000;
	private int expendedWater = 0;
	private int remainingWater = 1000;
	private int estimateWater = 0;
	#endregion

	#region Enums
	public enum GameState {  Allocate, Adjustment, End, Pause };
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
		initialFixedTimeDeltaTime = Time.fixedDeltaTime;
		
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
			case GameState.Adjustment:
				return "Adjustment";
			case GameState.End:
				return "Results";
			default:
				Debug.Log(state);
				return "Error";
		}
	}

	public void NextState()
	{
		switch (state)
		{
			case GameState.Allocate:
				EndAllocation();
				break;
			case GameState.Adjustment:
				EndAdjustment();
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

	private void EndAllocation()
	{
		state = GameState.Adjustment;
	}

	private void EndAdjustment()
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

	public int TotalWater
	{
		get
		{
			return totalWater;
		}

		set
		{
			totalWater = value;
		}
	}

	public int ExpendedWater
	{
		get
		{
			return expendedWater;
		}

		set
		{
			expendedWater = value;
		}
	}

	public int RemainingWater
	{
		get
		{
			return remainingWater;
		}

		set
		{
			remainingWater = value;
		}
	}

	public int EstimateWater
	{
		get
		{
			return estimateWater;
		}

		set
		{
			estimateWater = value;
		}
	}
	#endregion
}
