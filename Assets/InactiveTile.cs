using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveTile : MonoBehaviour
{
    public GameObject canvas1, canvas2, action;
    public Tile tileScript;
    bool isSelected;
    private void OnEnable() {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        tileScript.enabled = false;

        FindObjectOfType<PopUpManager>(true).Shortage();
    }

    public void ShowAction(){
        if (!isSelected){
            UnselectTile();

            isSelected = true;
            action.SetActive(true);
        } else {
            isSelected = false;
            action.SetActive(false);
            UnselectTile();
        }
    }

    public void ReactivateTile(){
        canvas1.SetActive(true);
        canvas2.SetActive(true);
        tileScript.enabled = true;

        action.SetActive(false);
        gameObject.SetActive(false);

        FindObjectOfType<AudioManager>().PlaySFX("Done");
    }

    public void UnselectTile(){
        GameObject[] highlightTiles = GameObject.FindGameObjectsWithTag("HighlightTile");
        foreach (GameObject h in highlightTiles)
        {
            Destroy(h);
        }

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject t in tiles)
        {
            t.GetComponent<Tile>().isSelected = false;  
            t.GetComponent<Tile>().action.SetActive(false);
            t.GetComponent<Tile>().buildMode.SetActive(false);
        } 
        foreach (InactiveTile it in FindObjectsOfType<InactiveTile>(true))
        {
            it.action.SetActive(false);
            it.isSelected = false;
        }
    }
}
