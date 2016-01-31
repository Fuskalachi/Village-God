using UnityEngine;
using System.Collections;

public class navmeshtest : MonoBehaviour
{
    public float MaxRange = 20;
    NavMeshAgent agent;
    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
