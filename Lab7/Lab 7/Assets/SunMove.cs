using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMove : MonoBehaviour
{
    private int vel = 1;
    private float bounce = 10;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + vel * Time.deltaTime, transform.position.z);
        bounce -= 1 * Time.deltaTime;
        if (bounce <= 0)
        {
            vel *= -1;
            bounce = 10;
        }
    }
}
