using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    public GameObject constructionTile;
    public void SelectPosition(){
        PopUpManager popUp = FindObjectOfType<PopUpManager>(true);
        popUp.gameObject.SetActive(true);
        popUp.tileTypes.SetActive(true);
        
        popUp.source = gameObject;
    }
    
    public void BuildTile(GameObject tile){
        GameObject newTile = Instantiate(constructionTile, transform.position, Quaternion.identity);
        newTile.GetComponent<TileConstruction>().tile = tile;
        newTile.GetComponent<TileConstruction>().buildTime = tile.GetComponent<Tile>().buildingCost.buildingTime;
        tile.GetComponent<Tile>().UnselectTile();
        FindObjectOfType<AudioManager>().PlaySFX("Build");
    }

    
}
