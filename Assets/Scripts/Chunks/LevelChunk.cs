using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour 
{
    private int Lanes = 3;

    [SerializeField]
    private Vector2 _size;

    private BoxCollider BoxCollierObject;

    private GameObject BoxCollierObjectExtra;

    private Vector3 BoxCollierObjectSize;

    private Vector3 BoxCollierObjectExtraSize;

    void Start()
    {

        Lanes = GameObject.Find("ChunkManager").GetComponent<ChunkCreator>().Lanes;

        BoxCollierObject = gameObject.transform.Find("FloorRowCollider").GetComponent<BoxCollider>();
        BoxCollierObjectSize = new Vector3(BoxCollierObject.size.x, BoxCollierObject.size.y, Lanes + 1);
        BoxCollierObject.size = BoxCollierObjectSize;
    }

    private void FixedUpdate()
    {
        
        BoxCollierObject.size = BoxCollierObjectSize;
        
    }

    private void OnDrawGizmos()
	{
        Gizmos.DrawWireCube(transform.position, new Vector3(_size.x, _size.y, 1));
    }
}
