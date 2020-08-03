using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum motionType
{
    vertical,horizontal
}
public class movingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public motionType MotionType;
    Transform currTargetPoint;
    int currIndx;
    public float speed;
    public float thresholdDistance;
    bool takeBreak;
    Rigidbody2D rb;
    void Start()
    {
        currIndx = 0;
        currTargetPoint = waypoints[currIndx];
        takeBreak = false;
        rb = GetComponent<Rigidbody2D>();

        
    }

    
    void Update()
    {
        //transform.Translate(currTargetPoint.position);
        //if(transform.position==currTargetPoint.position)
        //{
        //    currTargetPoint = waypoints[(currIndx + 1) % waypoints.Length];
        //}

        //transform.Translate(currTargetPoint.position);

        Debug.Log("Current target: "+ Mathf.Round(currTargetPoint.position.x) + ' ' + Mathf.Round(currTargetPoint.position.y) );
        Debug.Log("Transform position: "+ Mathf.Round(transform.position.x) + ' ' + Mathf.Round(transform.position.y) );
        //if ( Mathf.Round(currTargetPoint.position.x)==Mathf.Round(transform.position.x) && Mathf.Round(currTargetPoint.position.y) == Mathf.Round(transform.position.y))
        //{
        //    currIndx = (currIndx + 1) % waypoints.Length;
        //    currTargetPoint = waypoints[currIndx];

        //}

        if (Vector2.Distance(currTargetPoint.position,transform.position) <=thresholdDistance)
        {
            currIndx = (currIndx + 1) % waypoints.Length;
            currTargetPoint = waypoints[currIndx];

        }

        if (!takeBreak)
        {
            //transform.Translate(currTargetPoint.position*speed);
            //rb.MovePosition(currTargetPoint.position*speed  );
            Vector3 dir = currTargetPoint.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            
        }
    }
}
