using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class farmListener : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            UIReferences.descriptionText.text = "Farm Description";
            UIReferences.descriptionWindow.SetActive(true);
        } else if (eventData.button == PointerEventData.InputButton.Left) {
            BuildManager.buildFarm();
            UIReferences.buildMenu.SetActive(false);
        }
    }
}
