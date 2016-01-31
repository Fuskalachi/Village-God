using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class OfferWheat : RitualBase {

    public OfferWheat() {
        name = "Offer Wheat";
    }
	
    public override void ritualEffect() {
        List<wheatContextMenu> wheats = new List<wheatContextMenu>(GameObject.FindObjectsOfType<wheatContextMenu>());
        foreach(var wheat in wheats) {
            wheat.doubleHarvest = true;
        }
        dayTriggered = Timer.Days;
        onCoolDown = true;
    }

}
