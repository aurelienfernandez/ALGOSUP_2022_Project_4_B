using UnityEngine;
using System.Collections;

public class PickableObjects : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    public GameObject hand;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    void Update()
    {
        // check distance entre objet et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si - ou = 1.9 unités de distance = on peut ramasser
        if (dist <= 1.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetKey(KeyCode.Joystick1Button9))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = hand.transform;
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            gameObject.transform.localPosition = new Vector3(0.036f, -0.067f, 0.009f);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(31.346f, -144.144f, 58.377f));
            beingCarried = true;
        }

        // Si on porte l'objet
        if (beingCarried)
        {

            // Clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.9f);
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // Détection de contact grace au collider is trigger
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
