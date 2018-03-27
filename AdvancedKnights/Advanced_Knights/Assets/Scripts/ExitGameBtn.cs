using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameBtn : MonoBehaviour {

	public void exitGameBtn()
    {
        Application.Quit();
        Debug.Log("Exiting game");
    }

}
