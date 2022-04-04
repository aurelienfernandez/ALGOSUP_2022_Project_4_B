using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public struct NpcPath //create a struct to build the path of the NPC and program the caracteristics of each of its steps
{
    public bool waitTime; //if true, the player has to wait for a certain time before going to the next step 
    public bool waitCondition; //if true, the player has to wait that a certain condition from another GO is checked before going to the next step
    public bool waitTimeAndCondition; //if true, the player has both to wait for a certain time and the condition

    public Transform area;//location of a path's step

    public CheckCondition myScript;//script connected to a specific GO for a particular step

    public float WaitingTime;//indicates how much the player has to wait (in seconds) before going to the next step (if waitTime is TRUE)
}

public class NPCRoaming : MonoBehaviour
{
    private NavMeshAgent nav;// Create a navmeshAgent for the NPC

    public int priority; //set the NPC's priority
    public static int otherPriority; //set the priority for any other NPC
    public float reachDist = 1.0f;// distance required between the NPC and the step he has to reach before going to the next step
    public float dist;// actual distance between the NPC and a certain step
    public int currentPoint = 0;//counter to indicate the step number of a NPC's path

    //private float prevSpeed;

    

    public NpcPath[] pathMaker;// call the NpcPath struct
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();// get the NavMeshAgent component's value of the NPC

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(pathMaker[currentPoint].area.position, transform.position);//set the NPC <--> step distance
        nav.SetDestination(pathMaker[currentPoint].area.position);// Make the NPC move towards the area he has to reach       

        Debug.Log(nav.name + " has a priority of: " + priority);//show the NPC's priority
        Debug.Log(nav.name + " 's speed is: " + nav.speed);//show the NPC's speed

        //if (nav.speed != prevSpeed)
        //{
        //    Debug.Log(nav.name + " 's speed is: " + nav.speed);
        //    prevSpeed = nav.speed;
        //}

        TakeAPath();
    }

    private void OnTriggerStay(Collider other) //What happens when a NPC approaches another one
    {
        Debug.Log("Trigger is activated");

        nav.avoidancePriority = priority;
        otherPriority = other.GetComponent<NavMeshAgent>().avoidancePriority;//get the priority of the other NPC
        //when the priority value  of a 1st NavMesh Agent is higher than the priority of a 2nd one,
        //the 2nd agent ignore the first one and move normally, while the 1st one must let the other pass

        //In other terms, when NPC's PRIORITY VALUE +++ --> NPC's actual priority ---

        if (priority == otherPriority)// when the priority of the 2 NPC's is the same
        {
            Debug.Log("Slow down !");
            nav.speed = 2.4f;//The 2 NPC are slowing down as long as they are close to each other
        }

        if (priority > otherPriority)//when the NPC has a higher priority value than the other one
        {
            Debug.Log("STOP");
            nav.isStopped = true;// The NPC will stop and let the other pass as long as they are close to each other
        }

    }

    private void OnTriggerExit(Collider other)//When the NPC are far enough from each other
    {
        nav.isStopped = false;// The NPC with less priority will get back to his path
        nav.speed = 3.5f;//The NPCs will move at their normal speed
    }

    

    void TakeAPath()
    {
        if (dist <= reachDist)// When the distance NPC-Area is less or equal than the required distance
        {
            Debug.Log("Location Reached");
            CheckCondition();// Check if a condition is required to go to the next step or not
        }      
    }

    void CheckCondition()
    { 
        Debug.Log("WaitTime is" + pathMaker[currentPoint].waitTime);//Get a bool state
        Debug.Log("WaitCondition is" + pathMaker[currentPoint].waitCondition);//Get a bool state
        Debug.Log("WaitTimeAndCondition is" + pathMaker[currentPoint].waitTimeAndCondition);//Get a bool state

        if (pathMaker[currentPoint].waitTime == true && pathMaker[currentPoint].waitCondition == false && pathMaker[currentPoint].waitTimeAndCondition == false)
        {//When WaitTime is chosen

            Debug.Log("Wait for" + pathMaker[currentPoint].WaitingTime + "seconds");
            Invoke("GoToNextStep", pathMaker[currentPoint].WaitingTime);// wait for a certain time before calling the GoToNextStep() function
            

        }

        else if (pathMaker[currentPoint].waitCondition == true && pathMaker[currentPoint].waitTime == false && pathMaker[currentPoint].waitTimeAndCondition == false)
        {//When WaitCondition is chosen

            if (pathMaker[currentPoint].myScript.conditionIsChecked == true)
            {//When a certain bool from another GO is true
                Debug.Log("Condition is True");
                GoToNextStep();//Call the GoToNextStep() function
            }

        }

        if (pathMaker[currentPoint].waitTimeAndCondition == true && pathMaker[currentPoint].waitTime == false && pathMaker[currentPoint].waitCondition == false)
        {//When WaitTimeAndCondition is chosen

            if (pathMaker[currentPoint].myScript.conditionIsChecked == true)
            {//When a certain bool from another GO is true
                Debug.Log("Condition is True, just wait for" + pathMaker[currentPoint].WaitingTime + "seconds");
                Invoke("GoToNextStep", pathMaker[currentPoint].WaitingTime);// wait for a certain time before calling the GoToNextStep() function
            }
            
        }

        else if (pathMaker[currentPoint].waitTime == false && pathMaker[currentPoint].waitCondition == false && pathMaker[currentPoint].waitTimeAndCondition == false)
        {//No condition needed
            Debug.Log("You can continue");
            GoToNextStep();//Call the GoToNextStep() function
        }
    }

    void GoToNextStep()//Allow the NPC to go grom a step to another
    {   
        int NumberOfYourPoints = pathMaker.Length;//get the length of the path by number of steps
        Debug.Log("NEXT");

        if (dist <= reachDist)// When the distance NPC-Area is less or equal than the required distance
        {
            currentPoint++;//Increment the path's step counter
        }

        if (currentPoint >= NumberOfYourPoints)//when the counter is higher or equal than the number of steps
        {
            currentPoint = 0;//set the counter back to 0
        }
    }

    //public IEnumerator waitForCondition()
    //{
    //    while (pathMaker[currentPoint].myScript.conditionIsChecked == false)
    //    {
    //        yield return null;
    //    }
    //    yield return new WaitForSeconds(pathMaker[currentPoint].WaitingTime);
    //    GoToNextStep();
    //    //Or replace the two previous lines by:
    //    // Invoke("GoToNextStep", waitTime);
    //}

    void OnDrawGizmos()
    {//When the game isn't played yet, allow the user to view the halos of each step's location by drawing their 3D structure on the scene and view the reach distances
        if (pathMaker.Length > 0)
            for (int i = 0; i < pathMaker.Length; i++)
            {
                if (pathMaker[i].area != null)
                {
                    Gizmos.DrawSphere(pathMaker[i].area.position, reachDist);
                }
            }
    }
}
