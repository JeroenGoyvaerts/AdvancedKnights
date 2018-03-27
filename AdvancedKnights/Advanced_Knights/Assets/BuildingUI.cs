using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour {
    public GameObject panel;

    public void Activate()
    {
        panel.SetActive(true);
    }   
    public void DeActivate()
    {
        panel.SetActive(false);
    }
}
