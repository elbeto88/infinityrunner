using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
   void Update()
    {
	    if(Mathf.Abs(FindObjectOfType<Camera>().transform.position.x - transform.position.x)> 20)
		    Destroy(gameObject);
    }
}
