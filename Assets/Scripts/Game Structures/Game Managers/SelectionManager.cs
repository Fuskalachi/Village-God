using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionManager : MonoBehaviour {
    public static GameObject selectedUnit = null;
    private Text selectionText;    

    void Start() {
        selectionText = GameObject.Find("Selected Unit").GetComponent<Text>();
    }
    
    void Update() {
        if(Input.GetMouseButton(0)) {
            RaycastHit targetInfo;
            Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(targetRay, out targetInfo)) {
                if(targetInfo.transform.tag == "Interactable Unit") {
                    selectedUnit = targetInfo.transform.gameObject;
                    selectionText.text = targetInfo.transform.gameObject.name;
                } else {
                    selectedUnit = null;
                    selectionText.text = "";
                }
            }
        }
    }
}
