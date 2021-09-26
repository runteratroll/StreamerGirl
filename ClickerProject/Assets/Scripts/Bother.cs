using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bother : MonoBehaviour
{

    [SerializeField]
    private Transform PoolChating;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("도미>");
        if (collision.gameObject.CompareTag("Chating"))
        {
            Debug.Log("도미>");
            collision.gameObject.transform.SetParent(PoolChating.transform);
            collision.gameObject.SetActive(false);
        }
    }
}
