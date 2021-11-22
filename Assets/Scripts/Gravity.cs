using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float g = 9.81f;

    private Rigidbody rb;
    private List<GameObject> planetsInRange;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        planetsInRange = new List<GameObject>();
    }

    
    void Update()
    {
        foreach(GameObject planet in planetsInRange)
        {
            // kierunek działania siły to po prostu znormalizowana różnica wektorów położenia
            Vector3 direction = (planet.transform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, planet.transform.position);
            rb.AddForce(direction * g * rb.mass * planet.GetComponentInParent<Rigidbody>().mass / (distance * distance), ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gravity"))
        {
            planetsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gravity"))
        {
            planetsInRange.Remove(other.gameObject);
        }
    }
}
