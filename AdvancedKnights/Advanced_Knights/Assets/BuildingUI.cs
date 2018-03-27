using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour {
    public GameObject panel;
    public Text playerText;

    public void Activate(string myText)
    {
        panel.SetActive(true);
        SetText(myText);
    }   
    public void DeActivate()
    {
        panel.SetActive(false);
    }
    public void SetText(string myText)
    {
        playerText.text = myText;
    }
}
