using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject gameObject;


    public float timer;

    private void Update()
    {
        if(gameObject != null)
        {
            SpawnNode(gameObject);
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
