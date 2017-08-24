using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicPlayer musicManager;

	void Awake(){
		if(GameObject.FindObjectOfType<MusicPlayer>()){
			musicManager = GameObject.FindObjectOfType<MusicPlayer>();
		}
		musicManager.SetVolume( PlayerPrefsManager.GetMasterVolume()/100f);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
