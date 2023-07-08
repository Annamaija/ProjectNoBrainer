using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject hand;
    public GameObject e;

    private void OnTriggerEnter2D(Collider2D collider)
    {
            Debug.Log("Player has collected missing hand.");
            hand.SetActive(false);
            e.GetComponent<Enemy>().EnemyWakeUp();
    }
}
