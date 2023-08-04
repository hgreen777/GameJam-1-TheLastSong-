using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timer;

    //Timer Text Calc/Change Variables
    [SerializeField]
    int totalTime = 65;
    int time;

    private int minutes;
    private int seconds;

    private string txt;


    //Timer Color Change 
    float transitionDuration;
    Color startColor;
    Color targetColor;

    
    // Start is called before the first frame update
    void Start()
    {
        time = totalTime;
        transitionDuration = totalTime;
        StopCoroutine(Timer());
        StartCoroutine(Timer());
        StartCoroutine(ChangeTextColor());
        //Start Color
        startColor = Color.white;
        targetColor = Color.red;

        timer.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0){
            //Reset Game
            Debug.Log("Game Over!!");
            Start();
        }
    }

    private IEnumerator Timer(){
        while (time >= 0){
            yield return new WaitForSeconds(1);
            time -=1;
            //Update Text
            timer.text =  TimeDisplay();
        }
        yield return null;
    }

    string TimeDisplay(){
        
        minutes= (int)(time / 60);
        seconds = time % 60;


        if (seconds < 10){
            txt = "0" + minutes + ":" + "0" + seconds;
        }else if(seconds <= 0 ){
            txt  = "00:00";
        }else{
            txt = "0" + minutes + ":" + seconds;
        }

        return txt;
    }

    private IEnumerator ChangeTextColor(){
        float elapsedTime = 0;
        
        while (elapsedTime < transitionDuration){
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / transitionDuration);

            Color lerpedColor = Color.Lerp(startColor, targetColor,t);

            timer.color = lerpedColor;

            yield return null;
        }

        timer.color = targetColor;
    }
}
