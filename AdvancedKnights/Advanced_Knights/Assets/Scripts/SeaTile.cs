using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaTile : Selected {

    public Material unselected;
    public Material selected;

    public string seaName = "Sea";
    public string attributes = "impasseble";

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = selected;

        UpdateText(seaName, attributes);
    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = unselected;
    }
}
