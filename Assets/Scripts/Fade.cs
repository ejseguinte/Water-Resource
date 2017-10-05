using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {
	
	public float fadeInTime;
	public float fadeOutTime;
	
	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad < fadeInTime){
			Vector3 newPos = new Vector3(0f, 0f, 0f);
			fadePanel.transform.position = newPos;
			
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		}else{
			gameObject.SetActive(false);
		}
	}
}
