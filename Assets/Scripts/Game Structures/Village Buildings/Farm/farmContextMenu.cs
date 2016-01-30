using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class farmContextMenu : MonoBehaviour {
    public Button sampleButton;                         // sample button prefab
    private List<ContextMenuItem> contextMenuItems;     // list of items in menu

    void Awake() {
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> harvest = new Action<Image>(HarvestAction);

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
        int newHarvest = Village.Harvest + 1;
        int newWealth = Village.Wealth;
        int newPopulation = Village.Population;
        int newHappiness = Village.Happiness;

        Village.VillageScript.updatePrimaryResources(newHarvest, newWealth, newPopulation, newHappiness);
        Destroy(contextPanel.gameObject);
    }
}
