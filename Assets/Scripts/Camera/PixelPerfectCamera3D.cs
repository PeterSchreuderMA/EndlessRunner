using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera3D : MonoBehaviour
{

    public static float pixelsToUnits = 1f;
    public static float scale = 1f;

    public bool _Debug = false;

    public float cam_pos_x = -10f;
    public float cam_pos_y = 1.5f;
    public float cam_pos_z = 0f;

    public float cam_rot_x = 10f;
    public float cam_rot_y = 45f;
    public float cam_rot_z = 0f;


    /*
    public float cam_pos_x = -15f;
    public float cam_pos_y = 3f;
    public float cam_pos_z = 0f;

    public float cam_rot_x = 12f;
    public float cam_rot_y = 56f;
    public float cam_rot_z = -2.5f;
    */



    public Vector2 nativeResolution = new Vector2(24, 16);

    // Use this for initialization
    void Awake()
    {
        //var camera = GetComponent<Camera>();

        scale = Screen.height / nativeResolution.y;
        pixelsToUnits *= scale;


        //Change the position values of the camera
        var camera_t = GetComponent<Transform>();
        camera_t.localPosition = new Vector3(cam_pos_x, cam_pos_y, cam_pos_z);

        //Change the rotation
        var camera_r = new Vector3(cam_rot_x, cam_rot_y, cam_rot_z);
        camera_t.eulerAngles = camera_r;

    }


    private void Update()
    {
        if (_Debug)
        {
            //Change the position values of the camera
            var camera_t = GetComponent<Transform>();
            camera_t.localPosition = new Vector3(cam_pos_x, cam_pos_y, cam_pos_z);

            //Change the rotation
            var camera_r = new Vector3(cam_rot_x, cam_rot_y, cam_rot_z);
            camera_t.eulerAngles = camera_r;
        }
    }


}
