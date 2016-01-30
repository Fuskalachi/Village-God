using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public static GameObject primedBuilding = null;

    public static void buildFarm() {
        if (!Farm.checkResources()) {
            Debug.Log("Not enough resources!");
        } else if(primedBuilding == null) {
            Farm.subtractResources();
            primedBuilding = Resources.Load("Farm", typeof(GameObject)) as GameObject;
            Debug.Log(primedBuilding);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && primedBuilding != null) {
            RaycastHit hitInfo;
            Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(targetRay, out hitInfo);
            Debug.Log(hitInfo.collider);
            if (hitInfo.collider.tag == "Terrain") {
                Instantiate(primedBuilding, hitInfo.point, Quaternion.identity);
                primedBuilding = null;
            }
        } else if(primedBuilding != null && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))) {
            primedBuilding = null;
            Farm.refundResources();
        }
    }
}
