using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : Selected {

    public Player owner;

    public GameObject SelectedUI;

    public string GoldmineName = "Goldmine";

    public int goldgain = 10;

    public void Select()
    {
        ParentSelect();

        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 0, 0, 1);

        string attributes = "Income: +" + goldgain;
        UpdateText(GoldmineName, attributes);
    }
    public void Deselect()
    {
        ParentDeselect();

        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 1, 1);
    }
}
