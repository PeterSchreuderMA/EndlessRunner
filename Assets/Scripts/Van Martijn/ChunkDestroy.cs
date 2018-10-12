using UnityEngine;
using System.Collections;

public class ChunkDestroy : MonoBehaviour
{

    public GameObject outsideScreenPoint;
    
	void Start ()
    {
        outsideScreenPoint = GameObject.Find("OutsideScreenPoint");
	}


	void Update ()
    {
        //Zet de chunks op non-actief
	    if(transform.position.x < outsideScreenPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
	}
}
