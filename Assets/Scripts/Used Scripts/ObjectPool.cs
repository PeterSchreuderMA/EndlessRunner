using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public RecycleGameObject prefab;//Var for the object pool manager

    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();

    //Create the recycled instance
    private RecycleGameObject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;

        poolInstances.Add(clone);

        return clone;
    }

    //Return the next object in the pool
    public RecycleGameObject NextObject(Vector3 pos)
    {
        RecycleGameObject instance = null;

        //Check the pool of instances
        foreach (var go in poolInstances)
        {
            //Debug.Log("Check the pool of instances");
            if (go.gameObject.activeSelf != true)
            {
                //Debug.Log("activate instances");
                instance = go;
                instance.transform.position = pos;
            }
        }

        //If there is no instance active... Create it!
        if (instance == null)
            instance = CreateInstance(pos);

        //Restart the instance
        instance.Restart();

        return instance;
    }
}
