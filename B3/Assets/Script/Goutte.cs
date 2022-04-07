using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goutte : MonoBehaviour
{
    public GameObject GoutteOriginal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Goutte = Instantiate(GoutteOriginal);
        Goutte.transform.position = new Vector3(-11.474f, 0.8927f, -52.73833f);
        Goutte.GetComponent<Rigidbody>().useGravity = true;
        Destroy(Goutte, 3);
    }
}
