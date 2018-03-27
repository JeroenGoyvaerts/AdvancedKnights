﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {
    static GameObject selected = null;
    static int selectedtiletype = -1;

    static Player activeplayer;

    public static Player Activeplayer
    {
        get
        {
            return activeplayer;
        }

        set
        {
            activeplayer = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        
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
                else if (hitname == "Unit(Clone)")
                {
                    hit.transform.gameObject.GetComponent<Unit>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 3;
                }
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
            case 3:
                selected.GetComponent<Unit>().Deselect();
                break;
            default:
                break;
        }
    }
    public void Endturn()
    {
        Activeplayer.EndTurn();
        Debug.Log(Activeplayer.number+ "and" + Mapmanager.Players.Count);
        if (Activeplayer.number == Mapmanager.Players.Count-1)
        {
            Activeplayer = Mapmanager.Players[0];
        }
        else
        {
            Activeplayer = Mapmanager.Players[Activeplayer.number + 1];
        }
        Debug.Log(Activeplayer.number);
        

    }
}
