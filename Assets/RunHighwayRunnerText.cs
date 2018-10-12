using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunHighwayRunnerText : MonoBehaviour
{
    private Text highWayText;

    public float speed = 1;

    public string s = "|";

	// Use this for initialization
	void Start ()
    {
        highWayText = GetComponent<Text>();
        StartCoroutine(RunText());
    }
    

    IEnumerator RunText()
    {
        
        highWayText.text = "Highway Runner\n--"+s+ "--" + s + "--" + s + "-";
        yield return new WaitForSeconds(speed);
        highWayText.text = "Highway Runner\n-" + s + "--" + s + "--" + s + "--";
        yield return new WaitForSeconds(speed);
        highWayText.text = "Highway Runner\n" + s + "--" + s + "--" + s + "--" + s + "";
        yield return new WaitForSeconds(speed);


        StartCoroutine(RunText());
    }
}

/*
highWayText.text = "Highway Runner\n--|------|";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n-|------|-";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n|------|--";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n------|---";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n-----|----";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n----|-----";
yield return new WaitForSeconds(speed);
highWayText.text = "Highway Runner\n---|------";
yield return new WaitForSeconds(speed);
*/