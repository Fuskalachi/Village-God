﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Village : MonoBehaviour {

    public static GameObject chiefHut;
    public static GameObject shrine;

    public static int Harvest = 25;
    public static int Wealth = 10;
    public static int Population = 10;
    public static int Happiness = 50;
    public static int Workers = 2;
    public static float workersPerPopulation = 5;
    public static Village VillageScript;

    public static Dictionary<SecondaryResource, int> secondaryResources = new Dictionary<SecondaryResource, int>();

    public static List<RitualBase> rituals = new List<RitualBase>();

    private Text harvestText;
    private Text wealthText;
    private Text populationText;
    private Text happinessText;
    private Text idleText;
    private Image happinessBar;

	// Use this for initialization
	void Start () {
        chiefHut = GameObject.Find("Chief's Hut");
        shrine = GameObject.Find("Shrine");
        VillageScript = gameObject.GetComponent<Village>();

        harvestText = GameObject.Find("Harvest Text").GetComponent<Text>();
        wealthText = GameObject.Find("Wealth Text").GetComponent<Text>();
        populationText = GameObject.Find("Population Text").GetComponent<Text>();
        happinessText = GameObject.Find("Happiness Text").GetComponent<Text>();
        happinessBar = GameObject.Find("Happiness Image").GetComponent<Image>();
        idleText = GameObject.Find("Idle Text").GetComponent<Text>();

        updatePrimaryResourcesUI();

        rituals.Add(new RainDance());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updatePrimaryResources(int newHarvest, int newWealth,
                                int newPopulation, int newHappiness) {
        Harvest = newHarvest;
        Wealth = newWealth;
        Population = newPopulation;
        Happiness = newHappiness;
        Workers = (int) (Population / workersPerPopulation);

        updatePrimaryResourcesUI();
    }

    private void updatePrimaryResourcesUI() {
        harvestText.text = Harvest.ToString();
        wealthText.text = Wealth.ToString();
        populationText.text = Population.ToString();
        happinessText.text = Happiness.ToString();
        idleText.text = Workers.ToString();

        happinessBar.fillAmount = (float)Happiness / 100;
    }
}
