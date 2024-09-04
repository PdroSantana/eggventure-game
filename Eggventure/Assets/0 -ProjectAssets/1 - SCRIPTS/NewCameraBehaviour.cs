using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewCameraBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject[] triggersBoxes;
    [SerializeField] private float translateSpeed;

	private void Awake()
	{
        if (GameObject.FindGameObjectsWithTag("CamTrigger") != null) 
        { 
            triggersBoxes = GameObject.FindGameObjectsWithTag("CamTrigger"); 
        }

       
	}
    
     
	void LateUpdate()
    {
        cam.transform.LookAt(target.transform);
    }
	
	public void ChangeAnchors(Collider trigger)
    {
        for(int i = 0; i< triggersBoxes.Length; i++)
		{
            if(trigger == triggersBoxes[i].GetComponent<Collider>())
			{
                //Debug setup just snaps into position
                //cam.transform.position =  trigger.GetComponent<AnchorChanging>().getTrasnform().position;


                //Camera Movement;
                var step = translateSpeed * Time.deltaTime; // calculate distance to move

                Vector3 anchorPos = trigger.GetComponent<AnchorChanging>().getTrasnform().position; //Gets the target pos
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, anchorPos, step);

            }
        }
        
    }
  
    
}


