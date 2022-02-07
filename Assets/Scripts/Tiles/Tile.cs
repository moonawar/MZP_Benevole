using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isSelected;
    public GameObject highlightTile;
    Vector3 currentPos; float tileScale;
    private void Awake() {
        currentPos = transform.position;
        tileScale = transform.localScale.x;
    }
    void FindAvailableTile(){
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector3 instancePos = new Vector3((currentPos.x-tileScale) + tileScale*j,
                                    (currentPos.y-tileScale) + tileScale*i, 0);
                if (!isNotAvailable(instancePos)){
                    Instantiate(highlightTile, instancePos, Quaternion.identity);
                }
            }
        }
    }

    bool isNotAvailable(Vector3 pos3){
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
        }
    }

    private void OnMouseUp() {
        if (isSelected)
        {
            isSelected = false;
            UnselectTile();
        } else {
            isSelected = true;
            UnselectTile();
            FindAvailableTile();
        }
        
    }
}
