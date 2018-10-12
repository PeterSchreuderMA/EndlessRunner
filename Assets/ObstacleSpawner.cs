using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour 
{

    //Make a list for all the Car Obstacles
    public List<GameObject> ObsCars = new List<GameObject>();
    // Use this for initialization

    public float[] ActiveLanes;

    public GameObject[] spawnCheckersL;

    public float timeToActive = 1f;

    private float movementLeaderX;

    public float delay = 2.0f;
    public bool active = false;
    public Vector2 delayRange = new Vector2(1, 2);

    private ChooseNumber numberChooser;

    // Use this for initialization
    void Start()
    {
        ResetDelay();
        StartCoroutine(EnemyGenerator());
        numberChooser = new ChooseNumber();
        movementLeaderX = GameObject.Find("PlayerMoveLeader").GetComponent<Transform>().position.x;
    }

    private void Update()
    {
        movementLeaderX = GameObject.Find("PlayerMoveLeader").GetComponent<Transform>().position.x;
        transform.position = new Vector3(movementLeaderX + 35, -1f, 0);
    }

    IEnumerator ActivateGenerating(float _timeToActive)
    {
        yield return new WaitForSeconds(_timeToActive);
        active = true;
    }
    
    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            var newTransform = transform;
            int randomLane = Mathf.RoundToInt(Random.Range(0, 5));//Select lane from array
            float setLane = ActiveLanes[randomLane];

            Debug.Log("Inst Object");

            GameObject newObstacle = Instantiate(ObsCars[Random.Range(0, ObsCars.Count)], new Vector3(transform.position.x,transform.position.y, setLane), Quaternion.identity);

            if (setLane < 0)//Check the lane they are spaned on
            {
                newObstacle.GetComponent<AddMovement>().XAxesSpeed = 5;
                Debug.Log("Created Forward");
            }
            else
            {
                newObstacle.GetComponent<AddMovement>().XAxesSpeed = -5;
                newObstacle.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 0);//Dafaq Waarom doet dit het niet!?
                Debug.Log("Created Backward");
            }
            ResetDelay();
        }

        StartCoroutine(EnemyGenerator());
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }


}

