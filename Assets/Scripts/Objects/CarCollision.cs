using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CarCollision : MonoBehaviour 
{

    private GameManager gManager;

    private GameObject player;

    private void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
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
                //gManager.AddCoin();
                CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
                gManager.CarDamage();
                Destroy(gameObject);
            }
        }
    }

}

