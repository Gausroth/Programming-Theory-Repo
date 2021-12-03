using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } } // ENCAPSULATION
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
        if (Input.GetMouseButtonDown(0))
        {
            agent.isStopped = false;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

                if (hit.rigidbody != null)
                {
                    SetTarget(hit); // ABSTRACTION
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
            FaceTarget(); // ABSTRACTION

            StopAgent(interactable); // ABSTRACTION
        }
    }

    void SetTarget(RaycastHit hit)
    {
        target = hit.rigidbody.gameObject.transform;
        interactable = target.GetComponent<Interactable>();
        interactable.player = transform.gameObject;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void StopAgent(Interactable target)
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= interactable.radius)
        {
            agent.isStopped = true;
        }
    }
}
