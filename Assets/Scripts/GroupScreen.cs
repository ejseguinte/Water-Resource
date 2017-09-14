using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupScreen : MonoBehaviour {
	public Text title;
	public Text description;
	public GameObject content;

	// Use this for initialization
	void Awake () {
		Group group = GroupData.GetItem(LevelManager.groupAttribute);
		if (group == null)
		{
			title.text = "Test";
			description.text = "Testing";
			
		}
		else{
			title.text = group.guiName;
			description.text = group.description;
		}
		content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, description.preferredHeight);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
