using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CanvasManagerMain : MonoBehaviour
{

    //public Text BestTimeText;
    //public Text RecordDistanceText;
    public Text SavedCoinsText;

    public float BestTime;
    public float RecordDistance;
    public int SavedCoins;


    // Use this for initialization
    void Start ()
    {
        /*PlayerPrefs.SetFloat("BestTime", 60f);
        PlayerPrefs.SetFloat("RecordDistance", 2000f);
        PlayerPrefs.SetInt("SavedCoins", 9);*/


        CanvasSetUp();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //CanvasSetUp();
    }

    //Time
    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);


        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

    public void CanvasSetUp()
    {
        //BestTime = PlayerPrefs.GetFloat("BestTime");
        //BestTimeText.text = "BEST TIME:\n" + FormatTime(BestTime);

        //RecordDistance = PlayerPrefs.GetFloat("RecordDistance");
        //RecordDistanceText.text = "Record Distance:\n" + RecordDistance + "m";

        SavedCoins = PlayerPrefs.GetInt("SavedCoins");

        if (SavedCoins < 10)
            SavedCoinsText.text = "0" + SavedCoins + "c";
        else
            SavedCoinsText.text = SavedCoins + "c";
    }

    public void UpdateCoin()
    {
        SavedCoins = PlayerPrefs.GetInt("SavedCoins");

        if (SavedCoins < 10)
            SavedCoinsText.text = "0" + SavedCoins + "c";
        else
            SavedCoinsText.text = SavedCoins + "c";
    }

    //PlayerPrefs.GetFloat("BestTime");
}
