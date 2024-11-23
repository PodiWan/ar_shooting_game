using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("attacking");
        }
    }
}

