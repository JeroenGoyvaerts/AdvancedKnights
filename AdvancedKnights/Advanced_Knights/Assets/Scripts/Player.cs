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
        playerText.text = "player " + number;
        Debug.Log("player " + number);
        Debug.Log(Gamemanager.Activeplayer.gold);
        GetIncome();
        Debug.Log(Gamemanager.Activeplayer.gold);
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
