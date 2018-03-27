using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : MonoBehaviour {

    public Material unselected;
    public Material selected;

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = selected;
    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = unselected;
    }
}
