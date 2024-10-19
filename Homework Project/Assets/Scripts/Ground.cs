using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Optional: You can add properties here if needed
    public float friction = 1.0f; // Example property for ground friction
    public Color groundColor = Color.green; // Example property for ground color


    // Start is called before the first frame update
    void Start()
    {
        // Optionally, set the color of the ground plane for visual distinction
        GetComponent<Renderer>().material.color = groundColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
