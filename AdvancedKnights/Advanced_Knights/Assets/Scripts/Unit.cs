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
    public List<int[]> avAttacks = new List<int[]>();

    public Vector3 tilePosition;
    Animator anim;

    public Player owner;

    public GameObject SelectedUI;

    public string mUnitName = "Knight";
    public int mUnitCost = 5;
    public int mUnitHealth = 100;
    public int mUnitMaxHealth = 100;

    public int mUnitAttackDamage = 20;
    public int mUnitDefense = 15;

    public int movementRange = 2;
    public int maxMovementRange = 2;

    public int range = 1;

    void Start()
    {
        tilePosition = transform.position;
        anim = GetComponent<Animator>();
    }

    public void OnDrawGizmos()
    {
        //Gizmos.Draw
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
        bool avMove = false;
        bool avAttack = false;
        if (movementRange > 0)
        {
            Deselect();
            avMoves.Clear();
            avAttacks.Clear();
            Availablemoves(xvalue, yvalue, movementRange, 0);

        }
        int newxvalue = (int)Math.Round(newPosition.x);
        int newyvalue = (int)Math.Ceiling(-newPosition.z);
        int[] coordinates = { newxvalue, newyvalue,0,0 };
        foreach (int[] avcoordinates in avMoves)
        {
            if (avcoordinates[0] == coordinates[0] && avcoordinates[1] == coordinates[1])
            {
                avMove = true;
                coordinates[2] = avcoordinates[2];
                
            }
        }
        if (avMove)
        {
            avMoves.Clear();
            if (tilePosition.x < newPosition.x)
            {
                transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);
            }
            else if (tilePosition.x > newPosition.x)
            {
                transform.localScale = new Vector3(-0.5f, transform.localScale.y, transform.localScale.z);
            }
            tilePosition = newPosition;

            moveFromGameManager = true;
            update = true;
            stateChangeable = true;
            Mapmanager.myUnits[xvalue, yvalue] = null;
            Mapmanager.myUnits[newxvalue, newyvalue] = this;
            int movementspent = coordinates[2];
            movementRange -= movementspent;
            if (movementRange < 0)
            {
                movementRange = 0;
            }
            xvalue = newxvalue;
            yvalue = newyvalue;
        }
        else 
        {
            foreach (int[] avcoordinates in avAttacks)
            {
                if (avcoordinates[0] == coordinates[0] && avcoordinates[1] == coordinates[1])
                {
                    avAttack = true;
                    coordinates[2] = avcoordinates[2];
                    coordinates[3] = avcoordinates[3];

                }
            }

            if (avAttack)
            {
                avAttacks.Clear();
                if (coordinates[2] <= range)
                {
                    movementRange = 0;
                    if (coordinates[3] == 0)
                    {
                       
                        Buildings Target = Mapmanager.GameObjectMap[coordinates[0], coordinates[1]];
                        if (Target.name == "Castle(Clone)")
                        {
                           Target.GetComponent<Castle>().TakeDamage(mUnitAttackDamage);
                        }
                        else if (Target.name == "Goldmine(Clone)")
                        {
                            if (Target.owner == null)
                            {
                                tilePosition = newPosition;
                                moveFromGameManager = true;
                                update = true;
                                Target.GetComponent<Goldmine>().TakeDamage(50);
                            }
                            else if (Target.GetComponent<Goldmine>().TakeDamage(mUnitAttackDamage))
                            {
                                tilePosition = newPosition;
                                moveFromGameManager = true;
                                update = true;
                                stateChangeable = true;
                            }
                           

                        }
                        
                    }
                    else
                    {
                        Unit Target = Mapmanager.myUnits[coordinates[0], coordinates[1]];
                        Target.TakeDamage(MUnitAttackDamage);
                        TakeDamage(Target.mUnitDefense);

                    }
                }
            }
        }
        
    }
    // creates List of all tiles available to the unit

    public void Availablemoves(int x, int y, int moves, int range)
    {
        int[] coordinates = { x, y, range, 0 };
        bool continu = true;

        foreach (int[] avcorrdinates in avMoves)
        {
            if (avcorrdinates[0] == coordinates[0] && avcorrdinates[1] == coordinates[1])
            {
                continu = false;
            }
        }

        //make available tiles appear red
        

        //make available tiles appear normal again
        

        if (continu)
        {
            if (Mapmanager.Map[y, x] == 0)
            {
                return;
            }
            else if (Mapmanager.myUnits[x, y] != null)
            {
                Unit myUnit = Mapmanager.myUnits[x, y];
                if (myUnit.owner == Gamemanager.Activeplayer)
                {
                    if (moves >= 1)
                    {
                        Availablemoves(x + 1, y, moves - 1, coordinates[2] + 1);
                        Availablemoves(x - 1, y, moves - 1, coordinates[2] + 1);
                        Availablemoves(x, y + 1, moves - 1, coordinates[2] + 1);
                        Availablemoves(x, y - 1, moves - 1, coordinates[2] + 1);
                    }

                }
                else
                {
                    coordinates[3] = 1;
                    avAttacks.Add(coordinates);
                }

            }
            else if (Mapmanager.GameObjectMap[x, y] != null)
            {
                Buildings MyObject = Mapmanager.GameObjectMap[x, y];
                if (MyObject.name == "Castle(Clone)")
                {
                    if (MyObject.owner == Gamemanager.Activeplayer)
                    {
                        AddANdContinue(x, y, moves, coordinates);
                    }
                    else
                    {
                        avAttacks.Add(coordinates);
                    }

                }
                else if (MyObject.name == "Goldmine(Clone)")
                {
                    if (MyObject.owner != null)
                    {
                        if (MyObject.owner == Gamemanager.Activeplayer)
                        {
                            AddANdContinue(x, y, moves, coordinates);
                        }
                        else
                        {
                            avAttacks.Add(coordinates);
                        }
                    }
                    else
                    {
                        int[] newcoordinates = coordinates;
                        newcoordinates[2] = 1;
                        avAttacks.Add(newcoordinates);
                        Availablemoves(x + 1, y, moves - 1, coordinates[2] + 1);
                        Availablemoves(x - 1, y, moves - 1, coordinates[2] + 1);
                        Availablemoves(x, y + 1, moves - 1, coordinates[2] + 1);
                        Availablemoves(x, y - 1, moves - 1, coordinates[2] + 1);
                    }
                }
            }
            else { AddANdContinue(x, y, moves, coordinates); }
        }


    }

    private void DeHightlightMoves()
    {
        foreach (int[] coordinates in avMoves)
        {
            GameObject tile = Mapmanager.Tiles[coordinates[1], coordinates[0]];

            MeshRenderer meshRenderer = tile.GetComponent<MeshRenderer>();
            meshRenderer.material.color = new Color(0.5333333333333333f, 0.5333333333333333f, 0.5333333333333333f);
            

        }
        avMoves.Clear();
        avAttacks.Clear();
    }

    private void HighlightMoves()
    {
            foreach (int[] coordinates in avMoves)
            {
                GameObject tile = Mapmanager.Tiles[coordinates[1], coordinates[0]];

                MeshRenderer meshRenderer = tile.GetComponent<MeshRenderer>();
                meshRenderer.material.color = new Color(1, 0, 0);
            
            }
    }

    private void AddANdContinue(int x, int y, int moves, int[] coordinates)
    {
        if (moves <= 0)
        {
            avMoves.Add(coordinates);
        }
        else
        {
            avMoves.Add(coordinates);
            Availablemoves(x + 1, y, moves - 1, coordinates[2] + 1);
            Availablemoves(x - 1, y, moves - 1, coordinates[2] + 1);
            Availablemoves(x, y + 1, moves - 1, coordinates[2] + 1);
            Availablemoves(x, y - 1, moves - 1, coordinates[2] + 1);
        }
    }

    public void Select()
    {
        ParentSelect();
        string number = (owner.number+1).ToString();
        string Attributes = "Owner: Player " + number + "\n Health: " + MUnitHealth + "/" + mUnitMaxHealth+ "\n Attack: " + MUnitAttackDamage + "   Defense: " + mUnitDefense + "\n Range: " + movementRange + "//" + maxMovementRange ;
        UpdateText(mUnitName, Attributes);

        Availablemoves(xvalue, yvalue, movementRange, 0);
        HighlightMoves();
    }
    public void Deselect()
    {
        ParentDeselect();
        DeHightlightMoves();
    }
    public void TakeDamage(int damage)
    {
        MUnitHealth -= damage;
        if (MUnitHealth <= 0)
        {
            ChangeState("die");
            Rigidbody deathanimation = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            deathanimation.AddForce(new Vector3(0, 500, 500));
            Mapmanager.myUnits[xvalue, yvalue] = null;
        }
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


}
