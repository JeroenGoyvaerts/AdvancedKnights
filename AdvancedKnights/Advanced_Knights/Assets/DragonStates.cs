using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStates : MonoBehaviour {
    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }
        
    // Update is called once per frame
    void Update()
    {

       // changeState("attack");
    }

    void changeState(string state)
    {
        switch (state)
        {
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
}
