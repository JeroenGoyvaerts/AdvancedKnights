using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
