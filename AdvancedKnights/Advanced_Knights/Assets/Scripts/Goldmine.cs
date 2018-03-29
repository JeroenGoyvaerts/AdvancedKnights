using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goldmine : Buildings {

    private void Start()
    {
        buildingName = "Goldmine";
        health = 100;
    }

    public int goldgain = 10;

    public void Select()
    {
        ParentSelect();

        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 0, 0, 1);

        string attributes = "Income: +" + goldgain;
        UpdateText(buildingName, attributes);
    }
    public void Deselect()
    {
        ParentDeselect();

        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 1, 1);
    }
    public bool TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            owner = Gamemanager.Activeplayer;
            return true;
        }
        return false;
    }


}
