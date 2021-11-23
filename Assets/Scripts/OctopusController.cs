using UnityEngine;

// Ta klasy opisuje, jak powinna zachowywać się ośmiornica
public class OctopusController : MonoBehaviour
{
    // Prędkość liniowa ośmiornicy
    public float speed;

    // Jak blisko musimy podlecieć, żeby zaczęła nas gonić?
    public float dangerDistance;

    // Jak daleko musimy uciec, żeby przestała gonić?
    public float safeDistance;
    
    // Prędkość kątowa ośmiornicy
    public float rotationSpeed;
    
    // Ciało fizyczne
    private Rigidbody rb;
    
    // Postać gracza
    private GameObject player;

    // Czy właśnie goni gracza?
    private bool isChasing;

    // Ta funkcja pobiera z poziomu obiekty, o których ośmiornica musi wiedzieć, aby wykonywać swoje działania
    private void Awake()
    {
        // Znalezienie ciała ośmiornicy
        rb = GetComponent<Rigidbody>();
        
        // Znalezienie gracza
        player = GameObject.FindWithTag("Player");
    }

    /// <summary>
    /// Ta funkcja aktualizuje prędkość i kąt obrotu ośmiornicy
    /// </summary>
    void Chase()
    {
        // Obliczenie zwrotu i ustawienie prędkości zgodnej z nim prędkości
        var direction = (player.transform.position - gameObject.transform.position).normalized;
        rb.velocity = direction * speed;
        // Obracanie w kierunku gracza
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
           Quaternion.LookRotation(direction, Vector3.back), rotationSpeed);
    }

    /// <summary>
    /// "resetowanie" ośmiornicy kiedy gracz ucieknie zbyt daleko
    /// </summary>
    void StopChasing()
    {
        isChasing = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }


    /// <summary>
    /// "Maszyna stanów" ośmiornicy
    /// </summary>
    void Update()
    {
        if (isChasing)
        {
            if(Vector3.Distance(transform.position, player.transform.position) > safeDistance)
            {
                StopChasing();
            }
            else
            {
                Chase();
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) < dangerDistance)
            {
                isChasing = true;
            }
        }
    }
}
