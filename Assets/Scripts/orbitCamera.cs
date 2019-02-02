using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitCamera : MonoBehaviour
{
    public GameObject target;

    public float followGoalSpeed = 0.2f;
    public float camSpeed = 10;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followGoalSpeed * Time.deltaTime);
        
        transform.RotateAround (Vector3.zero, new Vector3(0.0f,-1.0f,0.0f),Time.deltaTime * camSpeed);
        
    }
}