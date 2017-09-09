using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance = null;

	public float autoLoadNextLevelAfter = 3f;

	void Awake () {
		Debug.Log ("Level Manager Awake " + GetInstanceID());
		if(instance != null){
			Destroy (gameObject);
			Debug.Log ("Destoying duplicate Level Manager");
		}else{
			instance = this;
		}
		GameObject.DontDestroyOnLoad(gameObject);
	}

    void Start(){
		if(autoLoadNextLevelAfter <= 0){
			Debug.Log("Auto Load Varible set to <= 0. Will not automatically proceed to next Scene in Build Order.");
		}else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	}



}
