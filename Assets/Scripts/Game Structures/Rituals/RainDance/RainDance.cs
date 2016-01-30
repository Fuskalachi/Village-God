using UnityEngine;
using System.Collections;
using System;

public class RainDance : RitualBase {

	public RainDance() {
        ritualTrigger += ritualEffect;
    }

    public override void ritualEffect() {
        Debug.Log("Rain Dance Effect Triggered");
    }
}
