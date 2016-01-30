using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RitualDescriptions : MonoBehaviour {

    public void rainDanceDescription() {
        UIReferences.descriptionWindow.SetActive(true);
        UIReferences.descriptionText.text = "Information about the ritual";
    }
}
