using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroyOffScreen : MonoBehaviour
{
    private GameObject outsideScreen;


	// Use this for initialization
	void Start ()
    {
        outsideScreen = GameObject.Find("OutsideScreenPoint");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (transform.position.x < outsideScreen.transform.position.x-5)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > outsideScreen.transform.position.x + 100)
        {
            Destroy(gameObject);
        }
    }
}
