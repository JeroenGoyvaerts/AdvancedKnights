using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour {

    [SerializeField]
    protected GameObject[] Tiletypes;

    static int[,] map =
    {{0,0,0,0,0,0,0},
     {0,1,1,1,1,1,0},
     {0,1,1,1,1,1,0},
     {0,1,1,1,1,1,0},
     {0,1,1,1,1,1,0},
     {0,1,1,1,1,1,0},
     {0,1,1,1,1,1,0},
     {0,0,0,0,0,0,0 } };
    static int[,] gameObjectMap = new int[map.GetLength(0),map.GetLength(1)];

    

	// Use this for initialization
	void Start () {
        GameObject tile;
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
}


