using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private bool transition;

    public float maxFOV;
    public float zoomRate;
    public float currentFOV;

    void Start()
    {
        currentFOV = GetComponent<Camera>().fieldOfView;
    }

    private void FixedUpdate()
    {
        if (transition)
        {
            if (currentFOV > maxFOV)
            {
                currentFOV -= zoomRate;
                GetComponent<Camera>().fieldOfView = currentFOV;
                Debug.Log("currentFOX = " + currentFOV);
            }
            else if (currentFOV == maxFOV)
            {
                StopCoroutine("ZoomTime");
                transition = false;
            }
        }
    }

    IEnumerator ZoomTime()
    {
        yield return new WaitForSeconds(0.05f);
        
    }

    public void ZoomInTransition()
    {
        StartCoroutine("ZoomTime");
        transition = true;
    }



}
