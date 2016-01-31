using UnityEngine;
using System.Collections;

public class navmeshtest : MonoBehaviour
{

    NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
		
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit targetInfo;
            Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(targetRay, out targetInfo))
            {
                agent.SetDestination(targetInfo.point);
            }
        }
    }
}
