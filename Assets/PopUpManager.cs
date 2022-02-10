using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [HideInInspector] public GameObject source;
    public GameObject confirmBuild, confirmDemolition;
    public GameObject tileTypes;
    public void ConfirmBuild(){
        GameObject instance = tileTypes.GetComponent<TileTypes>().chosenType;
        source.GetComponent<TileHighlight>().BuildTile(instance);
        ResetPopUp();
    }

    public void ResetPopUp(){
        gameObject.SetActive(false);
        confirmBuild.SetActive(false);
        confirmDemolition.SetActive(false);
        tileTypes.SetActive(false);
    }

    public void ConfirmDemolition(){
        if (GameObject.FindGameObjectsWithTag("Tile").Length > 1)
        {
            Destroy(source);
        }
        ResetPopUp();   
    }
}
