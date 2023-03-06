using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
   
	Rigidbody2D myBody;
    void Start()
    {
	    myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    if (Mathf.Abs(myBody.velocity.x)> .001f || Mathf.Abs(myBody.velocity.y) > .001f)
	    {
	    	myBody.gravityScale = 1;
	    }
    }
}
