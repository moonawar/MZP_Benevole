using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Food : MonoBehaviour
{
    int foodCount;
    public AgricultureTile agricultureTile;
    public TextMeshProUGUI countUI;

    void Update()
    {
        countUI.text = foodCount.ToString();
    }
}
