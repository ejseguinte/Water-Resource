using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audiosSource;

	void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void Awake () {
		audiosSource = GetComponent<AudioSource>();
		SetVolume(PlayerPrefsManager.GetMasterVolume()/100);
		DontDestroyOnLoad(gameObject);
		
	}
	
	void Start (){
		
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		print(scene.name);
		AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
		Debug.Log ("Playing clip:" + thisLevelMusic);
		Debug.Log (audiosSource);
		if(thisLevelMusic){
			audiosSource.clip = thisLevelMusic;
			if(scene.buildIndex == 0){
				audiosSource.loop = false;
			}else{
				audiosSource.loop = true;
			}
			audiosSource.Play();
			
		}
		
	}
	
	public void SetVolume(float volume){
		audiosSource.volume = volume;
	}
}
