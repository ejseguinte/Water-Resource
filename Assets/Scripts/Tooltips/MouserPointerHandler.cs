using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class MouserPointerHandler : MonoBehaviour{
 
	public static MouserPointerHandler mph;
	 
	//singleton class system
	void Awake () {
		mph=this;
	}
	 
	/// <summary>
	/// Add a UIPointerTrigger script to an UI element's GameObject and link to it the
	/// OnPointerEnter and OnPointerExit callbacks from another script
	/// </summary>
	/// <param name="uiItem">User interface item.</param>
	/// <param name="OnPointerEnter">OnPointerEnter<GameObject> callback.</param>
	/// <param name="OnPointerExit">OnPointerExit<GameObject> callback.</param>
	public void AddMouseTracker(GameObject uiItem, UnityAction<GameObject> OnPointerEnter, UnityAction<GameObject> OnPointerExit){
		UIPointerTrigger trig = uiItem.GetComponent<UIPointerTrigger>();
		//if the given object didn't have an UIPointerTrigger script attached, add one by default
		if(trig==null){
			trig=uiItem.AddComponent<UIPointerTrigger>();
		}
		trig.InitCallBacks(OnPointerEnter,OnPointerExit);
	}
}