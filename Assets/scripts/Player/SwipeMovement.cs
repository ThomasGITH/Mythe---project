using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{

    private Vector3 startTouchPosition, endTouchPosition, LeftPosition, RightPosition;
    private void Start()
    {
        LeftPosition = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
        RightPosition = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);

    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) { startTouchPosition = Input.GetTouch(0).position; }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended|| Input.anyKeyDown)
        {
           if (Input.touchCount > 0) { endTouchPosition = Input.GetTouch(0).position; }
    
        if (Input.GetKeyDown(KeyCode.A)|| (endTouchPosition.x < startTouchPosition.x))
        {
            if (LeftPosition != transform.position) {
            transform.position = new Vector3(transform.position.x - 2.5f, transform.position.y,transform.position.z);
            }

        }
        if (Input.GetKeyDown(KeyCode.D)|| (endTouchPosition.x > startTouchPosition.x))
        {
            if (RightPosition != transform.position)
            {
                transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
            }

        }
        }
    }
}
