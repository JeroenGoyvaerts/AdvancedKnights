using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : Selected {

    public Material unselected;
    public Material selected;

    public GameObject SelectedUI;
    public KnightScript knight;

    public string tileName = "Land";
    public string attributes = "none";

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = selected;

        UpdateText(tileName,attributes);

        knight = GameObject.Find("Knight").GetComponent<KnightScript>();
        knight.tilePosition = myrenderer.transform.position;
        knight.update = true;
        knight.stateChangeable = true;
        knight.UpdateCharacter();
    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = unselected;
    }
}
