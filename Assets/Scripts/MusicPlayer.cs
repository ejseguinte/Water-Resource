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
		DontDestroyOnLoad(gameObject);
		
	}
	
	void Start (){
		audiosSource = GetComponent<AudioSource>();
	}
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
		Debug.Log ("Playing clip:" + thisLevelMusic);
		if(thisLevelMusic){
			audiosSource.clip = thisLevelMusic;
			audiosSource.loop = true;
			audiosSource.Play();
			
		}
		
	}
	
	public void SetVolume(float volume){
		audiosSource.volume = volume;
	}
}
