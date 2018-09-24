using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public GameObject playerPrefab;
    public Text continueText;
    public Text scoreText;

    private float timeElapsed = 0f;
    private float bestTime = 0f;

    private float blinkTime = 0f;
    private bool blink;
    private bool gameStarted;
    private TimeManager _timeManager;
    private GameObject player;
    private GameObject floor;
    private Spawner spawner;

    private bool beatBestTime;

    // Use this for initialization

    void Awake()
    {
        floor = GameObject.Find("ForeGround");//
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();//Get the script
        _timeManager = GetComponent<TimeManager>();//Get the timemanager for al the time related stuff
    }

    // Use this for initialization

    void Start () 
	{
        var floorHeight = floor.transform.localScale.y;

        var pos = floor.transform.position;
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;

        Time.timeScale = 0;

        Debug.Log("Start (Time Scale): " + Time.timeScale);

        continueText.text = "PRESS ANY BUTTON TO START";

        bestTime = PlayerPrefs.GetFloat("BestTime");
    }

	
	
	// Update is called once per frame

	void Update () 
	{
        Debug.Log("GameStarted = " + gameStarted + " | Time Scale: "+Time.timeScale);
        if (gameStarted != true && Time.timeScale == 0)
        {
            Debug.Log("Look for the keypress to begin (Time Scale): " + Time.timeScale);
            if (Input.anyKeyDown)
            {
                Debug.Log("Start the game (Time Scale): " + Time.timeScale);
                _timeManager.ManipulateTime(1, 1f);
                ResetGame();
            }
        }

        if (!gameStarted)
        {
            blinkTime++;

            if (blinkTime % 40 == 0)
            {
                blink = !blink;
            }

            continueText.canvasRenderer.SetAlpha(blink ? 0 : 1);

            var textColor = beatBestTime ? "#FF0" : "#FFF";

            scoreText.text = "TIME: " + FormatTime(timeElapsed)+"\n<color="+textColor+">BEST: " + FormatTime(bestTime)+"</color>";
        }
        else
        {
            timeElapsed += Time.deltaTime;
            scoreText.text = "TIME: " + FormatTime(timeElapsed);
        }

    }

    //When the player gets killed
    void OnPlayerKilled()
    {
        spawner.active = false;

        var playerDestroyScript = player.GetComponent<DestroyOffScreen>();
        playerDestroyScript.DestroyCallBack -= OnPlayerKilled;//Now unlink this to prefent a memory leak

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _timeManager.ManipulateTime(0, 5.5f);//Slow everything down

        gameStarted = false;
        Debug.Log("Player got killed (Time Scale): " + Time.timeScale);

        continueText.text = "PRESS ANY BUTTON TO RESTART";

        if (timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;
        }
    }


    //"Reset the game"
    void ResetGame()
    {
        spawner.active = true;

        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + 100, 0));

        var playerDestroyScript = player.GetComponent<DestroyOffScreen>();
        playerDestroyScript.DestroyCallBack += OnPlayerKilled;//Now link this to: OnPlayerKilled

        gameStarted = true;

        Debug.Log("Reset the Game (Time Scale): " + Time.timeScale);

        continueText.canvasRenderer.SetAlpha(0);

        timeElapsed = 0;

        beatBestTime = false;
    }

    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);


        return string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);
    }

}

