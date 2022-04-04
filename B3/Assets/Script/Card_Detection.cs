using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Detection : MonoBehaviour
{
   private GameObject scan_light;
   public Material close;
   public Material open;
   public GameObject Door;
   private HingeJoint doorHinge;
   private  JointLimits limits;
   private bool opened;
   private Rigidbody doorRigi; 
   private bool closable=false;
   private void Start() {
       opened=false;
       scan_light= GameObject.Find("light");
        Destroy(Door.GetComponent<HingeJoint>());
        doorRigi=Door.GetComponent<Rigidbody>();
        doorRigi.isKinematic=true;
   }

   private void OnTriggerEnter(Collider other) {
       if(other.tag=="Student"&& opened==false){
           scan_light.GetComponent<Renderer>().material=open;

           Door.AddComponent<HingeJoint>();
           doorHinge= Door.GetComponent<HingeJoint>();

           limits =doorHinge.limits;
           limits.min=0;
           limits.max= 90;
           doorHinge.limits=limits;
           doorHinge.useLimits=true;
           doorRigi.isKinematic=false;
           doorHinge.axis=new Vector3(0,0,1);
           opened=true;

       }
   }

   private void Update() {
       if (opened==true){
           StartCoroutine(closeDoor()); 
       }
       if (Door.transform.rotation== Quaternion.Euler(-90,0,0) && closable==true){
        
           doorRigi.isKinematic=true;
           Destroy(Door.GetComponent<HingeJoint>());
           scan_light.GetComponent<Renderer>().material=close;
           closable=false;
           opened=false;
       }
   }
    IEnumerator closeDoor(){
        yield return new WaitForSeconds(5);
        closable=true;
    }
}

