using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carriotpickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CarriotManager carriotManager = other.gameObject.GetComponent<CarriotManager>();
            if (carriotManager != null)
            {
                carriotManager.UpdateCarriotCount();
                Destroy(gameObject);
            }
        }
    }
}
