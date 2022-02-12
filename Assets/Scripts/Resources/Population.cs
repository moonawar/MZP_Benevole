using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Population : MonoBehaviour
{
    public int populationCount = 2;
    public int maxPopulation = 2;
    public ResidentialTile residentialTile;
    public TextMeshProUGUI countUI;

    void Update()
    {
        countUI.text = populationCount.ToString() + "/" + maxPopulation.ToString();
    }
}
