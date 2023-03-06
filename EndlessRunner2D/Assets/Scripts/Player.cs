using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]float horizontalSpeed, flapThrow;
	Rigidbody2D myBody;
	
    void Start()
    {
	    myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    Flap();
    }
	void Flap()
	{
		if(Input.GetButtonDown("Jump"))
			myBody.velocity = new Vector2(horizontalSpeed, flapThrow); 
	}
}
