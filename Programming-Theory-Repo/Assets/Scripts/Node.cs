using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Interactable // INHERITANCE
{
    public float mineTime, respawnTime, mineTimer;
    [SerializeField]
    string nodeType;

    public HUD hud;

    public override void Interact() // POLYMORPHISM
    {
        base.Interact();
        mineTimer -= 1 * Time.deltaTime;
        if(mineTimer <= 0)
        {
            Debug.Log(gameObject.name + " Mined");

            gameObject.SetActive(false);

            AddOre(nodeType); // ABSTRACTION

            SpawnManager.Instance.gameObject = gameObject;
            SpawnManager.Instance.timer = respawnTime;
        }
    }

    void AddOre(string nodeType)
    {
        switch (nodeType)
        {
            case "stone":
                GameManager.Instance.stone++;
                break;
            case "tin":
                GameManager.Instance.tin++;
                break;
            case "copper":
                GameManager.Instance.copper++;
                break;
        }
        hud.UpdateInventory();
    }
}
