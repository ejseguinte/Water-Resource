using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurnCounter : MonoBehaviour {

	public GameManager gameManger;
	private Text myText;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = gameManger.turnCounter.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = gameManger.turnCounter.ToString();
	}
}
