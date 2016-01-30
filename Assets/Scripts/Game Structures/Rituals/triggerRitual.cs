using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class triggerRitual : MonoBehaviour {
    public void triggerRitualHandler(int ritualNum) {
        if (ritualNum == Village.rituals.Count) {
            
        } else if (Village.rituals[ritualNum].checkRequirements()) {
            Village.rituals[ritualNum].ritualEffect();
        }
        UIReferences.ritualList.SetActive(false);
    }
}
