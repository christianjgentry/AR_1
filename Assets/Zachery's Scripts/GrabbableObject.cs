using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour {


    public float extraHeight = 0f;
    [SerializeField]
    private float extraThrowPower = 1f;

    private Rigidbody rb;
    [HideInInspector]
    public float throwPower = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        throwPower = (rb.mass * 10f) * extraThrowPower;
        
    }


}
