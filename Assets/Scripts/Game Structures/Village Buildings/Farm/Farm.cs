using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Farm : MonoBehaviour {
    public static int[] primaryResourceRequirements = { 5, 5, 5, 5 };
    public static Dictionary<SecondaryResource, int> secondaryResourceRequirements = new Dictionary<SecondaryResource, int>();
    public static int timeToBuild = 0;

    public static bool checkResources() {
        if (Village.Harvest < primaryResourceRequirements[0] || Village.Wealth < primaryResourceRequirements[1] ||
            Village.Population < primaryResourceRequirements[2] || Village.Happiness < primaryResourceRequirements[3])
        {
            return false;
        }
        foreach (var requirement in secondaryResourceRequirements)
        {
            if (Village.secondaryResources[requirement.Key] > requirement.Value)
                return false;
        }
        return true;
    }

    public static void subtractResources() {
        int newHarvest = Village.Harvest - primaryResourceRequirements[0];
        int newWealth = Village.Wealth - primaryResourceRequirements[1];
        int newPopulation = Village.Population - primaryResourceRequirements[2];
        int newHappiness = Village.Happiness - primaryResourceRequirements[3];

        Village.VillageScript.updatePrimaryResources(newHarvest, newWealth, newPopulation,
                                                     newHappiness);
    }

    public static void refundResources() {
        int newHarvest = Village.Harvest + primaryResourceRequirements[0];
        int newWealth = Village.Wealth + primaryResourceRequirements[1];
        int newPopulation = Village.Population + primaryResourceRequirements[2];
        int newHappiness = Village.Happiness + primaryResourceRequirements[3];

        Village.VillageScript.updatePrimaryResources(newHarvest, newWealth, newPopulation,
                                                     newHappiness);
    }
}
