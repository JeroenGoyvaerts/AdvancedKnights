using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : MonoBehaviour {

    public Player owner;

    public GameObject SelectedUI;

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 0, 0, 1);


    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);
    }
}
