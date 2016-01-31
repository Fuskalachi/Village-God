using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fence : MonoBehaviour {
    public static int[] primaryResourceRequirements = { 0, 5, 0, 1 };
    public static Dictionary<SecondaryResource, int> secondaryResourceRequirements = new Dictionary<SecondaryResource, int>();
    public static int timeToBuild = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
