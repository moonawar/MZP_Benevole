using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialTile : Tile
{
    int currentDay, prevDay; 
    public int dailyFoodConsumption;
    public GameObject inactive;
    private void OnEnable() {
        FindObjectOfType<Population>().populationCount += 4;
        FindObjectOfType<Population>().maxPopulation += 4;
    }

    private void OnDisable() {
        FindObjectOfType<Population>().populationCount -= 4;
        FindObjectOfType<Population>().maxPopulation -= 4;
    }

    void ConsumeFood(int value){
        if (FindObjectOfType<Food>().foodCount - value >= 0)
        {
            FindObjectOfType<Food>().foodCount -= value;
        } else {
            inactive.SetActive(true);
        }
        
    }

    private void Update() {
        currentDay = FindObjectOfType<TimeManager>().elapsedDay;
        if (currentDay != prevDay){
            prevDay = currentDay;
            ConsumeFood(dailyFoodConsumption);
        }
    }
}
