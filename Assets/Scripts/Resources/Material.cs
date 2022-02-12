using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Material : MonoBehaviour
{
    int materialCount;
    public ProductionTile productionTile;
    public TextMeshProUGUI countUI;

    void Update()
    {
        countUI.text = materialCount.ToString();
    }
}
