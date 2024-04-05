using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    bool key_up = false;
    bool key_down = false;
    bool key_left = false;
    bool key_right = false;

    float moveSpeed = 400;
    	
    void Start()
    {
        
    }

    void Update()
    {
        key_up = Input.GetKey(KeyCode.W);
        key_down = Input.GetKey(KeyCode.S);
        key_left = Input.GetKey(KeyCode.A);
        key_right = Input.GetKey(KeyCode.D);
        
        //movement calculator
        float hSpeed = (key_right ? 1 : 0) - (key_left ? 1 : 0);
        float vSpeed = (key_up ? 1 : 0) - (key_down ? 1 : 0);
        hSpeed =hSpeed * moveSpeed * Time.deltaTime;
        vSpeed =vSpeed * moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x += hSpeed;
        pos.y += vSpeed;
        transform.position = pos;
        
        //look angle
        Vector3 mouseWordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float lookAngle = Mathf.Atan2(mouseWordPosition.y - transform.position.y, mouseWordPosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis (lookAngle, Vector3.forward);
    }
}

