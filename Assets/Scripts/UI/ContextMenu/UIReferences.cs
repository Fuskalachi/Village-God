﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIReferences : MonoBehaviour {
    public static GameObject descriptionWindow;
    public static GameObject buildMenu;
    public static Text descriptionText;
    public static GameObject ritualList;
    public static GameObject secondaryResources;
    public static GameObject buildButton;

    // Use this for initialization
    void Awake() {
        descriptionWindow = GameObject.Find("Description Window");
        descriptionText = GameObject.Find("UI Description").GetComponent<Text>();
        buildMenu = GameObject.Find("Build Menu");
        ritualList = GameObject.Find("Ritual List");
        secondaryResources = GameObject.Find("Secondary Resources Panel");
        buildButton = GameObject.Find("Build Button");
	}
    void Start () {
        secondaryResources.SetActive(false);
        ritualList.SetActive(false);
        descriptionWindow.SetActive(false);
    }
}
