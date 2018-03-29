using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour {
    [SerializeField]
    public GameObject gameOverPannel;
    [SerializeField]
    public Text winnerText;
    [SerializeField]
    public GameObject selectedPannel;
    [SerializeField]
    public Text selectedNameText;
    [SerializeField]
    public Text selectedAttributeText;

    

    static GameObject selected = null;
    static int selectedtiletype = -1;

    static Player activeplayer;

    [SerializeField]
    public Unit[] aUnit;

    public Cameramanager mycamera;
    public Vector3 lastposition;
    bool input = false;
    bool drag = false;
    protected bool unitselected = false;

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
               mycamera.Move(deltX*12/Screen.width, deltz*6/Screen.height);
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

    private void Click()
    {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
            return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
            string hitname = hit.transform.name;
            if (unitselected)
            {
                if (hitname == "LandTile(Clone)" || hitname == "ForestTile(Clone)" || hitname == "StoneTile(Clone)")
                {
                    /*
                     * ??
                     * 
                     * aUnit[0].Availablemoves(2,2, aUnit[0].avMoves[0][0]);
                     * */
                    //if (aUnit[0].GetType()) { ????
                   selected.GetComponent<Unit>().MoveKnight(hit.transform.position);
                    /*}
                    else { 
                    selected.GetComponent<DragonScript>().MoveDragon(hit.transform.position);
                }*/
                    unitselected = false;
                    Deselect();;
                }
                else
                {
                    unitselected = false;
                    Deselect();
                }
            }
            else
            {
                Deselect();

                if (hitname == "Castle(Clone)")
                {
                    hit.transform.gameObject.GetComponent<Castle>().Select();
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
                else if (hitname == "ForestTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<LandTile>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 5;
                }
                else if (hitname == "StoneTile(Clone)")
                {
                    hit.transform.gameObject.GetComponent<LandTile>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 6;
                }
                else if (hitname == "Knight(Clone)" || hitname == "Dragon(Clone)")
                {
                    SpriteRenderer spriteRenderer = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.material.color = new Color(1, 0, 0);
                    hit.transform.gameObject.GetComponent<Unit>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 3;
                    
                    if (selected.GetComponent<Unit>().owner == Activeplayer)
                    {
                        unitselected = true;
                    }

                }
                else if (hitname == "Goldmine(Clone)")
                {
                    hit.transform.gameObject.GetComponent<Goldmine>().Select();
                    selected = hit.transform.gameObject;
                    selectedtiletype = 4;
                }
            }
            }
        
    }

    private static void Deselect()
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
                selected.GetComponent<Castle>().Deselect();
                break;
            case 3:
                SpriteRenderer spriteRenderer = selected.GetComponent<SpriteRenderer>();
                spriteRenderer.material.color = new Color(1, 1, 1);
                selected.GetComponent<Unit>().Deselect();
                break;
            case 4:
                selected.GetComponent<Goldmine>().Deselect();
                break;
            case 5:
                selected.GetComponent<LandTile>().Deselect();
                break;
            case 6:
                selected.GetComponent<LandTile>().Deselect();
                break;
            default:
                break;
        }
    }
    public void Endturn()
    {
        Activeplayer.EndTurn();
        if (Activeplayer.number == Mapmanager.Players.Count-1)
        {
            Activeplayer = Mapmanager.Players[0];
        }
        else
        {
            Activeplayer = Mapmanager.Players[Activeplayer.number + 1];
        }
        Deselect();
        selectedtiletype = -1;
        Activeplayer.Startturn();
    }
    public void Createunit(int unitNmb)
    {
        Vector3 buildingLocation = selected.transform.position;
        int xvalue= (int)Math.Round(buildingLocation.x);
        int yvalue = (int)Math.Ceiling(-buildingLocation.z);
        if (Mapmanager.myUnits[xvalue, yvalue]!= null)
        {
            return;
        }
        if (Activeplayer.gold - aUnit[unitNmb].MUnitCost >= 0)
        {
            Activeplayer.gold -= aUnit[unitNmb].MUnitCost;
            Unit myUnit = Instantiate(aUnit[unitNmb]);
            myUnit.owner = Activeplayer;
            myUnit.selectedPanel = selectedPannel;
            myUnit.selectedAttributesText = selectedAttributeText;
            myUnit.selectedNameText = selectedNameText;
            myUnit.xvalue = xvalue;
            myUnit.yvalue = yvalue;
            
            myUnit.transform.position = buildingLocation + new Vector3(0, 0.35f, -0.4f);
            Mapmanager.myUnits[xvalue, yvalue] = myUnit;

            Activeplayer.UpdateText();
        }
    }
    public void CheckEnd()
    {
        if (Mapmanager.Players.Count == 1)
        {
            winnerText.text = "player " + (Mapmanager.Players[0].number + 1) + " wins";
            gameOverPannel.SetActive(true);

        }
    }
}
