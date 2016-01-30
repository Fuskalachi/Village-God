using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class shrineContextMenu : MonoBehaviour {
    public Button sampleButton;                         // sample button prefab
    public GameObject ritualList;
     private List<ContextMenuItem> contextMenuItems;     // list of items in menu

    void Awake()
    {
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> sacrifice = new Action<Image>(SacrificeAction);

        contextMenuItems.Add(new ContextMenuItem("Sacrifice Ritual", sampleButton, sacrifice));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }

    }

    public void SacrificeAction(Image contextPanel) {
        ritualList.SetActive(true);
        Destroy(contextPanel.gameObject);
    }

}
