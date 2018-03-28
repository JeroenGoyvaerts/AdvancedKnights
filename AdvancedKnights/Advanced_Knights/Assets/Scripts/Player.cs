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
        for (int i = 0, lenghtx = Mapmanager.myUnits.GetLength(0); i < lenghtx; i++)
        {
            for (int j = 0, lengthy = Mapmanager.myUnits.GetLength(1); j < lengthy; j++)
            {
                if (Mapmanager.myUnits[i,j] != null)
                {
                    Unit aUnit = Mapmanager.myUnits[i, j];
                    if (aUnit.owner == Gamemanager.Activeplayer)
                    {
                        Mapmanager.myUnits[i, j].movementRange = Mapmanager.myUnits[i, j].MaxmovementRange;
                    }
                    
                }
            }
            
        }
    }
}
