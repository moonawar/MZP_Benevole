using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionTile : Tile
{
    public int dailyProduction, dailyFoodConsumption;
    
    int currentDay, prevDay; 
    public GameObject inactive;

    void ProduceMaterial(int value){
        FindObjectOfType<Material>().materialCount += value;
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
            ProduceMaterial(dailyProduction);
            ConsumeFood(dailyFoodConsumption);
        }
    }
}
