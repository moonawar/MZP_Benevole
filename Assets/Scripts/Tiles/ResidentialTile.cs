using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialTile : Tile
{
    int currentDay, prevDay; 
    public int dailyFoodConsumption;
    private void Start() {
        FindObjectOfType<Population>().populationCount += 4;
        FindObjectOfType<Population>().maxPopulation += 4;
    }

    void ConsumeFood(int value){
        FindObjectOfType<Food>().foodCount -= value;
    }

    private void Update() {
        currentDay = FindObjectOfType<TimeManager>().elapsedDay;
        if (currentDay != prevDay){
            prevDay = currentDay;
            ConsumeFood(dailyFoodConsumption);
        }
    }
}
