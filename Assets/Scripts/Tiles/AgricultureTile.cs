using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgricultureTile : Tile
{
    public int dailyProduction;
    int currentDay, prevDay; 
    private void Start() {
        FindObjectOfType<Population>().populationCount -= 2;
    }

    void ProduceFood(int value) {
        FindObjectOfType<Food>().foodCount += value;
    }

    private void Update() {
        currentDay = FindObjectOfType<TimeManager>().elapsedDay;
        if (currentDay != prevDay){
            prevDay = currentDay;
            ProduceFood(dailyProduction);
        }
    }    
}
