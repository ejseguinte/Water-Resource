using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTracker : MonoBehaviour {

	public GameManager gameManager;
	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = gameManager.GetState();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(gameManager.GetState());
		myText.text = gameManager.GetState();
	}
}
