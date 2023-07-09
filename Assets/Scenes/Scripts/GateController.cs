using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController: MonoBehaviour
{
    public GameObject gate; //Gate reference
    public GameObject enemy;
    public GameObject player;
    public GameObject lose; // Gameover Panel
    public GameObject win; // Win Panel

    public AudioClip sound;

    private void Start()
    {
        gate.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
    }

    public void EnemyWins()
    {
        player.SetActive(false);
        enemy.SetActive(false);
        lose.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            win.SetActive(true);
            enemy.SetActive(false);
            player.SetActive(false);
        }
    }
}
