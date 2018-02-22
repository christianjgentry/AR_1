using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRay : MonoBehaviour {

    private float length = .75f;
    [Range(0, .5f)]
    public float forward = .1f;
    public GameObject player;
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, Vector3.down * length, Color.green);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, length))
        {
            player.transform.Translate(Vector3.up * (length - Vector3.Distance(transform.position, hit.point)) + Vector3.forward * forward);
            Debug.Log(hit.collider.name);
        }
	}
}
