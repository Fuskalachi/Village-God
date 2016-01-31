using UnityEngine;
using System.Collections;
using System;

public class RainDance : RitualBase {
    public RainDance() {
        name = "Rain Dance";
    }

    public override void ritualEffect() {
        Debug.Log("Rain Dance Effect Triggered");
        dayTriggered = Timer.Days;
        onCoolDown = true;
    }
}
