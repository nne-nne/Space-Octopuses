using UnityEngine;

// Ta klasa opisuje, jak powinna zachowywać się monetka
public class Collectible : MonoBehaviour
{
    // Ta funckja odpowiada za to, co się stanie, gdy monetka z czymś się zderzy
    public void OnCollisionEnter(Collision other)
    {
        // Dwie kolejne linijki sprawdzają, czy obiekt, z którym monetka się zderza, reprezentuje postać gracza
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            // Zwiększenie licznika monet
            playerController.coins += 1;
            
            // Dezaktywowanie monetki - powoduje to jej zniknięcie z poziomu
            this.gameObject.SetActive(false);
        }
    }
}