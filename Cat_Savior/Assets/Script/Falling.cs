using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = 10 * -Time.deltaTime;
        Vector3 move = new Vector3(0, y, 0);

    }
}
