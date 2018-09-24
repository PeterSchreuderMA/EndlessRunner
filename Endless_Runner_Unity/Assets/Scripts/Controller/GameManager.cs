using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public GameObject playerPrefab;


    private bool gameStarted;
    private TimeManager _timeManager;
    private GameObject player;
    private GameObject floor;
    private Spawner spawner;

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
    }


}

