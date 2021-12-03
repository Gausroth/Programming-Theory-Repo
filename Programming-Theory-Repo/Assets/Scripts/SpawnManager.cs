using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; } // ENCAPSULATION

    public new GameObject gameObject { private get; set; } // ENCAPSULATION

    public float timer { private get; set; } // ENCAPSULATION

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
            SpawnNode(gameObject); // ABSTRACTION
        }
    }
    public void SpawnNode(GameObject nodePrefab)
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
