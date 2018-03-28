using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : Selected {

    public Material unselected;
    public Material selected;

    public GameObject SelectedUI;

    public string tileName = "Land";
    public string attributes = "none";

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = selected;

        UpdateText(tileName,attributes);
    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = unselected;
    }
}
