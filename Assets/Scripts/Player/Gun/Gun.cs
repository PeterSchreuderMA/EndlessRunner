using UnityEngine;

public class Gun : MonoBehaviour 
{

    public float damage = 10f;
    public float range = 10f;

    private InputState _inputState;

    private void Start()
    {
        _inputState = GetComponent<InputState>();
    }

    // Update is called once per frame

    void Update () 
	{
        if (_inputState.ShootButton)
        {
            Shoot();
        }
			
	}

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log("Hit: "+hit.transform.name);
        }


    }


}

