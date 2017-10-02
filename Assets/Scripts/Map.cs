using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Map : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Interactable()
	{
		for (int i = 0; i < this.transform.childCount; i++)
		{
			Button button = this.transform.GetChild(i).GetComponent<Button>();
			button.interactable = !button.IsInteractable();
		}
	}
}
