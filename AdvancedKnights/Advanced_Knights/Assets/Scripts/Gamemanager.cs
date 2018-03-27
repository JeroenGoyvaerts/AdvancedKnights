using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {
    static GameObject selected = null;
    static int selectedtiletype = -1;

    public Unit[] aUnit;

    static Player activeplayer;

    public Cameramanager mycamera;
    protected Vector3 lastposition;
    bool input = false;
    bool drag = false;

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

    public static GameObject Selected
    {
        get
        {
            return selected;
        }

        set
        {
            selected = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastposition = Input.mousePosition;
            input = true;

        }
        if (input)
        {


           float deltX = lastposition.x - Input.mousePosition.x;
           float deltz = lastposition.y - Input.mousePosition.y;
          float delty = lastposition.z - Input.mousePosition.z;
          if (deltX < -20 || deltX > 20 || delty < -20 || delty > 20 || deltz < -20 || deltz > 20)
           {
               drag = true;
               mycamera.Move(deltX/50, deltz/50);
                lastposition = Input.mousePosition;
               
           }
        }
        if (Input.GetMouseButtonUp(0))
        {
            input = false;
            if (!drag)
            {
                Click();
            }
            else
            {
                drag = false;
            }
        }
        
        

    }

    private static void Click()
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
                    Selected = hit.transform.gameObject;
                    selectedtiletype = 2;

                }
                else if (hitname == "SeaTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<SeaTile>().Select();
                    Selected = hit.transform.gameObject;
                    selectedtiletype = 0;
                }
                else if (hitname == "LandTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<LandTile>().Select();
                    Selected = hit.transform.gameObject;
                    selectedtiletype = 1;
                }
                else if (hitname == "Unit(Clone)")
                {
                    hit.transform.gameObject.GetComponent<Unit>().Select();
                    Selected = hit.transform.gameObject;
                    selectedtiletype = 3;
                }
            }
        
    }

    private static void Deselect(ref RaycastHit hit)
    {
        switch (selectedtiletype)
        {
            case 0:
                Selected.GetComponent<SeaTile>().Deselect();
                break;
            case 1:
                Selected.GetComponent<LandTile>().Deselect();
                break;
            case 2:
                Selected.GetComponent<Building>().Deselect();
                break;
            case 3:
                Selected.GetComponent<Unit>().Deselect();
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
    public void Createunit(int unitNmb)
    {
        if (selectedtiletype == 2)
        {
            if (Activeplayer.gold - aUnit[unitNmb].MUnitCost >= 0)
            {
                Activeplayer.gold -= aUnit[unitNmb].MUnitCost;
                Unit myUnit = Instantiate(aUnit[unitNmb]);
                myUnit.owner = Activeplayer;
                Vector3 buildingLocation = Selected.transform.position;
                myUnit.transform.Translate(buildingLocation);
                Debug.Log(Activeplayer.gold);
            }
        }
        
    }
}
