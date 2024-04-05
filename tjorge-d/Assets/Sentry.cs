using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentry : MonoBehaviour{

	public float	rotationSpeed;
	public float	distance;

	void Start(){

		Physics2D.queriesStartInColliders = false;
	}

	void Update(){
	
		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
		if(hitInfo.collider != null){
			Debug.DrawLine(transform.position, hitInfo.point, Color.red);
		}
		else{
			Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
		}
	}
}
