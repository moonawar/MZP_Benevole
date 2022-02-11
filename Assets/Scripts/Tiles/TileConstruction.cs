using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileConstruction : MonoBehaviour
{
    int buildTime; int currentTime; int finishTime;
    bool instatitated; 
    [HideInInspector] public GameObject tile; 
    public TextMeshProUGUI day;
    private void Awake() {
        finishTime = FindObjectOfType<TimeManager>().elapsedDay + 1;
    }

    void OnConstructionEnd(){
        Instantiate(tile, transform.position, Quaternion.identity);
        tile.GetComponent<Tile>().UnselectTile();
        Destroy(gameObject);
    }
    private void Update() {
        currentTime = FindObjectOfType<TimeManager>().elapsedDay;
        if (currentTime >= finishTime && !instatitated){
            instatitated = true;
            OnConstructionEnd();
        }
        day.text = (finishTime-currentTime).ToString();
    }
}
