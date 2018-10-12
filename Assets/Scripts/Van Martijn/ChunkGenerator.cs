using UnityEngine;
using System.Collections;

public class ChunkGenerator : MonoBehaviour
{

    public ObjectPooler[] objectPools;
   

    private int chunkSelector;
    private float[] chunkArray;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;

    public float maxHeightChange;
    private float heightChange;


    // randomiser for chunk selection
    void Start ()
    {
        chunkArray = new float[objectPools.Length];
        
        for(var i = 0; i< objectPools.Length; i++)
        { 
            chunkArray[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }
	
	
    //Random chunk selector 
	void Update ()
    {
        //Als 
	    //if (transform.position.x < generationPoint.position.x)
     //   {
            //distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            chunkSelector = Random.Range(0, objectPools.Length);

            //heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            //if (heightChange > maxHeight)
            //{
            //    heightChange = maxHeight;
            //}
            //else if (heightChange < minHeight)
            //{
            //    heightChange = minHeight;
            //}

            transform.position = new Vector3(transform.position.x + (chunkArray[chunkSelector]/2) + 35, 0, transform.position.z);

            

            transform.position = new Vector3(transform.position.x + (chunkArray[chunkSelector]/2), transform.position.y, transform.position.z);
        //}
	}
}
