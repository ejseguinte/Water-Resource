using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
/*
	This class is used for managing all item that will go into the Player Preference
	bucket. Before any item is put into the bucket a Constant is requred for a Key at
	the top of this class. Then create a Region for the Getter and Setter of the value.
*/

	const string MASTER_VOLUME_KEY 	= "master_volume";
	const string DIFFICULTY_KEY 	= "difficulty";
	const string YEAR_KEY			= "year";
	const string KEEP_SCORE_KEY		= "keep_score";
	const string LEVEL_KEY 			= "level_unlocked_";	//Example: "level_unlocked_01" for Level 1
	
	#region Master Volume

	public static void SetMasterVolume (float volume){
		volume = volume / 100f;
		Debug.Log ("Setting volume to: " + volume);
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}else{
			Debug.LogError ("Master Volume out of Range. Tried to set Volume to: " + volume);
		}
	}
	
	public static float GetMasterVolume (){
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY) * 100f;
	}
	#endregion
	
	#region Diffculty

	public static void SetDifficulty (float difficulty){
		if(difficulty >= 1f && difficulty < 3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		}else{
			Debug.LogError ("Diffculty is out of Range. Tried to set Difficulty to: "+difficulty);
		}
	}
	
	public static int GetDifficulty (){
		return Mathf.RoundToInt(PlayerPrefs.GetFloat (DIFFICULTY_KEY));
	}
	
	#endregion

	#region Year Picker

	public static void SetYear (int year){
		PlayerPrefs.SetInt(YEAR_KEY, year);
	}

	public static int GetYear (){
		return PlayerPrefs.GetInt(YEAR_KEY);
	}
	#endregion

	#region KeepScore

	public static void SetKeepScore (bool keepScore){
		int value = -1;
		if(keepScore == true)	{
			value = 1;
		}else {
			value = 0;
		}
		
		PlayerPrefs.SetInt(KEEP_SCORE_KEY, value);
	}

	public static bool GetKeepScore(){
		int keepScore = PlayerPrefs.GetInt(KEEP_SCORE_KEY);
		if(keepScore == 1)	{
			return true;
		}else {
			return false;
		}
	}
	#endregion
	
	#region Level Unlocking

	public static void UnlockLevel (int level){
		if(level <= SceneManager.sceneCountInBuildSettings - 1 ){
			PlayerPrefs.SetInt (LEVEL_KEY+level.ToString(), 1); //Use 1 for True
		}else{
			Debug.LogError ("Requested Level is out of Range. Tried to Unlock Level: "+ level);
		}
	}
	
	public static bool IsLevelUnlocked (int level){
		if(level <= SceneManager.sceneCountInBuildSettings  - 1 ){
			int levelValue = PlayerPrefs.GetInt (LEVEL_KEY+level.ToString()); //Use 1 for True
			return (levelValue == 1);
		}else{
			Debug.LogError ("Requested Level is out of Range");
		}
		return false;
	}
	#endregion
	
}
