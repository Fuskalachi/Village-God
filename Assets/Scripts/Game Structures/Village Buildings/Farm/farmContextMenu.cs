using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public enum Crop {
    Wheat,
    Tomato,
    Bell_Pepper,
    Carrot
}

public class farmContextMenu : MonoBehaviour {
    public Button sampleButton;                         // sample button prefab
    private List<ContextMenuItem> contextMenuItems;     // list of items in menu
    public Crop? currentCrop = null;
    public GameObject spawnedToken;
    private bool isReadyToHarvest = false;
    private Dictionary<Crop, string> cropToToken = new Dictionary<Crop, string> { { Crop.Wheat, "wheatToken" },
                                                                                  { Crop.Tomato, "tomatoToken" },
                                                                                  { Crop.Bell_Pepper, "bellpeperToken" },
                                                                                  {Crop.Carrot, "carrotToken" } };
     

    void Awake() {
        Timer.TriggerNewDay += farmNewDay;
    
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> harvest = new Action<Image>(HarvestAction);
        Action<Image> planetwheat = new Action<Image>(plantWheat);
        Action<Image> planettomato = new Action<Image>(plantTomato);
        Action<Image> plantcarrot = new Action<Image>(plantCarrot);

        contextMenuItems.Add(new ContextMenuItem("Plant Wheat", sampleButton, plantWheat));
        contextMenuItems.Add(new ContextMenuItem("Plant Tomato", sampleButton, plantTomato));
        contextMenuItems.Add(new ContextMenuItem("Plant Carrot", sampleButton, plantCarrot));
        contextMenuItems.Add(new ContextMenuItem("Harvest", sampleButton, harvest));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }
    }

    void HarvestAction(Image contextPanel) {
        if (isReadyToHarvest && currentCrop != null && spawnedToken == null) {
            spawnedToken = Instantiate(Resources.Load("wheatToken"),
                                       new Vector3(transform.position.x + 1,
                                                   transform.position.y + 3,
                                                   transform.position.z + 1),
                                       Quaternion.Euler(0, 45, 0)) as GameObject;
            spawnedToken.GetComponent<wheatContextMenu>().parentFarm = this;
            currentCrop = null;
        }
        Destroy(contextPanel.gameObject);
    }

    void plantWheat(Image contextPanel) {
        currentCrop = Crop.Wheat;
        Destroy(contextPanel.gameObject);
    }

    void plantTomato(Image contextPanel)
    {
        currentCrop = Crop.Tomato;
        Destroy(contextPanel.gameObject);
    }

    void plantBellPepper(Image contextPanel) {
        currentCrop = Crop.Bell_Pepper;
        Destroy(contextPanel.gameObject);
    }

    void plantCarrot(Image contextPanel) {
        currentCrop = Crop.Carrot;
        Destroy(contextPanel.gameObject);
    }

    void farmNewDay() {
        if (currentCrop != null) {
            isReadyToHarvest = true;
        }
    }
}
