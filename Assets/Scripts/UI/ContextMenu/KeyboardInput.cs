using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
    GameObject buildMenu;
    bool isBuildButtonDown;
    
    void Awake() {
        isBuildButtonDown = false;
        buildMenu = GameObject.Find("Build Menu");
    }

    void Update() {
        if (Input.GetAxis("Build Shortcut") > 0) {
            if (!isBuildButtonDown) {
                buildMenu.SetActive(!buildMenu.activeSelf);
                isBuildButtonDown = true;
            }
        } else if (Input.GetAxis("Build Shortcut") == 0) {
            isBuildButtonDown = false;
        }
    }
}
