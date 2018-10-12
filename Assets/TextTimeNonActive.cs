using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimeNonActive : MonoBehaviour
{

    private Text activeText;
    [SerializeField]
    private float timeToActive = 1;

    // Use this for initialization
    void Start ()
    {
        activeText = GetComponent<Text>();

        activeText.canvasRenderer.SetAlpha(0);
        Debug.Log("Non-Active");
    }

    public void ActivateText(string value)
    {
        activeText.text = value;

        activeText.canvasRenderer.SetAlpha(1);
        Debug.Log("Active");

        StopCoroutine(WaitAndDeactivate(timeToActive));//Stop it

        StartCoroutine(WaitAndDeactivate(timeToActive));//Run it
    }

    private IEnumerator WaitAndDeactivate(float _time)
    {
        yield return new WaitForSeconds(_time);

        activeText.canvasRenderer.SetAlpha(0);
        Debug.Log("Non-Active Coroutine");
    }
}
