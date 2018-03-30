﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapmanager : MonoBehaviour {

    [SerializeField]
    protected GameObject[] Tiletypes;
    [SerializeField]
    protected Buildings[] building;
    [SerializeField]
    protected Buildings[] goldMine;
    [SerializeField]
    protected Text playerText;
    [SerializeField]
    protected Text goldText;
    [SerializeField]
    protected BuildingUI BuildingUI;
    [SerializeField]
    protected Text selectedNameText;
    [SerializeField]
    protected Text selectedAttributesText;
    [SerializeField]
    protected GameObject selectedPanel;
    [SerializeField]
    protected Camera MainCamera;



    protected int amountOfPlayers = 2;
    protected static List<Player> players = new List<Player>{ };

    static int[,] map =
    {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
     {0,1,1,1,1,1,1,3,1,1,1,1,1,1,1,0},
     {0,1,1,1,2,1,1,1,1,1,1,3,1,1,1,0},
     {0,1,1,3,1,1,1,1,2,1,1,1,1,3,1,0},
     {0,3,1,1,1,1,1,3,1,1,1,2,1,1,1,0},
     {0,1,2,1,3,1,1,1,1,3,1,1,2,1,1,0},
     {0,1,1,1,1,1,1,3,1,1,2,1,1,3,1,0},
     {0,1,1,3,1,1,2,1,1,1,1,1,1,2,1,0},
     {0,1,2,1,1,1,1,1,1,2,1,1,1,1,1,0},
     {0,1,1,3,1,1,1,3,1,1,1,3,1,1,1,0},
     {0,1,1,1,2,1,1,1,1,1,2,1,1,2,1,0},
     {0,1,2,1,1,1,1,1,2,1,1,1,3,3,1,0},
     {0,1,1,1,1,3,1,1,1,1,1,2,1,1,1,0},
     {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };
    static Buildings[,] gameObjectMap = new Buildings[map.GetLength(1), map.GetLength(0)];
    public static Unit[,] myUnits = new Unit[map.GetLength(1), map.GetLength(0)];
    
    static GameObject[,] tiles = new GameObject[map.GetLength(0),map.GetLength(1)];

    int[,] buildings = { { 2, 2, 1 }, {  map.GetLength(1) - 3, map.GetLength(0) - 3,2 } };
    //map.GetLength(1)-3, map.GetLength(0)-3
    int[,] goldMines = { { 7, 5 }, { map.GetLength(1) - 8, map.GetLength(0) - 6 },{5,7 },{ map.GetLength(1) - 6, map.GetLength(0) - 8 } };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Player newplayer = gameObject.AddComponent<Player>() as Player;
            newplayer.number = i;
            newplayer.playerText = playerText;
            newplayer.goldText = goldText;
            newplayer.MainCamera = MainCamera;
            Players.Add(newplayer);
        }
        Gamemanager.Activeplayer = Players[0];
        Gamemanager.Activeplayer.Startturn();

        Buildings aBuilding;
        GameObject tile;
        Vector3 move;
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int tiletype = map[x, y];
                tile = Instantiate(Tiletypes[tiletype]);
                Tiles[x, y] = tile;
                tile.GetComponent<Selected>().selectedNameText = selectedNameText;
                tile.GetComponent<Selected>().selectedAttributesText = selectedAttributesText;
                tile.GetComponent<Selected>().selectedPanel = selectedPanel;
                move = new Vector3(y,0, -x);
                tile.transform.Translate(move);
            }
        }
        for (int i = 0; i < buildings.GetLength(0); i++)
        {
            aBuilding = Instantiate(building[i]);
            aBuilding.GetComponent<Castle>().BuildingUI = BuildingUI;
            aBuilding.selectedNameText = selectedNameText;
            aBuilding.selectedAttributesText = selectedAttributesText;
            aBuilding.selectedPanel = selectedPanel;
            move = new Vector3(buildings[i, 0],0.25f, -buildings[i, 1]+0.5f);
            aBuilding.transform.position = move;
            aBuilding.owner = Players[i];
            aBuilding.owner.buildingPosition = aBuilding.transform.position;

            gameObjectMap[buildings[i, 0], buildings[i, 1]] = aBuilding;

        }
        for (int i = 0; i < goldMines.GetLength(0); i++)
        {
            aBuilding = Instantiate(goldMine[0]);
            aBuilding.selectedNameText = selectedNameText;
            aBuilding.selectedAttributesText = selectedAttributesText;
            aBuilding.selectedPanel = selectedPanel;
            move = new Vector3(goldMines[i, 0], 0.25f, -goldMines[i, 1]+0.5f);
            aBuilding.transform.position = move;

            gameObjectMap[goldMines[i, 0], goldMines[i, 1]] = aBuilding;
        }
        
	}
    protected List<int[]> avMoves =new List<int[]>();

    public static int[,] Map
    {
        get
        {
            return map;
        }
    }

    public static Buildings[,] GameObjectMap
    {
        get
        {
            return gameObjectMap;
        }

        set
        {
            gameObjectMap = value;
        }
    }

    public static List<Player> Players
    {
        get
        {
            return players;
        }

        set
        {
            players = value;
        }
    }

    public static GameObject[,] Tiles
    {
        get
        {
            return tiles;
        }

        set
        {
            tiles = value;
        }
    }
}


