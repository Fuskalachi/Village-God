using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseContextMenu : MonoBehaviour {

    void OnGUI() {

        if (Event.current.type == EventType.MouseDown && 
            !RectTransformUtility.RectangleContainsScreenPoint(
                    gameObject.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null)) {
                        Destroy(gameObject);
            }
        }
}
