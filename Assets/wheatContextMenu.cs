using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class wheatContextMenu : MonoBehaviour {
    public Button sampleButton;
    private GameObject Shrine;
    public farmContextMenu parentFarm;
    private List<ContextMenuItem> contextMenuItems;
    public bool doubleHarvest = false;

    void Awake()
    {
        Shrine = GameObject.Find("Shrine");
        contextMenuItems = new List<ContextMenuItem>();

        Action<Image> movetostorage = new Action<Image>(moveToStorage);
        Action<Image> movetosacrifice = new Action<Image>(moveToSacrifice);

        contextMenuItems.Add(new ContextMenuItem("Move to Altar", sampleButton, movetosacrifice));
        contextMenuItems.Add(new ContextMenuItem("Move to Storage", sampleButton, movetostorage));
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            ContextMenu.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
        }
    }

    private void moveToSacrifice(Image contextPanel)
    {
        transform.position = new Vector3(Shrine.transform.position.x,
                                         Shrine.transform.position.y + 3,
                                         Shrine.transform.position.z);
 
        shrineContextMenu.currentOffering = this;
        Destroy(contextPanel.gameObject);
    }

    private void moveToStorage(Image contextPanel)
    {
        int harvestValue = doubleHarvest ? 20 : 10;
        int newHarvest = Village.Harvest + harvestValue;
        Village.VillageScript.updatePrimaryResources(newHarvest,
                                                     Village.Wealth,
                                                     Village.Population,
                                                     Village.Happiness);
        Destroy(transform.gameObject);
        Destroy(contextPanel.gameObject);
    }

}
