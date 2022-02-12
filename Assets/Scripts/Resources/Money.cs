using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    int moneyCount;
    public TextMeshProUGUI countUI;

    void Update()
    {
        countUI.text = moneyCount.ToString();
    }
}
