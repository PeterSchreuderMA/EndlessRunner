using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil
{
    //Make a Dictionary for the pool
    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();


    //Instantiate a GameObject
    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        //Take advantage of using the pool
        var recycledScript = prefab.GetComponent<RecycleGameObject>();

        if (recycledScript != null)//If the object has a recycle script
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        }
        else
        {
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    //Destroy the GameObject
    public static void Destroy(GameObject gameObject)
    {
        //If the GameObject has the Recycle Script attatched
        var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();

        if (recycleGameObject != null)//If the object has the script
        {
            recycleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    //Return the instance of the pool based on the gameobject we're requesting
    private static ObjectPool GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;

        //Acces the dictionary
        if (pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        else //if we dont have the pool object, make it
        {
            var poolContainer = new GameObject(reference.gameObject.name + "_ObjectPool");//Add a name
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }

        return pool;
    }

}
