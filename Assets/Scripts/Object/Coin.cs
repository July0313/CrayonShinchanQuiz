using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.Coin += 1;
        Destroy(this.gameObject);
    }
}
