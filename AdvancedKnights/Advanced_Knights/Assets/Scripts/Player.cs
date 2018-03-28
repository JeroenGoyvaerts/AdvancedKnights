using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Selected {
    public int number;
    public int startGold = 50;

    public int gold = 50;
    public int goldIncome;

    public Text playerText;
    public Text goldText;

    public Vector3 buildingPosition;
    public Camera MainCamera;

    public Player()
    {
        Start();
    }

    void Start()
    {
        goldIncome = 5;
    }

    public void Startturn()
    {
        MainCamera.transform.position = buildingPosition + new Vector3(0,4,-1);
        playerText.text = "player " + (number+1);
        GetIncome();
        UpdateText();
    }
    public void UpdateText()
    {
        goldText.text = "gold: " + gold + "(+" + goldIncome + ")";
    }

    public void GetIncome()
    {
        gold += goldIncome;
    }
    public void EndTurn()
    {
       Debug.Log("end turn");
    }
}
