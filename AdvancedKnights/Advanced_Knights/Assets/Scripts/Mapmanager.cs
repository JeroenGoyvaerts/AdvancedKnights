using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapmanager : MonoBehaviour {

    [SerializeField]
    protected GameObject[] Tiletypes;
    [SerializeField]
    protected GameObject building;
    [SerializeField]
    protected GameObject goldMine;
    [SerializeField]
    protected Text playerText;
    [SerializeField]
    protected Text goldText;
    [SerializeField]
    protected GameObject BuildingUI;
    [SerializeField]
    protected Text selectedNameText;
    [SerializeField]
    protected Text selectedAttributesText;
    [SerializeField]
    protected GameObject selectedPanel;


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
     {0,1,2,1,1,1,1,1,2,1,1,1,3,1,1,0},
     {0,1,1,1,1,3,1,1,1,1,1,2,1,1,1,0},
     {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };
    static int[,] gameObjectMap = new int[map.GetLength(0),map.GetLength(1)];

    int[,] buildings = { { 2, 2, 1 }, { map.GetLength(1)-3, map.GetLength(0)-3, 2 } };
    int[,] goldMines = { { 5,5}, {map.GetLength(1)-6,map.GetLength(0)-6 } };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Player newplayer = gameObject.AddComponent<Player>() as Player;
            newplayer.number = i;
            newplayer.playerText = playerText;
            newplayer.goldText = goldText;
            Players.Add(newplayer);
        }
        Gamemanager.Activeplayer = Players[0];
        Gamemanager.Activeplayer.Startturn();

        GameObject tile;
        GameObject aBuilding;
        GameObject aGoldMine;
        Vector3 move;
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int tiletype = map[x, y];
                tile = Instantiate(Tiletypes[tiletype]);
                tile.GetComponent<Selected>().selectedNameText = selectedNameText;
                tile.GetComponent<Selected>().selectedAttributesText = selectedAttributesText;
                tile.GetComponent<Selected>().selectedPanel = selectedPanel;
                move = new Vector3(y,0, -x);
                tile.transform.Translate(move);

                if (tiletype == 1)
                {
                    gameObjectMap[x, y] = 1;
                }
                else if (tiletype == 0)
                {
                    gameObjectMap[x, y] = 0;
                }
            }
        }
        for (int i = 0; i < buildings.GetLength(0); i++)
        {
            aBuilding = Instantiate(building);
            aBuilding.GetComponent<Building>().BuildingUI = BuildingUI;
            aBuilding.GetComponent<Selected>().selectedNameText = selectedNameText;
            aBuilding.GetComponent<Selected>().selectedAttributesText = selectedAttributesText;
            aBuilding.GetComponent<Selected>().selectedPanel = selectedPanel;
            move = new Vector3(buildings[i, 0],0, -buildings[i, 1]);
            Debug.Log(buildings[i, 0] + " " + buildings[i, 1]);
            aBuilding.transform.Translate(move);
            aBuilding.GetComponent<Building>().owner = Players[i];
        }
        for (int i = 0; i < goldMines.GetLength(0); i++)
        {
            aGoldMine = Instantiate(goldMine);
            aGoldMine.GetComponent<Selected>().selectedNameText = selectedNameText;
            aGoldMine.GetComponent<Selected>().selectedAttributesText = selectedAttributesText;
            aGoldMine.GetComponent<Selected>().selectedPanel = selectedPanel;
            move = new Vector3(goldMines[i, 0], 0, -goldMines[i, 1]);
            aGoldMine.transform.Translate(move);
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

    public static int[,] GameObjectMap
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
}


