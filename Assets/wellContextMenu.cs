using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class wellContextMenu : MonoBehaviour {
    public Button sampleButton;
    private List<ContextMenuItem> contextMenuItems;

    void Awake() {
        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> fetchWater = new Action<Image>(FetchWaterAction);
        contextMenuItems.Add(new ContextMenuItem("Fetch Water", sampleButton, fetchWater));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }
    }

    public void FetchWaterAction(Image contextPanel) {
        Instantiate(Resources.Load("waterToken"),
                    new Vector3(transform.position.x, transform.position.y + 3, transform.position.z),
                    Quaternion.Euler(0, 45, 0));
        Destroy(contextPanel.gameObject);
    }
}
