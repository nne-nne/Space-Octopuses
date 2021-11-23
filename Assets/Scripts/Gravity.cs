using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // nasza wymyślona stała grawitacyjna
    public float g;

    private Rigidbody rb;

    // w tym miejscu deklarujemy listę planet. To nie wystarczy, żeby móc jej użyć!
    private List<GameObject> planetsInRange;
    
    void Start()
    {
        // po zadeklarowaniu listy, trzeba ją najpierw stworzyć:
        planetsInRange = new List<GameObject>();

        // komponentu rigidbody oczywiście nie tworzymy, ale pobieramy referencję do tego, który już istnieje
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        foreach(GameObject planet in planetsInRange)
        {
            // kierunek działania siły to po prostu różnica wektorów położenia. Normalizujemy go dla wygody.
            Vector3 direction = (planet.transform.position - transform.position).normalized;

            // ta linijka mówi sama za siebie
            float distance = Vector3.Distance(transform.position, planet.transform.position);

            // zgodnie ze wzorem F=GmM/r^2 aplikujemy siłę grawitacji
            rb.AddForce(direction * g * rb.mass * planet.GetComponentInParent<Rigidbody>().mass / (distance * distance), ForceMode.Force);
        }
    }


    /// <summary>
    /// jeśli wpadniemy na trigger i okaże się on planetą, dodajmy tę planetę do naszej listy
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Gravity"))
        {
            planetsInRange.Add(other.gameObject);
        }
    }

    /// <summary>
    /// analogicznie jeśli wyjdziemy z pola grawitacyjnego planety, wyrzućmy ją z listy
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gravity"))
        {
            planetsInRange.Remove(other.gameObject);
        }
    }
}
