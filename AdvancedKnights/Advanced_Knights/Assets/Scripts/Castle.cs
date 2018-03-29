using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : Buildings{
    public BuildingUI BuildingUI;

    Slider HealthSlider;

    public GameObject BuildingName;
    private void Start()
    {
        HealthSlider = this.GetComponentInChildren<Slider>();
        buildingName = "building";
        maxhealth = 100f;
        health = maxhealth;
        HealthSlider.value = health / 100f;
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
        string attributes = "owner: player " + (owner.number+1) + "\n health: " + health + "/" + maxhealth;
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
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        health -= damage;
        HealthSlider.value = health / 100f;
        if (health <= 0)
        {
            DestroyBuilding();
        }
    }
    public void DestroyBuilding()
    {
        Mapmanager.Players.Remove(owner);
        Rigidbody deathanimation = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
        deathanimation.AddForce(new Vector3(0, 1000,1000));
    }



}
