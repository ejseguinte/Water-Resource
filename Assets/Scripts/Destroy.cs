using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour {

	bool firstUpdate = true;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, PlayerPrefsManager.GetWarning());
	}
	
	// Update is called once per frame
	void Update () {
		if(firstUpdate){
			 firstUpdate=false;
				
				Text textBox = this.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
				RectTransform background = this.GetComponent<RectTransform>();
				HorizontalLayoutGroup layout = this.transform.GetChild(0).GetComponent<HorizontalLayoutGroup>();

				layout.GetComponent<RectTransform>().sizeDelta = new Vector2(textBox.preferredWidth , textBox.preferredHeight/ 2);
				background.sizeDelta = new Vector2(textBox.preferredWidth + 40, textBox.preferredHeight/ 2);

			
		 }
	}

}
