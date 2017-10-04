using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	
	public Slider volume;
	public Slider difficulty;
	public Slider warningTime;
	public Toggle keepScore;
	public Toggle tooltip;
	public Dropdown year;
	public LevelManager levelManager;
	
	private MusicPlayer musicManager;
	
	// Use this for initialization
	void Start () {
		if(GameObject.FindObjectOfType<MusicPlayer>()){
			musicManager = GameObject.FindObjectOfType<MusicPlayer>();
		}
		volume.value = PlayerPrefsManager.GetMasterVolume();
		difficulty.value = PlayerPrefsManager.GetDifficulty();
		warningTime.value = PlayerPrefsManager.GetWarning();
		keepScore.isOn = PlayerPrefsManager.GetKeepScore();
		tooltip.isOn = PlayerPrefsManager.GetTooltip();
		year.value = PlayerPrefsManager.GetYear();
	}
	
	// Update is called once per frame
	void Update () {
		if(musicManager){
			musicManager.SetVolume(volume.value/100f);
		}
	}
	
	public void setDefaults(){
		volume.value = 80f;
		difficulty.value = 2f;
		warningTime.value = 2f;
		keepScore.isOn = true;
		tooltip.isOn = true;
		year.value = 0;
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volume.value);
		PlayerPrefsManager.SetDifficulty(difficulty.value);
		PlayerPrefsManager.SetWarning(warningTime.value);
		PlayerPrefsManager.SetKeepScore(keepScore.isOn);
		PlayerPrefsManager.SetToolTip(tooltip.isOn);
		PlayerPrefsManager.SetYear(year.value);
		
		if(musicManager){
			musicManager.SetVolume(volume.value);
		}
		
		levelManager.LoadPreviousLevel();
		
	}
}
