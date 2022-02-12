using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [HideInInspector] public GameObject source;
    public GameObject confirmBuild, confirmDemolition, cancel, shortage;
    public GameObject tileTypes;
    int material, population; 

    public void ConfirmBuild(){
        material = FindObjectOfType<Material>().materialCount;
        population = FindObjectOfType<Population>().populationCount;

        GameObject instance = tileTypes.GetComponent<TileTypes>().chosenType;
        int materialCost = instance.GetComponent<Tile>().buildingCost.material;
        int populationCost = instance.GetComponent<Tile>().buildingCost.population;
        
        if (material >= materialCost && population >= populationCost){
            FindObjectOfType<Material>().materialCount = material - materialCost;
            FindObjectOfType<Population>().populationCount = population - populationCost;

            source.GetComponent<TileHighlight>().BuildTile(instance);
            ResetPopUp();
        } else {
            cancel.SetActive(true);
        }
    

    }

    public void ResetPopUp(){
        gameObject.SetActive(false);
        confirmBuild.SetActive(false);
        confirmDemolition.SetActive(false);
        tileTypes.SetActive(false);
        cancel.SetActive(false);
        shortage.SetActive(false);
    }

    public void ConfirmDemolition(){
        if (GameObject.FindGameObjectsWithTag("Tile").Length > 1)
        {
            Destroy(source);
        }
        ResetPopUp();   
    }

    public void Shortage(){
        gameObject.SetActive(true);
        shortage.SetActive(true);
    }
}
