using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour {

    float maxx = 13;
    float maxy = -2;

    float minx =  2;
    float miny = -15;
	// Update is called once per frame
	void Update () {
        
	}
    public void MoveTo(Vector3 myvector)
    {
        this.transform.position = myvector;
    }
    public void Move(float x , float y)
    {
        float xchange = this.transform.position.x + x;
        float ychange = this.transform.position.z + y;
        if (xchange > maxx)
        {
            xchange = maxx;
        }
        else if (xchange < minx)
        {
            xchange = minx;
        }
        if (ychange > maxy)
        {
            ychange = maxy;
        }
        else if (ychange < miny)
        {
            ychange = miny;
        }
        Vector3 newPosition = new Vector3(xchange, this.transform.position.y, ychange);
        this.transform.position = newPosition;
    }
}
