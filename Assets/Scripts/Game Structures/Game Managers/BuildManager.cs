using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public static GameObject primedBuilding = null;
    private GameObject Village;

    void Awake()
    {
        Village = GameObject.Find("Village");
    }

    public static void buildFarm() {
        if (!Farm.checkResources()) {
            Debug.Log("Not enough resources!");
        } else if(primedBuilding == null) {
            Farm.subtractResources();
            primedBuilding = Resources.Load("Farm", typeof(GameObject)) as GameObject;
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && primedBuilding != null) {
            RaycastHit hitInfo;
            Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(targetRay, out hitInfo);
            if (hitInfo.collider.tag == "Terrain") {
                GameObject tempGO = Instantiate(primedBuilding, hitInfo.point, Quaternion.identity) as GameObject;
                tempGO.transform.parent = Village.transform;
                primedBuilding = null;
            }
        } else if(primedBuilding != null && (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))) {
            primedBuilding = null;
            Farm.refundResources();
        }
    }
}
