using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
public class GameManager : MonoBehaviour {
	
	#region Static
	public static int maxTurns = 13;
	public static GameManager gameManager = null;
	#endregion

	#region Public Variables
	public int turnCounter = 1;					
	#endregion

	#region Private Variables
	private float initialFixedTimeDeltaTime;
	private LevelManager levelManager;
	public GameState state;                 //TODO Make state private
	#endregion

	#region Enums
	public enum GameState {Pause, Allocate, Adjustment, End};
	#endregion

	#region Unity Methods
	void Awake () {
		Debug.Log ("Game Manager Awake " + GetInstanceID());
		if(gameManager != null){
			Destroy (gameObject);
			Debug.Log ("Destoying duplicate Game Manager");
		}else{
			gameManager = this;
		}
		GameObject.DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		initialFixedTimeDeltaTime = Time.fixedDeltaTime;
		state = GameState.Allocate;
		//statScreen.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		
	}
	#endregion

	#region State Control

	public string GetState(){
		switch(state){
			case GameState.Allocate:
				return "Allocation";
			case GameState.Adjustment:
				return "Adjustment";
			case GameState.End:
				return "Results";
			default:
				return "Error";
		}
	}

	public void NextState(){
		switch(state){
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
				levelManager.LoadLevel("01a Start Menu");
				break;
		}
		Debug.Log(state);
	}

	private void EndAllocation(){
		state = GameState.Adjustment;
	}

	private void EndAdjustment(){
		turnCounter ++;
		state = GameState.End;
		levelManager.LoadLevel("02b Game Report");
	}

	private void NextTurn(){
		if(turnCounter >= maxTurns){
			levelManager.LoadLevel("03 Final Results");
		}else{
			state = GameState.Allocate;
			levelManager.LoadLevel("02a Game");
		}
	}
	#endregion

	#region Pause Methods

	public void pause(){
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	public void resume(){
		Time.timeScale = 1;
		Time.fixedDeltaTime = initialFixedTimeDeltaTime;
	}
	#endregion
}
