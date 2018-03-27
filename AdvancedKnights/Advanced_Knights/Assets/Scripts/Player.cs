using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public int number;
    public int startGold = 50;

    public int gold;
    public int goldIncome;

    public Player()
    {
        Start();
    }

    void Start()
    {
        
        gold = startGold;
    }

    public void Startturn()
    {
        playerText.text = "player " + number;
        GetIncome();
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
