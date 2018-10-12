using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNumber
{
    public int[] numbers = { 6, 3, 0 };

    // Use this for initialization

    public ChooseNumber () 
	{
        
        
    }

    public int ReturnNumber()
    {
        int randomIndex = Random.Range(0, numbers.Length);
        int chooseNumber = numbers[randomIndex];
        return chooseNumber;
    }

}

