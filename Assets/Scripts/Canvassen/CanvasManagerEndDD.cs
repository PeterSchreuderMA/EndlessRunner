using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CanvasManagerEndDD : MonoBehaviour
{

    public Text BestTimeText;
    public Text RecordDistanceText;

    public float BestTime;
    public float RecordDistance;


    //Set-up the text 
    void Start ()
    {

        PlayerPrefs.SetFloat("BestTime", 60f);
        PlayerPrefs.SetFloat("RecordDistance", 2000f);

        //Set-up the best time values
        BestTime = PlayerPrefs.GetFloat("BestTime");
        BestTimeText.text = "BEST TIME:\n" + FormatTime(BestTime);
        
        //Set-up the record distance values
        RecordDistance = PlayerPrefs.GetFloat("RecordDistance");
        RecordDistanceText.text = "Record Distance:\n" + RecordDistance + "m";
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Time
    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);

        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

    //PlayerPrefs.GetFloat("BestTime");
}
