using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {
	public static string previousScreen = "";
	public static string groupAttribute = "";
	public float autoLoadNextLevelAfter = 3f;

    void Start(){
		if(autoLoadNextLevelAfter <= 0){
			//Debug.Log("Auto Load Varible set to <= 0. Will not automatically proceed to next Scene in Build Order.");
			if(SceneManager.GetActiveScene().buildIndex == 0){
				WaterData.LoadItemsData();
				EventData.LoadItemsData();
				PolicyData.LoadItemsData();
				GroupData.LoadItemsData();
			}
		}else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		string button = EventSystem.current.currentSelectedGameObject.name;
		if (!GameManager.EventDisplayed || (button == "Main Menu Button"))
		{
			previousScreen = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(name);
		}
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel(){
		if (!GameManager.EventDisplayed)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
		}
	}
	
	public void LoadPreviousLevel(){
		//Debug.Log ("New Level load: " + name);
		string previousLevelName = previousScreen;
		//Debug.Log(previousLevelName);
		if (previousLevelName == ""){
			previousLevelName = "01a Start Menu";
		}
		previousScreen = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(previousLevelName);
	}

	public void LoadGroupLevel(string name){
		if (!GameManager.EventDisplayed)
		{
			Debug.Log("Loading Group Screen: " + name);
			previousScreen = SceneManager.GetActiveScene().name;
			groupAttribute = name;
			SceneManager.LoadScene("02c Game Sliders");
		}
	}
	
	



}
