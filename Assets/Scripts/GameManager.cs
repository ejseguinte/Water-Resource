using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditorInternal;

public class GameManager : MonoBehaviour {

	public int maxTurns = 13;
	public int turnCounter = 1;				
	public LevelManager levelManager;
	public GameObject gameScreen;
	public GameObject statScreen;

	private float initialFixedTimeDeltaTime;
	public GameState state; 				//TODO Make state private

	public enum GameState {Pause, Allocate, Adjustment, End};

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		gameScreen = GameObject.FindGameObjectWithTag("Main Game");
		statScreen = GameObject.FindGameObjectWithTag("Stat Screen");
		initialFixedTimeDeltaTime = Time.fixedDeltaTime;
		state = GameState.Allocate;
		statScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
	}

	private void EndAllocation(){
		state = GameState.Adjustment;
	}

	private void EndAdjustment(){
		turnCounter ++;
		state = GameState.End;
		gameScreen.SetActive(false);
		statScreen.SetActive(true);
	}

	private void NextTurn(){
		if(turnCounter >= maxTurns){
			levelManager.LoadLevel("03 Final Results");
		}else{
			state = GameState.Allocate;
			gameScreen.SetActive(true);
			statScreen.SetActive(false);
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
