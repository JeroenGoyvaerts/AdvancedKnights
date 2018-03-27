using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
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
        float ychange = this.transform.position.y + y;
        Vector3 newPosition = new Vector3(xchange, 0, ychange);
        this.transform.position = newPosition;
    }
}
