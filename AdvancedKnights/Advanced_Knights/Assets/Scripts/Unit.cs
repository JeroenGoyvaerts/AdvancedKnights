using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit{

    private string mUnitName = "Knight";
    private int mUnitCost = 5;
    private int mUnitHealth = 100;
    private int mUnitAttackDamage = 15;

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

}
