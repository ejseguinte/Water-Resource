using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseTracker : MonoBehaviour {

	private GameManager gameManager;
	private Text myText;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
		myText = GetComponent<Text>();
		myText.text = gameManager.GetState();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = gameManager.GetState();
	}
}
