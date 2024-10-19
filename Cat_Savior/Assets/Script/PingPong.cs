using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float speed = 2.0f;
    public float height = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.PingPong(Time.time * speed, height);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
