using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour {

    [SerializeField]
    protected GameObject[] Tiletypes;
    [SerializeField]
    protected GameObject Building;

    protected int amountOfPlayers = 2;
    protected static List<Player> players = new List<Player>{ };

    static int[,] map =
    {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
     {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 } };
    static int[,] gameObjectMap = new int[map.GetLength(0),map.GetLength(1)];

    int[,] buildings = { { 2, 2, 1 }, { map.GetLength(1)-3, map.GetLength(0)-3, 2 } };

	// Use this for initialization
	void Start () {
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Player newplayer = gameObject.AddComponent<Player>() as Player;
            Players.Add(newplayer);
        }

        GameObject tile;
        GameObject aBuilding;
        Vector3 move;
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int tiletype = map[x, y];
                tile = Instantiate(Tiletypes[tiletype]);
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
            aBuilding = Instantiate(Building);
            move = new Vector3(buildings[i, 0],0, -buildings[i, 1]);
            aBuilding.transform.Translate(move);
            aBuilding.GetComponent<Building>().owner = Players[i];
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


