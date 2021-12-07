using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public GameObject player { protected get; set; } // ENCAPSULATION

    protected virtual void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= radius)
            {
                Interact();
            }
        }
    }
    public virtual void Interact() // ABSTRACTION
    {

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
