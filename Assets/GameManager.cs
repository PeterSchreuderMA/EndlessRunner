using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public Text TimeText;
    public Text CoinText;
    public Text DistanceText;
    public Text HealthText;
    public GameObject AddCoinText;
    public GameObject AddHealthText;

    //Get the usefull objects
    public GameObject player;
    public GameObject movementLeader;
    public GameObject spawnerL;
    public GameObject spawnerR;

    public GameObject BeginCanvas;
    public GameObject MainCanvas;
    public GameObject EndCanvas;

    public float unitsToMeters = 4f;
    public bool startCountingDistance = true;
    private float distanceTraveled = 0;

    public bool gameStarted;

    public bool gamePauzed;

    private int CoinCount = PlayerPrefs.GetInt("SavedCoins");

    private float timeElapsed = 0f;
    private float bestTime = 0;

    private float blinkTime = 0f;
    private bool blink;

    private bool beatBestTime;






    private TimeManager _timeManager;

	// Use this for initialization

	void Start () 
	{
        _timeManager = GetComponent<TimeManager>();
        //spawnerL = GameObject.Find("SpawnerL");//Get the object
        //spawnerR = GameObject.Find("SpawnerR");//Get the object

        bestTime = PlayerPrefs.GetFloat("BestTime");

        //Activate the begin canvas
        BeginGame();
    }

	
	
	// Update is called once per frame

	void Update () 
	{
        //Check if disctance can be added
        if (startCountingDistance)
        {
            DistanceTraveled();
        }

        if (!gameStarted)
        {
            blinkTime++;

            if (blinkTime % 40 == 0)
            {
                blink = !blink;
            }

            //continueText.canvasRenderer.SetAlpha(blink ? 0 : 1);

            var textColor = beatBestTime ? "#FF0" : "#FFF";

            TimeText.text = "TIME: " + FormatTime(timeElapsed) + "\n<color=" + textColor + ">BEST: " + FormatTime(bestTime) + "</color>";
        }
        else
        {
            timeElapsed += Time.deltaTime;
            TimeText.text = "TIME: " + FormatTime(timeElapsed);

            HealthText.text = player.GetComponent<PlayerScript>().health.ToString() + "%";
            HealthText.color = Color.Lerp(Color.red, Color.green, player.GetComponent<PlayerScript>().health / 100);
        }

    }

    public float DistanceTraveled()
    {
        distanceTraveled = player.transform.position.x * 4;
        DistanceText.text = Math.Round(distanceTraveled) + "m";
        return distanceTraveled;
    }

    //"Reset the game"
    void ResetGame()
    {
        spawnerL.transform.position = new Vector3(50, spawnerL.transform.position.y, spawnerL.transform.position.z);
        spawnerR.transform.position = new Vector3(20, spawnerR.transform.position.y, spawnerR.transform.position.z);

        gameStarted = true;

        timeElapsed = 0;

        beatBestTime = false;
    }


    //When the player gets killed
    void OnPlayerKilled()
    {
        spawnerL.transform.position = new Vector3(50, spawnerL.transform.position.y, spawnerL.transform.position.z);
        spawnerR.transform.position = new Vector3(-15, spawnerR.transform.position.y, spawnerR.transform.position.z);

        //spawnerL.GetComponent<ObstacleSpawner>().active = false;
        //spawnerR.GetComponent<ObstacleSpawner>().active = false;

        gameStarted = false;
        //Debug.Log("Player got killed (Time Scale): " + Time.timeScale);

        //continueText.text = "PRESS ANY BUTTON TO RESTART";

        if (timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;
        }
    }

    //Add a Coin
    public void AddCoin()
    {
        PlayerPrefs.SetInt("SavedCoins", 20);//Add a coin to the existing coins
        //CoinCount++;
        UpdateCoinText();
        AddCoinText.GetComponent<TextTimeNonActive>().ActivateText("\n+1c");
    }

    //Update the coin text
    public void UpdateCoinText()
    {
        /*if (CoinCount<10)
        CoinText.text = "0" + CoinCount + "c";
        else
        CoinText.text = CoinCount + "c";*/
        MainCanvas.GetComponent<CanvasManagerMain>().UpdateCoin();

    }

    //Repair the players car
    public void CarDamage()
    {
        player.GetComponent<PlayerScript>().LoseHealth(25f);
        AddHealthText.GetComponent<TextTimeNonActive>().ActivateText("-25");
    }

    //Repair the players car
    public void CarRepair()
    {
        player.GetComponent<PlayerScript>().GainHealth(25f);
        AddHealthText.GetComponent<TextTimeNonActive>().ActivateText("+25");
    }

    //When the player gets killed
    public void CarDestroyed()
    {
        EndGame();
    }

    //When player loads the game
    public void BeginGame()
    {
        movementLeader.GetComponent<PlayerMovementLeader>().forwardSpeed = 0;

        spawnerL.transform.position = new Vector3(0, spawnerL.transform.position.y, spawnerL.transform.position.z);
        spawnerR.transform.position = new Vector3(0, spawnerR.transform.position.y, spawnerR.transform.position.z);

        BeginCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        EndCanvas.SetActive(false);

        BeginCanvas.GetComponent<CanvasManagerBegin>().CanvasSetUp();
    }

    //When player plays the game
    public void PlayGame()
    {
        movementLeader.GetComponent<PlayerMovementLeader>().forwardSpeed = 10;

        ResetGame();
        BeginCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        EndCanvas.SetActive(false);
    }

    //When player died
    public void EndGame()
    {
        movementLeader.GetComponent<PlayerMovementLeader>().forwardSpeed = 0;

        BeginCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        EndCanvas.SetActive(true);

        if (timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;
        }
    }

    //Time
    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);


        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

}

