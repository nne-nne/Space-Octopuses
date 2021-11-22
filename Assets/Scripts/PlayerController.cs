using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// zmienna 'speed' będzie decydować o szybkości gracza.
    /// float, czyli liczba zmiennoprzecinkowa.
    /// public, czyli będzie widoczna w Unity w oknie Inspektora.
    /// 
    /// AMBITNIEJ:
    /// [SerializeField] private float speed;
    /// tak zadeklarowana zmienna też jest widoczna w Inspektorze, a dodatkowo jest prywatna.
    /// </summary>
    public float speed;
    public float rotationSpeed;

    /// <summary>
    /// komponent Rigidbody pozwala na fizyczne symulowanie zachowania ciała, a także dostarcza wielu przydatnych funkcji
    /// </summary>
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        /// zanim zaczniemy coś robić z Rigidbody, musimy zdobyć referencję do tego komponentu
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ///Input.GetAxis("Vertical") zwraca liczbę od -1 do 1 w zależności od tego,
        ///czy gracz wcisnął klawisze W,S albo UP_ARROW, DOWN_ARROW
        ///Analogiczne oś "Horizontal" to A,D, strzałka w lewo i strzałka w prawo
        rb.AddForce(transform.forward * Input.GetAxis("Vertical") * speed, ForceMode.VelocityChange)
        transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
    }
}
