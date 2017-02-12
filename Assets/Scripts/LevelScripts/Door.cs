using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public float speed; 
    public bool opening = false;
    public float maxOpenValue; 
    private float currentValue=0; 
    public Transform door;
    public bool closing = false;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (opening) OpenDoor();
        if (closing) closeDoor();
		
	}
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.transform.name == "Player")
        {
 
                opening = true;
                closing = false;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.transform.name == "Player")
        {
            opening = false;
            closing = true;
        }
    }
    void OpenDoor()
    {
        float movement = speed * Time.deltaTime;
        currentValue += movement;
        if (currentValue <= maxOpenValue)
        {
            door.position = new Vector3(door.position.x + movement, door.position.y, door.position.z);
        }
        else
        {
            opening = false;

        }
   
    }
    void closeDoor()
    {
        float movement = speed * Time.deltaTime;
        currentValue -= movement;
        if (currentValue >=0)
        {
            door.position = new Vector3(door.position.x - movement, door.position.y, door.position.z);
        }
        else
        {
            closing = false;

        }
    }
}
