using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    public bool update;
    public bool stateChangeable = true;

    public Vector3 tilePosition;
    Animator anim;

    // Use this for initialization
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
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {


        


        Debug.Log((Vector3.Distance(transform.position, tilePosition)));
        if (Vector3.Distance(transform.position, tilePosition) < 0.35)
        {
            ChangeState("idle");
            stateChangeable = false;
            if (transform.position == tilePosition + new Vector3(0, 0.15f, 0.3f))
            {
                update = false;
            }
        }
        if (update)
        {       
            if (stateChangeable) ChangeState("walk");
            transform.position = Vector3.Lerp(transform.position, tilePosition + new Vector3(0, 0.15f, 0.3f), Time.deltaTime * 3);
        }
    }

    
}
