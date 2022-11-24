using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStatus>(out PlayerStatus p))
        {
            UseItem(p);
        }
    }

    protected virtual void UseItem(PlayerStatus p)
    {
        Destroy(gameObject);
    }
}
