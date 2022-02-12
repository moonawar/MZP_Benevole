using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionTile : Tile
{
    public int dailyProduction, dailyFoodConsumption;
    
    int currentDay, prevDay; 

    void ProduceMaterial(int value){
        FindObjectOfType<Material>().materialCount += value;
    }

    void ConsumeFood(int value){
        FindObjectOfType<Food>().foodCount -= value;
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
