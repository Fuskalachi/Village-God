using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Village : MonoBehaviour {

    public static GameObject chiefHut;
    public static GameObject shrine;

    public static int Harvest = 25;
    public static int Wealth = 10;
    public static int Population = 5;
    public static int Happiness = 50;

    public static Dictionary<SecondaryResource, int> secondaryResources = new Dictionary<SecondaryResource, int>();

    public List<RitualBase> rituals = new List<RitualBase>();

	// Use this for initialization
	void Start () {
        chiefHut = GameObject.Find("Chief's Hut");
        shrine = GameObject.Find("Shrine");

        rituals.Add(new RainDance());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
