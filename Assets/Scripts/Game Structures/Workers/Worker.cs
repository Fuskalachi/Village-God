using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {
    public bool inMotion;
    public bool startDancing;

    private NavMeshAgent agent;
	// Use this for initialization
	void Awake () {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
