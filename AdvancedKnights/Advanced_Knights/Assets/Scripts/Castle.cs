using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Buildings{
    public int health = 100;
    public BuildingUI BuildingUI;

    public GameObject BuildingName;
    private void Start()
    {
        buildingName = "building";
    }
   

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1,0,0,1);
        if (owner == Gamemanager.Activeplayer)
        {
           string name = "player " + (owner.number+1) ;
           BuildingUI.Activate(name);
        }
        string attributes = "player" + (owner.number+1);
        UpdateText(buildingName, attributes);

    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 1, 1, 1);

        BuildingUI.GetComponent<BuildingUI>().DeActivate();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void DestroyBuilding()
    {
        Mapmanager.Players.Remove(owner);
        Rigidbody deathanimation = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        deathanimation.AddForce(new Vector3(0, 1000,1000));
    }



}
