using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Tile : MonoBehaviour
{
    public bool isSelected; 
    public GameObject highlightTile;
    Vector3 currentPos; float tileScale;

    public GameObject action, buildMode;
    [System.Serializable]
    public class BuildingCost{
        public int population;
        public int material;
        public int buildingTime;
    }

    public BuildingCost buildingCost;

    private void Awake() {
        currentPos = transform.position;
        tileScale = transform.localScale.x;
    }
    public void FindAvailableTile(){
        action.SetActive(false);
        int ot = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 instancePos = new Vector3((currentPos.x-tileScale) + tileScale*j,
                                    (currentPos.y-tileScale) + tileScale*i, 0);
                if (!isNotAvailable(instancePos)){
                    Instantiate(highlightTile, instancePos, Quaternion.identity);
                    ot ++;
                }
            }
        }
        if (ot != 0){
            buildMode.SetActive(true);
        } else {
            UnselectTile();
        }
    }

    public bool isNotAvailable(Vector3 pos3){
        Vector2 pos2 = new Vector2(pos3.x, pos3.y);
        Collider2D coll = Physics2D.OverlapPoint(pos2, LayerMask.GetMask("TileBase"));
        return coll;
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
    }

    public void Select() {
        if (isSelected)
        {
            isSelected = false;
            UnselectTile();
        } else {
            UnselectTile();
            
            isSelected = true;
            action.SetActive(true);
            FindObjectOfType<AudioManager>().PlaySFX("Select");
        }   
    }
    public void Demolish(){
        PopUpManager popUp = FindObjectOfType<PopUpManager>(true);
        popUp.gameObject.SetActive(true);
        popUp.confirmDemolition.SetActive(true);

        popUp.source = gameObject;
        
    }
    
}
