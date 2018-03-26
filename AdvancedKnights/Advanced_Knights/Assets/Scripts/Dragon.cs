using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Unit {

    public string knightName = "Dragon";
    public int knightCost = 15;
    public int knightHealth = 100;
    public int knightAttackDamage = 20;

    public Dragon()
    {
        Unit unit = new Unit(knightName, knightCost, knightHealth, knightAttackDamage);
    }

}
