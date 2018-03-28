using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Selected {
    public bool update;
    public bool stateChangeable = true;
    public bool moveFromGameManager;

    public int xvalue;
    public int yvalue;

    public List<int[]> avMoves = new List<int[]>();

    public Vector3 tilePosition;
    Animator anim;

    public Player owner;

    public GameObject SelectedUI;

    private string mUnitName = "Knight";
    private int mUnitCost = 5;
    private int mUnitHealth = 100;
    private int mUnitAttackDamage = 15;

    public int movementRange = 2;
    public int MaxmovementRange = 2;

    void Start()
    {
        tilePosition = transform.position;
        anim = GetComponent<Animator>();
    }


    void ChangeState(string state)
    {
        switch (state)
        {
            case "idle":
                anim.SetInteger("state", -1);
                break;

            case "walk":
                anim.SetInteger("state", 1);
                break;

            case "attack":
                anim.SetInteger("state", 2);
                break;

            case "hurt":
                anim.SetInteger("state", 3);
                break;

            case "die":
                anim.SetInteger("state", 4);
                break;

            default:
                anim.SetInteger("state", -1);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (moveFromGameManager)
        {
            UpdateCharacter();
        }
    }

    public void UpdateCharacter()
    {
        if (Vector3.Distance(transform.position, tilePosition + new Vector3(0, 0.6f, 0.2f)) < 0.05)
        {
            ChangeState("idle");
            stateChangeable = false;
            if (transform.position == tilePosition + new Vector3(0, 0.6f, 0.2f))
            {
                update = false;
            }
            moveFromGameManager = false;
        }
        if (update)
        {
            if (stateChangeable) ChangeState("walk");
            transform.position = Vector3.MoveTowards(transform.position, tilePosition + new Vector3(0, 0.6f, 0.2f), Time.deltaTime * 2);
        }
    }
    public void MoveKnight(Vector3 newPosition)
    {
        bool avmove = false;
        if (movementRange > 0)
        {
            Availablemoves(xvalue, yvalue, movementRange);
        }
        int newxvalue = (int)Math.Round(newPosition.x);
        int newyvalue = (int)Math.Ceiling(-newPosition.z);
        int[] coordinates = { newxvalue, newyvalue };
        foreach (int[] avcoordinates in avMoves)
        {
            if (avcoordinates[0] == coordinates[0] && avcoordinates[1] == coordinates[1])
            {
                avmove = true;
                
            }
        }
        if (avmove)
        {
            tilePosition = newPosition;
            moveFromGameManager = true;
            update = true;
            stateChangeable = true;
            Mapmanager.myUnits[xvalue, yvalue] = null;
            Mapmanager.myUnits[newxvalue, newyvalue] = this;
            int movementspent = Math.Abs(xvalue - newxvalue) + Math.Abs(yvalue - newyvalue);
            movementRange -= movementspent;
            xvalue = newxvalue;
            yvalue = newyvalue;

            avMoves.Clear();
            
        }
        
    }
    // creates List of all tiles available to the unit

    public void Availablemoves(int x, int y, int moves)
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
            if (Mapmanager.Map[y,x] == 0)
            {
                return;
            }
            else if(Mapmanager.GameObjectMap[y,x] != null)
            {
                if (Mapmanager.GameObjectMap[y,x].name == "Building(Clone)")
                {
                    avMoves.Add(coordinates);
                    Availablemoves(x + 1, y, moves - 1);
                    Availablemoves(x - 1, y, moves - 1);
                    Availablemoves(x, y + 1, moves - 1);
                    Availablemoves(x, y - 1, moves - 1);
                }
                else if (Mapmanager.GameObjectMap[y,x].name == "Goldmine(Clone)")
                {
                }
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

    public void Select()
    {
        ParentSelect();
        string number = (owner.number+1).ToString();
        string Attributes = "Owner: Player " + number + "\n Health: " + MUnitHealth + "\n Attack: " + MUnitAttackDamage + "\n Range: " + movementRange + "//" + MaxmovementRange ;
        UpdateText(mUnitName, Attributes);
    }
    public void Deselect()
    {
      ParentDeselect();
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
    


}
