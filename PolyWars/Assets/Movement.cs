using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        float ms = moveSpeed * Time.deltaTime;
		if (Input.GetKey(KeyCode.W)) transform.Translate(Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.forward * ms);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.back * ms);
        if (Input.GetKey(KeyCode.A)) transform.Translate(Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.left * ms);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Vector3.right * ms);

        float rs = rotateSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q)) transform.Rotate(0, -rs, 0);
        if (Input.GetKey(KeyCode.E)) transform.Rotate(0, rs, 0);
        if (Input.GetKey(KeyCode.R)) transform.Rotate(rs, 0, 0);
        if (Input.GetKey(KeyCode.F)) transform.Rotate(-rs, 0, 0);

        transform.position += new Vector3(0, Input.mouseScrollDelta.y, 0);
    }

    public float rotateSpeed;
    public float moveSpeed;
    public float zoomSpeed;
}