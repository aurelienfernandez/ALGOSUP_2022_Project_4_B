using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Script : MonoBehaviour
{
    public bool active = false;
    private Light[] lights;
    public GameObject lightParent;


    private void Start()
    {
        lights = lightParent.GetComponentsInChildren<Light>(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        active = !active;
        Vector3 tmp = transform.localEulerAngles;

        if (active == true)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
                tmp.x = -4.684f;
                transform.localEulerAngles = tmp;
            }
        }
        else
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
                tmp.x = 4.684f;
                transform.localEulerAngles = tmp;
            }
        }
    }


}