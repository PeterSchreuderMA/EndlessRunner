using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;//Get the objects

    public int pooledAmount;//How many do you want?

    List<GameObject> pooledObjects;//Make a list

	void Start ()
    {
        //Platform list
        pooledObjects = new List<GameObject>();

        //Make the instances and set them on non-active
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
	
    //Get the pooled objects
	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }


        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
