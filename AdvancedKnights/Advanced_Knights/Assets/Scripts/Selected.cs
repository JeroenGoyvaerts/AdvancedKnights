using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour {
    public Text selectedNameText;
    public Text selectedAttributesText;
    public GameObject selectedPanel;

    protected void UpdateText(string name,string attributes)
    {
        selectedNameText.text = name;
        selectedAttributesText.text = attributes;
    }
    public void ParentSelect()
    {
        selectedPanel.SetActive(true);
    }
    public void ParentDeselect()
    {
        selectedPanel.SetActive(false);
    }

}
