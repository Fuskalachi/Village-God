using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {
    public bool inMotion;
    public bool startDancing;
    private new Rigidbody rigidbody;
    private Animator animator;

    private NavMeshAgent agent;
	// Use this for initialization
	void Awake () {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        inMotion = rigidbody.velocity.x > 0 || rigidbody.velocity.y > 0;
        animator.SetBool("inMotion", inMotion);
        if (!inMotion)
            animator.SetTrigger("startDancing");
	}
}
