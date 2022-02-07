using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    public GameObject tile;
    private void OnMouseDown() {
        Instantiate(tile, transform.position, Quaternion.identity);
        tile.GetComponent<Tile>().UnselectTile();
    }
}
