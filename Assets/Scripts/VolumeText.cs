using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeText : MonoBehaviour {

	public Slider volume;
	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text>();
		myText.text = volume.value * 100 +" ";
	}
	
	// Update is called once per frame
	void Update () {
		Text myText = GetComponent<Text>();
		myText.text = volume.value.ToString();
	}
}
