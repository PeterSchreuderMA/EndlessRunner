using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour 
{

    private GameManager gManager;

    private void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collsion");
        if (collision.gameObject.name == "Player")
        {
            var SameZPos = GameObject.Find("PlayerMoveLeader").transform.position.z;

            //Debug.Log("SameZPos: " + SameZPos);

            if (Mathf.Round(transform.position.z) == Mathf.Round(SameZPos))
            {
                //Debug.Log("CoinCollision");
                gManager.AddCoin();
                Destroy(gameObject);
            }
        }
    }

}

