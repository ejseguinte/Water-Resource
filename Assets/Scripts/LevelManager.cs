using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static string previousScreen = "";
	public static string groupAttribute = "";
	public float autoLoadNextLevelAfter = 3f;

    void Start(){
		if(autoLoadNextLevelAfter <= 0){
			Debug.Log("Auto Load Varible set to <= 0. Will not automatically proceed to next Scene in Build Order.");
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
		Debug.Log ("New Level load: " + name);
		previousScreen = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}
	
	public void LoadPreviousLevel(){
		Debug.Log ("New Level load: " + name);
		string previousLevelName = previousScreen;
		if (previousLevelName == null){
			previousLevelName = "01a Start Menu";
		}
		previousScreen = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(previousLevelName);
	}

	public void LoadGroupLevel(string name){
		Debug.Log ("New Level load: " + name);
		previousScreen = SceneManager.GetActiveScene().name;
		groupAttribute = name;
		SceneManager.LoadScene("02c Game Sliders");
	}
	
	



}
