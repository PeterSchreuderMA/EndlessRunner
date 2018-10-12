using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    //The player script for lives 'n shit
    public float health = 100f;

    [SerializeField]
    private ParticleSystem particleEm50Health;

    [SerializeField]
    private ParticleSystem particleEm25Health;

    // Use this for initialization

    void Start () 
	{
        particleEm50Health.GetComponent<ParticleSystem>();
        particleEm25Health.GetComponent<ParticleSystem>();
    }

	
	
	// Update is called once per frame

	void FixedUpdate () 
	{
        CheckHealth();

    }

    public void GainHealth(float value)
    {
        //Gain some health
        health += value;
        if (health > 100)
            health = 100;
    }

    public void LoseHealth(float value)
    {
        //Lose some health
        health -= value;
        if (health < 0)
            health = 0;
    }

    public void CheckHealth()
    {
        //Kleiner dan 50
        if (health <= 50)
        {
            if (!particleEm50Health.isPlaying)//Als 50 niet speelt
            {
                particleEm50Health.Play();//Speel het af
            }
        }
        else
        {
            if (particleEm50Health.isPlaying)//Als 50 speelt
            {
                particleEm50Health.Stop();//Stop het
            }
        }


        //Kleiner dan 25
        if (health <= 25)
        {
            if (!particleEm25Health.isPlaying)//Als 25 niet speelt
            {
                particleEm25Health.Play();//Speel 25 af
            }

            if (particleEm50Health.isPlaying)//Als 50 speelt
            {
                particleEm50Health.Stop();//Stop het
            }
        }
        else
        {
            if (particleEm25Health.isPlaying)//Als 25 speelt
            {
                particleEm25Health.Stop();//Stop het
            }
        }

        if (health <= 1)
        {
            if (!particleEm25Health.isPlaying)//Als 25 niet speelt
            {
                particleEm25Health.Stop();//Speel 25 af
            }

            if (particleEm50Health.isPlaying)//Als 50 speelt
            {
                particleEm50Health.Stop();//Stop het
            }
        }
    }

}

