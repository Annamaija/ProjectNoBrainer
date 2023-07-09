using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject hand;
    public GameObject gate;
    public GameObject enemy;

    public AudioClip sound;

    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.2f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    private void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        Debug.Log("Player has collected missing hand.");
        hand.SetActive(false);
        gate.SetActive(true);
        enemy.GetComponent<EnemyController>().EnemyWakeUp();
    }
}