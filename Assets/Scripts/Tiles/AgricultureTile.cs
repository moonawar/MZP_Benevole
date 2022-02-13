using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgricultureTile : Tile
{
    public int dailyProduction;
    int currentDay, prevDay; 
    public GameObject inactive;
    private void Start() {
        if (FindObjectOfType<Population>().populationCount - 2 >= 0)
        {
            FindObjectOfType<Population>().populationCount -= 2;
        } else {
            inactive.SetActive(true);
        }
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
