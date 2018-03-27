using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Player owner;
    public GameObject BuildingUI;

    private void Start()
    {
        BuildingUI = GameObject.Find("BuildingUI");
    }

    int [] availableUnits = {0};

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        Debug.Log("owner = " + owner.number);

        if (owner == Gamemanager.Activeplayer)
        {
            BuildingUI.SetActive(true);
        }
        
        


    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);

        BuildingUI.SetActive(false);
    }
    


}
