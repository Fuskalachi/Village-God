using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xDistance = x * xSpeed * Time.deltaTime;
        float yDistance = y * ySpeed * Time.deltaTime;

        Vector3 targetVector = Quaternion.Euler(0, 45, 0) * new Vector3(xDistance, 0, yDistance);

        transform.Translate(targetVector);
	}
}
