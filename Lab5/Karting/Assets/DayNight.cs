using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField]
    private float setTime;
    private GameObject sun;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("DayNight");
    }

    // Turn the sun until my set time
    private void Update()
    {
        if (triggered)
        {
            float rotateSpeed = 10 * Time.deltaTime;
            transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.right);
            if (sun.transform.rotation.x >= setTime)
            {
                triggered = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
