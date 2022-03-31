using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {

            Debug.Log("collision with player");
            anim.SetBool("character_nearby", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Joueur"))
        {

            Debug.Log("player exit");
            anim.SetBool("character_nearby", false);
        }
    }

}
