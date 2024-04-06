using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    bool key_up = false;
    bool key_down = false;
    bool key_left = false;
    bool key_right = false;
    
    [SerializeField] bool lockMovement = false;

    float moveSpeed = 500;
    
    BoxCollider2D boxCollider;
    	
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        key_up = Input.GetKey(KeyCode.W);
        key_down = Input.GetKey(KeyCode.S);
        key_left = Input.GetKey(KeyCode.A);
        key_right = Input.GetKey(KeyCode.D);
        
        //look angle
        Vector3 mouseWordPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float lookAngle = Mathf.Atan2(mouseWordPosition.y - transform.position.y, mouseWordPosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis (lookAngle, Vector3.forward);
        
        //movement calculator
        float hSpeed = 0;
        float vSpeed = 0;
        if (lockMovement)
        {
       		hSpeed = (key_right ? 1 : 0) - (key_left ? 1 : 0);
		vSpeed = (key_up ? 1 : 0) - (key_down ? 1 : 0);
	}
	else
	{
		if(key_up)
		{
			hSpeed += Mathf.Cos(lookAngle * Mathf.Deg2Rad);
			vSpeed += Mathf.Sin(lookAngle * Mathf.Deg2Rad);
		}
		if(key_down)
		{
			hSpeed -= Mathf.Cos(lookAngle * Mathf.Deg2Rad);
			vSpeed -= Mathf.Sin(lookAngle * Mathf.Deg2Rad);
		}
		if(key_right)
		{
			hSpeed = Mathf.Cos((lookAngle - 90) * Mathf.Deg2Rad);
			vSpeed = Mathf.Sin((lookAngle - 90) * Mathf.Deg2Rad);
		}
		if(key_left)
		{
			hSpeed = Mathf.Cos((lookAngle + 90) * Mathf.Deg2Rad);
			vSpeed = Mathf.Sin((lookAngle + 90) * Mathf.Deg2Rad);
		}
	}
        hSpeed *= moveSpeed * Time.deltaTime;
        vSpeed *= moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        //horizontal collision
        if(Physics2D.OverlapBox(new Vector2(pos.x + hSpeed,pos.y), boxCollider.size, 0, LayerMask.GetMask("Wall")))
        	hSpeed = 0;
        pos.x += hSpeed;
        //Vertical collision
         if(Physics2D.OverlapBox(new Vector2(pos.x ,pos.y + vSpeed), boxCollider.size, 0, LayerMask.GetMask("Wall")))
        	vSpeed = 0;
        pos.y += vSpeed;
        
        pos.x += hSpeed;
        pos.y += vSpeed;
        transform.position = pos;
        

    }
}

