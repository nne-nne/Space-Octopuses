using UnityEngine;

public class HideInGame : MonoBehaviour
{
    void Start()
    {
        var cube = gameObject.GetComponent<MeshRenderer>();
        cube.enabled = false;
    }
}
