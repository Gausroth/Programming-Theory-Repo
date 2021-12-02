using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Interactable // INHERITANCE
{
    public float mineTime, mineTimer, respawnTime;
    [SerializeField]
    string nodeType;

    public HUD hud;
    public SpawnManager spawnManager;

    public override void Interact() // POLYMORPHISM
    {
        base.Interact();
        mineTimer -= 1 * Time.deltaTime;
        if(mineTimer <= 0)
        {
            Debug.Log(gameObject.name + " Mined");

            gameObject.SetActive(false);

            AddOre(nodeType);

            spawnManager.gameObject = gameObject;
            spawnManager.timer = respawnTime;
        }
    }

    void AddOre(string nodeType)
    {
        switch (nodeType)
        {
            case "stone":
                GameManager.Instance.Stone++;
                break;
            case "tin":
                GameManager.Instance.Tin++;
                break;
            case "copper":
                GameManager.Instance.Copper++;
                break;
        }
        hud.UpdateInventory();
    }
}
