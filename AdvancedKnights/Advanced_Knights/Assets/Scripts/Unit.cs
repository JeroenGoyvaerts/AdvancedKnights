using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour{
    public Player owner;

    public GameObject SelectedUI;

    private string mUnitName = "Knight";
    private int mUnitCost = 5;
    private int mUnitHealth = 100;
    private int mUnitAttackDamage = 15;

    public void Select()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(1, 0, 0, 1);
    }
    public void Deselect()
    {
        MeshRenderer myrenderer = this.GetComponent<MeshRenderer>();
        myrenderer.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }


    public string MUnitName
    {
        get
        {
            return mUnitName;
        }

        set
        {
            mUnitName = value;
        }
    }

    public int MUnitCost
    {
        get
        {
            return mUnitCost;
        }

        set
        {
            mUnitCost = value;
        }
    }

    public int MUnitHealth
    {
        get
        {
            return mUnitHealth;
        }

        set
        {
            mUnitHealth = value;
        }
    }

    public int MUnitAttackDamage
    {
        get
        {
            return mUnitAttackDamage;
        }

        set
        {
            mUnitAttackDamage = value;
        }
    }

    public Unit(string unitName, int unitCost, int unitHealth, int unitAttackDamage)
    {
        mUnitName = unitName;
        mUnitCost = unitCost;
        mUnitHealth = unitHealth;
        mUnitAttackDamage = unitAttackDamage;
    }

    public Unit()
    {

    }
    // creates List of all tiles available to the unit
    protected List<int[]> avMoves = new List<int[]>();
    protected void Availablemoves(int x, int y, int moves)
    {
        int[] coordinates = { x, y };
        bool continu = true;
        foreach (int[] avcorrdinates in avMoves)
        {
            if (avcorrdinates[0] == coordinates[0] && avcorrdinates[1] == coordinates[1])
            {
                continu = false;
            }
        }
        if (continu)
        {
            if (Mapmanager.Map[x, y] == 0)
            {
                return;
            }
            else if (moves == 0)
            {

                avMoves.Add(coordinates);
            }
            else
            {
                avMoves.Add(coordinates);
                Availablemoves(x + 1, y, moves - 1);
                Availablemoves(x - 1, y, moves - 1);
                Availablemoves(x, y + 1, moves - 1);
                Availablemoves(x, y - 1, moves - 1);
            }
        }


    }


}
