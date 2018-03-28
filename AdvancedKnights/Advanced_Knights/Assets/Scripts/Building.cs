using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Selected {

    public Player owner;
    public GameObject BuildingUI;

    public GameObject SelectedUI;

    public string buildingName = "building";

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        Debug.Log("owner = " + owner.number);
        if (owner == Gamemanager.Activeplayer)
        {
           string name = "player " + (owner.number+1) ;
           BuildingUI.GetComponent<BuildingUI>().Activate(name);
        }
        string attributes = "player" + (owner.number+1);
        UpdateText(buildingName, attributes);

    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);

        BuildingUI.GetComponent<BuildingUI>().DeActivate();
    }
    


}
