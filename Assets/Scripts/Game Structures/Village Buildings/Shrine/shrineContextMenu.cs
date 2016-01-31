using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class shrineContextMenu : MonoBehaviour {
    public Button sampleButton;
    public GameObject ritualList;
    public static MonoBehaviour currentOffering;
    private List<ContextMenuItem> contextMenuItems;
    private Dictionary<string, Type> scriptToRitual = new Dictionary<string, Type>() { { "wheatContextMenu", typeof(RainDance) } };

    void Awake()
    {
        scriptToRitual.Add("wheaties", typeof(RainDance));
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> sacrifice = new Action<Image>(SacrificeAction);

        contextMenuItems.Add(new ContextMenuItem("Sacrifice Offering", sampleButton, sacrifice));
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
        Type ritualType = scriptToRitual[currentOffering.GetType().Name];
        RitualBase ritual = Activator.CreateInstance(ritualType) as RitualBase;
        if (ritual.checkRequirements()) {
            EventManager.AddRitual(ritual);
            Destroy(currentOffering.gameObject);
            currentOffering = null;
        }
        Destroy(contextPanel.gameObject);
    }
}
