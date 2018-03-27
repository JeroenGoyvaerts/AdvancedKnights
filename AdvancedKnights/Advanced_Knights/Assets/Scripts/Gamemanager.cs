using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {
    static GameObject selected = null;
    static int selectedtiletype = -1; 
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        Click();

    }

    private static void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Deselect(ref hit);
                string hitname = hit.transform.name;
                if (hitname == "Building(Clone)")
                {            
                    hit.transform.gameObject.GetComponent<Building>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 2;

                }
                else if (hitname == "SeaTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<SeaTile>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 0;
                }
                else if (hitname == "LandTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<LandTile>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 1;
                }
                Debug.Log(hit.transform.name);
            }
        }
        
    }

    private static void Deselect(ref RaycastHit hit)
    {
        switch (selectedtiletype)
        {
            case 0:
                selected.GetComponent<SeaTile>().Deselect();
                break;
            case 1:
                selected.GetComponent<LandTile>().Deselect();
                break;
            case 2:
                selected.GetComponent<Building>().Deselect();
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
        
    }
}
