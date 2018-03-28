using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int number;
    public int startGold = 50;

    public int gold;
    public int goldIncome;

    public Text playerText;
    public Text goldText;


    public Player()
    {
        Start();
    }

    void Start()
    {
        
        gold = startGold;
        goldIncome = 0;
    }

    public void Startturn()
    {
        playerText.text = "player " + number;
        UpdateText();
        GetIncome();
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
