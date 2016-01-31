using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EventHistory : MonoBehaviour {
    public static List<Text> daysText = new List<Text>();
    public static List<Text> ritualsText = new List<Text>();
    public static List<GameObject> eventPanels = new List<GameObject>();

    void Awake()
    {
        foreach(Transform child in transform)
        {
            eventPanels.Add(child.gameObject);
            daysText.Add(child.GetChild(0).GetComponent<Text>());
            ritualsText.Add(child.GetChild(1).GetComponent<Text>());
        }
        foreach(var text in daysText)
        {
            text.text = "";
        }

        foreach(var text in ritualsText)
        {
            text.text = "";
        }
        foreach(var go in eventPanels)
        {
            go.SetActive(false);
        }
    }

    public static void updateUIList()
    {
        for (int i = EventManager.preferredListCount - 1; i >= EventManager.eventsTracker.Count; i--) {
            daysText[i].text = "";
            ritualsText[i].text = "";
            eventPanels[i].SetActive(false);
        }
        for (int i = 0 ; i < EventManager.eventsTracker.Count; i++)
        {
            eventPanels[i].SetActive(true);
            daysText[i].text = EventManager.eventsTracker[i].dayTriggered < 0 ? "" : EventManager.eventsTracker[i].dayTriggered.ToString();
            ritualsText[i].text = EventManager.eventsTracker[i].name;
            eventPanels[i].SetActive(true);
        }
    }
}
