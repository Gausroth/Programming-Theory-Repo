using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public NavMeshAgent agent { get; private set; } // ENCAPSULATION

    [SerializeField]
    Transform target;
    Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(0))
        {
            agent.isStopped = false;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(interactable != null)
                {
                    interactable.player = null;
                }
                agent.SetDestination(hit.point);

                if (hit.rigidbody != null)
                {
                    SetTarget(hit);
                }
                else
                {
                    target = null;
                }
            }
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();

            StopAgent(interactable);
        }
    }

    void SetTarget(RaycastHit hit) // ABSTRACTION
    {
        target = hit.rigidbody.gameObject.transform;
        interactable = target.GetComponent<Interactable>();
        interactable.player = transform.gameObject;
    }
    void FaceTarget() // ABSTRACTION
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void StopAgent(Interactable target) // ABSTRACTION
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= interactable.radius)
        {
            agent.isStopped = true;
        }
    }
}
