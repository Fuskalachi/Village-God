using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class RitualBase {
    public int[] primaryResourceRequirements = { 0, 0, 0, 0 };
    public Dictionary<SecondaryResource, int> secondaryResourceRequirements = new Dictionary<SecondaryResource, int>();
    public int sacrificeDuration = 0;
    public int effectDelay = 0;
    public int effectDuration = 0;
    public int effectCoolDown = 0;
    protected bool onCoolDown = false;

    public delegate void RitualHandler();
    public RitualHandler ritualTrigger;

    public virtual bool checkRequirements() {
        foreach(var requirement in secondaryResourceRequirements) {
            if (Village.secondaryResources[requirement.Key] < requirement.Value)
                return false;
        }
        return true;
    }
    public abstract void ritualEffect();
}
