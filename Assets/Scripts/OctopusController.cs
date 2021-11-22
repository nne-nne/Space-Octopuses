using UnityEngine;

// Ta klasy opisuje, jak powinna zachowywać się ośmiornica
public class OctopusController : MonoBehaviour
{
    // Prędkość liniowa ośmiornicy
    public float speed;
    
    // Prędkość kątowa ośmiornicy
    public float rotationSpeed;
    
    // Ciało fizyczne
    private Rigidbody rb;
    
    // Postać gracza
    private GameObject player;

    // Ta funkcja pobiera z poziomu obiekty, o których ośmiornica musi wiedzieć, aby wykonywać swoje działania
    private void Awake()
    {
        // Znalezienie ciała ośmiornicy
        rb = GetComponent<Rigidbody>();
        
        // Znalezienie gracza
        player = GameObject.FindWithTag("Player");
    }

    // Ta funkcja aktualizuje prędkość i kąt obrotu ośmiornicy
    void Update()
    {
        // Obliczenie zwrotu i ustawienie prędkości zgodnej z nim prędkości
        var direction = (player.transform.position - gameObject.transform.position).normalized;
        rb.velocity = direction * speed;

        // Obracanie w kierunku gracza
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(direction), rotationSpeed);
    }
    
}
