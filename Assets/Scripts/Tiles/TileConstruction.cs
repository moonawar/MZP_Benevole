using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileConstruction : MonoBehaviour
{
    int currentTime; int finishTime;
    bool instatitated; 
    [HideInInspector] public GameObject tile; 
    [HideInInspector] public int buildTime;
    public TextMeshProUGUI day;
    private void Start() {
        finishTime = FindObjectOfType<TimeManager>().elapsedDay + buildTime;
    }
    void OnConstructionEnd(){
        Instantiate(tile, transform.position, Quaternion.identity);
        tile.GetComponent<Tile>().UnselectTile();
        
        ResetPopulation();
        FindObjectOfType<AudioManager>().PlaySFX("Done");
        Destroy(gameObject);
    }

    void ResetPopulation(){
        int populationCost = tile.GetComponent<Tile>().buildingCost.population;
        FindObjectOfType<Population>().populationCount += populationCost;
    }

    private void Update() {
        currentTime = FindObjectOfType<TimeManager>().elapsedDay;
        if (currentTime >= finishTime && !instatitated){
            instatitated = true;
            OnConstructionEnd();
        }
        day.text = (finishTime-currentTime).ToString();
    }
}
