using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIReferences : MonoBehaviour {
    public static GameObject descriptionWindow;
    public static GameObject buildMenu;
    public static Text descriptionText;
    public static GameObject ritualList;
    
	// Use this for initialization
	void Awake() {
        descriptionWindow = GameObject.Find("Description Window");
        descriptionText = GameObject.Find("UI Description").GetComponent<Text>();
        descriptionWindow.SetActive(false);
        buildMenu = GameObject.Find("Build Menu");
        ritualList = GameObject.Find("Ritual List");
        ritualList.SetActive(false);
	}
}
