using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    Vector3 initialPos;
    Quaternion initialRotation;
    public FirstPersonMove move;
    
    public float xDeg;
    public float yDeg;
    public float speed;
    public float lerpSpeed;
    public float objectDistance;
    float friction = 0.5f;
    public Quaternion fromRotation;
    public Quaternion toRotation;
    bool thisObject;

    void Start()
    {
        initialPos = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if(move.enabled == false && thisObject)
        {
            xDeg += Input.GetAxis("Mouse X") * speed * friction;
            yDeg += Input.GetAxis("Mouse Y") * speed * friction;
            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(yDeg,xDeg,0);
            transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime * lerpSpeed);
        }
    }

    public void MoveTo()
    {
        
        if(transform.position == initialPos)
        {
            thisObject = true;
            transform.parent = Camera.main.transform;
            transform.localPosition = new Vector3(0,0,objectDistance);
            move.enabled = false;
        }
        else
        {
            thisObject = false;
            transform.parent = null;
            transform.position = initialPos;
            transform.rotation = initialRotation;
            move.enabled = true;
        }
    }
}
