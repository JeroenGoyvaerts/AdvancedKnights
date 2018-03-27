﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public Player owner;
    public Unit aUnit;
    

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        Debug.Log("owner = " + owner.number);
    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 0, 1);
    }
    public void Createunit()
    {
        if(owner.gold - aUnit.MUnitCost >= 0)
        {
            owner.gold -= aUnit.MUnitCost;
            Unit myUnit = Instantiate(aUnit);
            myUnit.owner = this.owner;
            Vector3 buildingLocation = this.transform.position;
            myUnit.transform.Translate(buildingLocation);
            Debug.Log(owner.gold);
        }
    }


}
