using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PolicyLogController : MonoBehaviour {

	public GameObject textbox;
	public Transform parent;
	public Text title;
	public Text body;
	public GameObject button;
	public Text cost;
	public Policy currentPolicy;

	private Array policies;
	// Use this for initialization
	void Start () {
		
		policies = PolicyData.GetKeys();
		float y = 0;
		parent.transform.position = new Vector2(0, 0);
		Debug.Log(currentPolicy);
		if(currentPolicy.nameID == ""){
			button.SetActive(false);
		}
		if(cost.text == "Cost: $99999999"){
			cost.enabled = false;
		}
		if (policies != null)
		{
			foreach (string policyName in policies)
			{
				Policy temp = PolicyData.GetItem(policyName);
				GameObject text = Instantiate(textbox) as GameObject;
				Text description = text.GetComponentInChildren<Text>();
				description.text = temp.guiName;
				text.name = temp.nameID;
				
				text.GetComponent<Button>().onClick.AddListener(() => { DisplayPolicy(); }); 
				text.transform.SetParent(parent.transform);
				y = y + text.transform.lossyScale.y;
				Vector2 pos = new Vector2(text.transform.position.x, y);
				text.transform.position = pos;
				text.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (parent.GetComponent<VerticalLayoutGroup>().preferredHeight > parent.GetComponent<RectTransform>().sizeDelta.y)
		{
			parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parent.GetComponent<VerticalLayoutGroup>().preferredHeight);
		}
		
	}

	public void DisplayPolicy()
	{
		currentPolicy = PolicyData.GetItem(EventSystem.current.currentSelectedGameObject.name);
		title.text = currentPolicy.guiName;
		body.text = currentPolicy.description;
		cost.text = "Cost: $" + currentPolicy.cost;
		cost.enabled = true;
		if(currentPolicy.nameID != ""){
			button.SetActive(true);
			button.GetComponent<Button>().onClick.RemoveAllListeners();
			button.GetComponent<Button>().onClick.AddListener(() => { PolicyManager.AddPolicy(currentPolicy); }); 
		}
	}
	
}
