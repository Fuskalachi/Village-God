using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class RitualBase {
    public string name = "";
    public int[] primaryResourceRequirements = { 0, 0, 0, 0 };
    public Dictionary<SecondaryResource, int> secondaryResourceRequirements = new Dictionary<SecondaryResource, int>();
    public int sacrificeDuration = 0;
    public int effectDelay = 0;
    public int effectDuration = 0;
    public int effectCoolDown = 0;
    public bool onCoolDown = false;
    public int dayTriggered = -1;

    public delegate void RitualHandler();
    public RitualHandler ritualTrigger;

    public virtual bool checkRequirements() {
        if (Village.Harvest < primaryResourceRequirements[0] || Village.Wealth < primaryResourceRequirements[1] ||
            Village.Population < primaryResourceRequirements[2] || Village.Happiness < primaryResourceRequirements[3])
        {
            return false;
        }
        foreach (var requirement in secondaryResourceRequirements)
        {
            if (Village.secondaryResources[requirement.Key] > requirement.Value)
                return false;
        }
        return true;
    }

    public abstract void ritualEffect();
}
