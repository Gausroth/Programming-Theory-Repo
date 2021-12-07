using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //TODO: Need to find a better way to handle node respawning. Currently if a node is being respawned and a nother node is being mined the other node will not respawn.
    public static SpawnManager Instance { get; private set; } // ENCAPSULATION

    public new GameObject gameObject;

    public float timer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(transform.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Update()
    {
        if(gameObject != null)
        {
            SpawnNode(gameObject);
        }
    }
    public void SpawnNode(GameObject nodePrefab) // ABSTRACTION
    {
        Node node = nodePrefab.GetComponent<Node>();

        timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            nodePrefab.SetActive(true);
            node.mineTimer = node.mineTime;
            gameObject = null;
        }
    }
}
