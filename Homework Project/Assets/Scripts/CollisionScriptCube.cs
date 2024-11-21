using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScriptCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Why would you run into me?");

        if (collision.gameObject.CompareTag("Cube4"))
        {
            transform.position = new Vector3(-0.3f, 3, -8);
        }



    }
    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {

    }

}
