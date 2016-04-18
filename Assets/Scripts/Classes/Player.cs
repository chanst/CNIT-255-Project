﻿using UnityEngine;
using System.Collections;

public class Player : Person {
    //isKinematic so need tranform.Position to move
    //float health
    //Position position
    //navagent2d agent
    //rigidbody2d rb

    private Vector3 targetpos;
    private const int LeftMouseButton = 0;
    private const int MiddleMouseButton = 2;
    private float velocity = 2f; //units per frame

    void Awake()
    {
        agent = gameObject.AddComponent<NavAgent2D>();  //creates accessor to NavAgent2D script
        rb = gameObject.GetComponent<Rigidbody2D>();
        agent.setvelocity(velocity); //set speed
    }
    
	// Use this for initialization
	void Start () {
        health = 100f;
        pos = transform.position; //use for enemy detection
        targetpos = transform.position; //use form movement
        
	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(transform.position.x, transform.position.y); //get current position
        if (Input.GetMouseButton(LeftMouseButton) == true) //if left mouse on screen
        {
            SetTargetPosition();
        }
        MovePlayer();
    }

    void SetTargetPosition()
    {
        float cameraz = Camera.main.transform.position.z;
        /*float point = 0f;
        Plane plane = new Plane(Vector3.up, transform.position); //creates a plane at player position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Finds a ray pointing from the camera at where the mouse has clicked
        if (plane.Raycast(ray, out point) == true)
        {
            targetpos = ray.GetPoint(point);
        }*/
        targetpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraz));
        //targetpos.z = transform.position.z;
        
        //Debug.Log(Input.mousePosition);
        //Debug.Log(targetpos.ToString());
    }

    void MovePlayer()
    {
        agent.SetDestination(targetpos);

        Debug.DrawLine(transform.position, targetpos, Color.red); //see if it works
    }


}
