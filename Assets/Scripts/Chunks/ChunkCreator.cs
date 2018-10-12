using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCreator : MonoBehaviour 
{
    public GameObject[] chunks;

    private GameManager gManager;

    public ObjectPooler[] objectPools;

    private int chunkSelector;
    private float[] chunkArray;

    private int distanceThreshold = 500;
    private int distanceThresholdMultiplier = 500;

    public int Lanes = 3;

    //[SerializeField]
    //private List<GameObject> ingameChunks = new List<GameObject>();

    private GameObject player;
    private GameObject newChunkBox;
    private float newChunkWidth;


    

    // Use this for initialization

    void Start () 
	{
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.Find("Player");
        newChunkBox = GameObject.Find("newChunkBox");
        newChunkWidth = newChunkBox.transform.localScale.x;
    }

	
	
    
	void Update () 
	{
        if (player.transform.position.x > (newChunkBox.transform.position.x - newChunkWidth/2))
        {
            var newTransform = transform;

            if (Mathf.Round(gManager.DistanceTraveled()) >= distanceThreshold-300)
            {

                //Chunk with board
                GameObject newchunk = objectPools[1].GetPooledObject();
                newchunk.transform.position = new Vector3(newChunkBox.transform.position.x + (newChunkWidth), 0, 0);
                newchunk.transform.GetChild(0).GetChild(0).GetComponent<TextMesh>().text = distanceThreshold + "m";
                newchunk.SetActive(true);

                distanceThreshold = distanceThreshold + distanceThresholdMultiplier;
            }
            else
            {
                //Normal chunk
                GameObject newchunk2 = objectPools[0].GetPooledObject();
                newchunk2.transform.position = new Vector3(newChunkBox.transform.position.x + (newChunkWidth), 0, 0);
                newchunk2.SetActive(true);
            }

            

            newChunkBox.transform.position = new Vector3(newChunkBox.transform.position.x + newChunkWidth,  newChunkBox.transform.position.y,  newChunkBox.transform.position.z);
        }
			
	}

    //Color ChooseColor()
    //{
    //    int _newColor;
    //    int _newColorArray[];



    //    return _newColor;
    //}


}

