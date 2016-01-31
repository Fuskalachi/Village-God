using UnityEngine;
using System.Collections;

public class nativeBehaviorController : MonoBehaviour {

    public bool job = false;
    Vector3 currentPosition;


    // Use this for initialization
    void Start () {
        currentPosition = transform.position;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != currentPosition)
        {
            job = true;
            currentPosition = transform.position;
        }
        else {
            job = false;
        }
    }
}
