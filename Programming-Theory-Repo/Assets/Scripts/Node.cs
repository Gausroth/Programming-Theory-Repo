using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Interactable
{
    [SerializeField]
    float mineTime, respawnTime;
     
    public override void Interact()
    {
        base.Interact();
        mineTime -= 1 * Time.deltaTime;
        if(mineTime <= 0)
        {
            Debug.Log(gameObject.name + " Mined");

            //TODO
            //Tell RespawnManager to respawn node after respawnTime

            gameObject.SetActive(false);
            
            //TODO
            //Add ore to player inventory
        }
    }
}
