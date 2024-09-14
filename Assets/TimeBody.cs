using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class TimeBody : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRewinding = false;
    List<PointInTime> timePoints;
    Rigidbody rb;
    void Start()
    {
        timePoints = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRewinding = true;
            StartRewinding();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            isRewinding = false;
            StopRewinding();
        } 
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(-34.98f, 3.93f, 0);
            timePoints.Clear();
        }
    }
    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    void Record()
    {
        if(timePoints.Count > Math.Round(5f/Time.fixedDeltaTime)){
            timePoints.RemoveAt(timePoints.Count - 1);
        }
        timePoints.Insert(0, new PointInTime(transform.position,transform.rotation));
    }
    void Rewind()
    {
        if(timePoints.Count>0){
        PointInTime pointInTime = timePoints[0];
        transform.position = pointInTime.position;
        transform.rotation = pointInTime.rotation;
        timePoints.RemoveAt(0);
        }else{
            StopRewinding();
        }
    }
    public void StartRewinding()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    public void StopRewinding()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
