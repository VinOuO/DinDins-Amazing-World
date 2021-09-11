using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TB_Button : MonoBehaviour , IPointerClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name[0] == 'T')
        {
            transform.parent.transform.parent.GetComponent<Conbin_List>().P--;
        }
        else
        {
            transform.parent.transform.parent.GetComponent<Conbin_List>().P++;
        }
        transform.parent.transform.parent.GetComponent<Conbin_List>().Sprite_Change();
    }
}
