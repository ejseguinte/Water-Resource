using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class UIPointerTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
 
	UnityAction<GameObject> OnPointerEnter;
	UnityAction<GameObject> OnPointerExit;
	 
	//called from the manager to init the callbacks
	public void InitCallBacks(UnityAction<GameObject> Enter, UnityAction<GameObject> Exit){
		OnPointerEnter = Enter;
		OnPointerExit = Exit;
	}
	 
	#region IPointerEnterHandler implementation
	void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData){
		if(!GameManager.EventDisplayed)
			OnPointerEnter(this.gameObject);
	}
	#endregion
	 
	#region IPointerExitHandler implementation
	void IPointerExitHandler.OnPointerExit (PointerEventData eventData){
		if(!GameManager.EventDisplayed)
			OnPointerExit(this.gameObject);
	}
	#endregion
}