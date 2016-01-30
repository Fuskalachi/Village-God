using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildingDescriptions : MonoBehaviour {
    public GameObject descriptionWindow;
    
    public void farmDescription() {
        UIReferences.descriptionWindow.SetActive(true);
    }
}
