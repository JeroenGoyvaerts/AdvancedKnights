using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandTile : Selected
{

    public Material unselected;
    public Material selected;

    public GameObject SelectedUI;
    // public KnightScript knight;
    // public DragonScript dragon;

    public string selectedChar = "dragon";

    public string tileName = "Land";
    public string attributes = "none";

    public void Select()
    {
        ParentSelect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = selected;

        UpdateText(tileName, attributes);

        /*      if (selectedChar == "knight")
              {
                  knight = GameObject.Find("Knight").GetComponent<KnightScript>();
                  knight.tilePosition = myrenderer.transform.position;
                  knight.update = true;
                  knight.stateChangeable = true;
                  knight.UpdateCharacter();
             }

              if (selectedChar == "dragon")
             {
                  dragon = GameObject.Find("Dragon").GetComponent<DragonScript>();
                  dragon.tilePosition = myrenderer.transform.position;
                  dragon.update = true;
                  dragon.stateChangeable = true;
                  dragon.UpdateCharacter();
              }*/
    }
    public void Deselect()
    {
        ParentDeselect();
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.sharedMaterial = unselected;
    }
}
