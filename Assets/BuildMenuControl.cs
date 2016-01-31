using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildMenuControl : MonoBehaviour {
    private GameObject buildMenu;
    private GameObject buildButton;

    void Awake() {
        buildMenu = GameObject.Find("Build Menu");
        buildButton = GameObject.Find("Build Button");
    }

    void Start() {
        buildMenu.SetActive(false);
    }

    public void openBuildMenu() {
        buildMenu.SetActive(true);
        buildButton.SetActive(false);
    }
}
