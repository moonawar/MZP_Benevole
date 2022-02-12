using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileTypes : MonoBehaviour
{
    [HideInInspector] public GameObject chosenType;
    public GameObject confirmBuild;
    public TextMeshProUGUI costUI;
    public void ChoseTileType(GameObject tileType){
        chosenType = tileType;
        
        int materialCost = tileType.GetComponent<Tile>().buildingCost.material;
        int populationCost = tileType.GetComponent<Tile>().buildingCost.population;
        costUI.text = "It will cost you " + populationCost + " population and " + materialCost + " material";
        ToConfirm();
    }

    private void ToConfirm(){
        gameObject.SetActive(false);
        confirmBuild.SetActive(true);
    }
}
