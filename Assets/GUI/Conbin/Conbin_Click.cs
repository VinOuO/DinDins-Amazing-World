using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Conbin_Click : MonoBehaviour, IPointerClickHandler
{

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.parent.GetComponent<Conbin_List>().Conbin(transform.GetSiblingIndex());
    }
}
