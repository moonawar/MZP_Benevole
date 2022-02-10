using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypes : MonoBehaviour
{
    [HideInInspector] public GameObject chosenType;
    public GameObject confirmBuild;
    public void ChoseTileType(GameObject tileType){
        chosenType = tileType;
        ToConfirm();
    }

    private void ToConfirm(){
        gameObject.SetActive(false);
        confirmBuild.SetActive(true);
    }
}
