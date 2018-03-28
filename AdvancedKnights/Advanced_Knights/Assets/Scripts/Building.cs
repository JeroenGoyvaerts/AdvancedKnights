using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Player owner;
    public GameObject BuildingUI;

    public GameObject SelectedUI;

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        Debug.Log("owner = " + owner.number);
        if (owner == Gamemanager.Activeplayer)
        {
           string name = "player " + (owner.number+1) ;
           BuildingUI.GetComponent<BuildingUI>().Activate(name);
        }
        
    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);

        BuildingUI.GetComponent<BuildingUI>().DeActivate();
    }
    


}
