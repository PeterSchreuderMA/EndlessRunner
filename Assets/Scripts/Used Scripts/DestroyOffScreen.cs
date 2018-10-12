using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{

    public float offset = 16f;
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallBack;

    private GameObject mainCamera;
    private GameObject SideScreenDebug;

    private bool offscreen;
    private float offscreenX = 0;


    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("MainCameraDolly");// / PixelPerfectCamera.pixelsToUnits
        SideScreenDebug = GameObject.Find("OutsideScreenPoint");// / PixelPerfectCamera.pixelsToUnits

        offscreenX = mainCamera.transform.position.x - ((Screen.width / PixelPerfectCamera3D.pixelsToUnits) / 2);//  - offscreenX; //(Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;//Takes the distance from the center to the right side of the screen.

        SideScreenDebug.transform.position = new Vector3(offscreenX,0,0);
        //Debug.Log("offscreenX: " + offscreenX);
    }

    // Update is called once per frame
    void Update()
    {
        var posX = transform.position.x;
        //var dirX = body2d.velocity.x;

        //Check in absolute if the posX bigger is than offscreenX
        offscreenX = mainCamera.transform.position.x - ((Screen.width / PixelPerfectCamera3D.pixelsToUnits) / 2);

        SideScreenDebug.transform.position = new Vector3(offscreenX, 0, 0);

        var chunkWidth = gameObject.GetComponent<Transform>().localScale.x;

        //var stringW = offscreenX + chunkWidth;
        //Debug.Log("Screen Width: " + PixelPerfectCamera3D.pixelsToUnits);

        if (posX <= offscreenX - (chunkWidth/2))//If the velocity is smaller than 0 and the posX smaller is than the 
            {
                offscreen = true;
            //Debug.Log("Off screen");
        }


        //If offscreen run OnOutOfBounds
        if (offscreen)
        {
            OnOutOfBounds();
        }
    }

    //"Destroy" the object
    public void OnOutOfBounds()
    {
        //Debug.Log("Out of bounds");
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);

        if (DestroyCallBack != null)
        {
            DestroyCallBack();
        }
    }
}
