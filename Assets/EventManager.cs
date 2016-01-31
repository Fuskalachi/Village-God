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
    }

    private void newDayHandler()
    {
        if (eventsTracker.Count != 0)
        {
            if (eventsTracker[0].onCoolDown)
            {
                eventsTracker.RemoveAt(0);
            }
            foreach (var ritual in eventsTracker)
            {
                if (!ritual.onCoolDown)
                {
                    ritual.ritualEffect();
                }
            }
            EventHistory.updateUIList();
        }
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
