using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    int elapsedDay; int elapsedWeek;
    int elapsedHour; float nextHour;

    public Slider timeBar; public TextMeshProUGUI timeText;
    bool timePaused; 
    public Image timeButton; public Sprite[] buttonSprites;
    
    void Update()
    {
        if (!timePaused){
            if (Time.time > nextHour){
                elapsedHour ++;
                nextHour = Time.time + 1;
        }

            if (elapsedHour == 24){
                elapsedDay ++;
                elapsedHour = 0;
        }

            if (elapsedDay == 7){
                elapsedWeek ++;
                elapsedDay = 0;
            }

            UIController();
        }
    }

    void PauseTime(){
        timePaused = true;
        timeText.text = "Game Paused";
        timeButton.sprite = buttonSprites[0];
    }
    void StartTime(){
        timePaused = false;
        timeButton.sprite = buttonSprites[1];
    }

    public void ClickHandler(){
        if (timePaused){
            StartTime();
        } else {
            PauseTime();
            
        }
    }

    void UIController(){
        timeBar.value = elapsedHour;
        timeText.text = elapsedWeek + " Week, " + elapsedDay + " Day";
    }
}
