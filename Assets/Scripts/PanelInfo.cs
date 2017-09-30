using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInfo : MonoBehaviour {
	 [Tooltip("Must match Attribute used for Level Manager.")]
	public string GroupName;
	
	GroupWater group;
	GameObject warningPanel;
	GameManager gameManager;
	Text percentGiven;
	float percent;
	// Use this for initialization
	void Start () {
		gameManager = GameManager.gameManager;
		group = GameManager.GetItem(GroupName);
		warningPanel = this.transform.GetChild(0).gameObject;
		percentGiven= this.transform.GetChild(1).gameObject.GetComponent<Text>();
		MouserPointerHandler.mph.AddMouseTracker(this.gameObject,OnPointerEnter,OnPointerExit);
		
		
	}

	public void OnPointerEnter(GameObject hovered)
	{
		GameManager.tooltip.SetTooltip(hovered.GetComponent<PanelInfo>().GroupName);
	}

	public void OnPointerExit(GameObject hovered)
	{
		GameManager.tooltip.HideTooltip();
	}
	// Update is called once per frame
	void Update () {
		warningPanel.SetActive(!gameManager.CheckWaterAllocation(GroupName));
		checkPercent();
		percentGiven.text = percent + "%";
	}

	void checkPercent()
	{
		if (group != null && group.waterGiven >= 0)
		{
			if (group.waterRecommended <= 0)
			{
				percent = group.waterGiven / group.waterNeeded * 100;
			}
			else
			{
				percent = group.waterGiven / group.waterRecommended * 100;
			}
			
			percent = Mathf.RoundToInt(percent);
			if (percent < 100)
			{
				percentGiven.color = Color.red;
			}
			else if (percent >= 100)
			{
				percentGiven.color = Color.green;
			}

		}
		else
		{
			percent = 0;
		}
	}
}
