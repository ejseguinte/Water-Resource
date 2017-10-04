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

				RectTransform background = this.GetComponent<RectTransform>();
				HorizontalLayoutGroup layout = this.transform.GetChild(0).GetComponent<HorizontalLayoutGroup>();

				background.sizeDelta = new Vector2(layout.preferredWidth + 8, layout.preferredHeight + 8);

			
		 }
	}

}
