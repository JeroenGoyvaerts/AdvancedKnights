using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Player owner;
    GameObject BuildingUI;
    private void Start()
    {
        BuildingUI = GameObject.Find("BuildingUI");
    }

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        Debug.Log("owner = " + owner.number);
        if (owner == Gamemanager.Activeplayer)
        {
           BuildingUI.GetComponent<BuildingUI>().Activate();
        }
        
    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);

        BuildingUI.GetComponent<BuildingUI>().DeActivate();
    }
    


}
