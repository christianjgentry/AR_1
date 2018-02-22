using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehavior : MonoBehaviour {

    public float grabDistance = 2;
    public Transform pickupLocation;
    public Transform dropOffLocation;
    private bool isCarrying = false;
    private Vector3 forward;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        forward = transform.forward * grabDistance;
        Debug.DrawRay(transform.position + Vector3.up, forward);
        if (Input.GetButtonDown("Grab"))
        {
            if (!isCarrying)
                AttemptGrab();
            else
                Throw();
        }
	}

    void AttemptGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * .5f, forward, out hit, grabDistance) || Physics.Raycast(transform.position, forward, out hit, grabDistance) || Physics.Raycast(transform.position + Vector3.up, forward, out hit, grabDistance))
        {
            Debug.Log("Something in front");
            if (hit.collider.tag == "grabbable")
            {
                Collider objectColl = hit.collider;

                GrabbableObject grabbedObject;
                if (hit.collider.GetComponent<GrabbableObject>() != null)
                {
                    grabbedObject = hit.collider.GetComponent<GrabbableObject>();
                }
                else
                {
                    Debug.Log("Item " + hit.collider.name + " needs the GrabbableObject script in order to be picked up.");
                    return;
                }
                objectColl.enabled = false;
                hit.transform.position = pickupLocation.position + Vector3.up * grabbedObject.extraHeight;
                hit.transform.parent = pickupLocation;
                if(hit.collider.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody hitRb = hit.collider.GetComponent<Rigidbody>();
                    hitRb.isKinematic = true;
                }
                isCarrying = true;
            }
        }

    }

    void Throw()
    {
        GameObject child = pickupLocation.GetChild(0).gameObject;
        pickupLocation.DetachChildren();
        child.GetComponent<Collider>().enabled = true;
        if (child.GetComponent<Rigidbody>() != null)
        {
            GrabbableObject grabbedObject = child.GetComponent<GrabbableObject>();
            Rigidbody childrb = child.GetComponent<Rigidbody>();
            childrb.isKinematic = false;
            childrb.AddForce(transform.forward * grabbedObject.throwPower, ForceMode.Impulse);
        }
        else
        {
            child.transform.position = dropOffLocation.position;
        }
        isCarrying = false;
    }
}
