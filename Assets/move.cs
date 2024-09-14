using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
public float speed = 10.0f;
public float sensitivity = 100.0f;
void Start(){
        transform.Rotate(0,0,0);
}
void Update()
{
    if(Input.GetKey(KeyCode.D))
	{
		transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
	}
	if(Input.GetKey(KeyCode.A))
	{
		transform.Translate(new Vector3(-speed*Time.deltaTime,0,0));
	}
	if(Input.GetKey(KeyCode.S))
	{
		transform.Translate(new Vector3(0,0,-speed*Time.deltaTime));
	}
	if(Input.GetKey(KeyCode.W))
	{
		transform.Translate(new Vector3(0,0,speed*Time.deltaTime));
	}
    if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(-34.98f, 2.36f, -17.19f);
            transform.rotation = new Quaternion(0, 0, 0,0);
        }
    float mouseY = Input.GetAxis("Mouse Y");
    transform.Rotate(Vector3.right,-mouseY*sensitivity*Time.deltaTime);
    float mouseX = Input.GetAxis("Mouse X");
    transform.Rotate(Vector3.up,mouseX*sensitivity*Time.deltaTime,Space.World);
}
}
