using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
    public static int preferredListCount = 5;
    public static List<RitualBase> eventsTracker = new List<RitualBase>();

    void Start()
    {
        Timer.TriggerNewDay += newDayHandler;
        var ritual1 = new RainDance();
        ritual1.onCoolDown = true;
        var ritual2 = new RainDance();
        AddRitual(ritual1);
        AddRitual(ritual2);
    }

    private void newDayHandler()
    {
        if (eventsTracker[0].onCoolDown)
        {
            eventsTracker.RemoveAt(0);
        }
        foreach(var ritual in eventsTracker)
        {
            if (!ritual.onCoolDown)
            {
                ritual.ritualEffect();
            }
        }
        EventHistory.updateUIList();
    }

    public static void AddRitual(RitualBase ritual)
    {
        if (eventsTracker.Count >= preferredListCount)
        {
            Debug.Log("Too many rituals");
        } else
        {
            eventsTracker.Add(ritual);
            EventHistory.updateUIList();
        }   
    }
}
