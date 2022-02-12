using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Population : MonoBehaviour
{
    public int populationCount = 5;
    public int maxPopulation = 5;
    public ResidentialTile residentialTile;
    public TextMeshProUGUI countUI;

    void Update()
    {
        countUI.text = populationCount.ToString() + "/" + maxPopulation.ToString();
    }
}
