using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static List<GameObject> blocks;

    private void Start()
    {
        blocks.Add(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameObject.SetActive(false);            
        }
    }
}
