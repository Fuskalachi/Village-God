using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class shrineContextMenu : MonoBehaviour {
    public Button sampleButton;
    public GameObject ritualList;
    public static MonoBehaviour currentOffering;
    public static MonoBehaviour currentOffering2;
    public static event Action TriggerRainDanceSummon;
    private List<ContextMenuItem> contextMenuItems;
    private Dictionary<string, Type> scriptToRitual = new Dictionary<string, Type>() { { "wheatContextMenu", typeof(RainDance) } };

    void Awake()
    {
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> sacrifice = new Action<Image>(OfferWheatAction);
        Action<Image> raindance = new Action<Image>(RainDanceAction);
        Action<Image> insult = new Action<Image>(InsultAction);

        contextMenuItems.Add(new ContextMenuItem("Offer Wheat", sampleButton, sacrifice));
        contextMenuItems.Add(new ContextMenuItem("Rain Dance", sampleButton, raindance));
        contextMenuItems.Add(new ContextMenuItem("Insult", sampleButton, insult));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }
    }

    public void OfferWheatAction(Image contextPanel) {
        if (currentOffering != null && currentOffering.name == "wheatToken") {
            var wheatRitual = new OfferWheat();
            EventManager.AddRitual(wheatRitual);
            Destroy(currentOffering.gameObject);
        }
        Destroy(contextPanel.gameObject);
    }

    public void RainDanceAction(Image contextPanel) {
        RainDance raindance = new RainDance();
        EventManager.AddRitual(raindance);
    }

    public void InsultAction(Image contextPanel) {
        Insult insult = new Insult();
        EventManager.AddRitual(insult);
        insult.triggerLightning();
    }
}
