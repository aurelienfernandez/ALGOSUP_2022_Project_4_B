using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandireFlaque : MonoBehaviour
{
    public GameObject Flaque;
    float flTaille = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider myTrigger)
    {
        if (myTrigger.gameObject.name == "Goutte(Clone)")
        {
            flTaille += 0.01f;
            Flaque.transform.localScale = new Vector3(flTaille, 0.01f, flTaille);
        }
        
    }
}
