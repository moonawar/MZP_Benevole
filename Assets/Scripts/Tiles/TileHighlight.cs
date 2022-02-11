using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    // private void OnMouseDown() {

    // }
    public void SelectPosition(){
        PopUpManager popUp = FindObjectOfType<PopUpManager>(true);
        popUp.gameObject.SetActive(true);
        popUp.tileTypes.SetActive(true);
        
        popUp.source = gameObject;
    }

    public void BuildTile(GameObject tile){
        Instantiate(tile, transform.position, Quaternion.identity);
        tile.GetComponent<Tile>().UnselectTile();
        FindObjectOfType<AudioManager>().PlaySFX("Build");
    }

    
}
