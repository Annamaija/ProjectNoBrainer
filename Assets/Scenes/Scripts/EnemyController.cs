using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rBody;

    public GameObject player; //Player reference
    public GameObject enemy; //Enemy reference
    public GameObject gate; // Gate reference

    public float speed; //Enemy's movement speed
    public float distance; //Distance that enemy will stop moving from player
    public float thrust; //Keeps enemy from going through player

    private Transform target; //Target that enemy follows
    private int hit = 0; //Amount of times enemy has hit player
    bool isfollowing;

    private void Start()
    {
        isfollowing = false;
    }
    private void Update()
    {
        if (isfollowing == true)
        {
            EnemyFollow();
        }
    }
    // Enemy starts moving
    public void EnemyWakeUp()
    {
        //enemy.SetActive(true);
        rBody = GetComponent<Rigidbody2D>();
        Debug.Log("Enemy starts moving");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Enemy targets player
        isfollowing = true;
    }

    public void EnemyFollow()
    {

        // Enemy slows down movement when close to player
        if (Vector2.Distance(transform.position, target.position) > distance)
        {
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //MoveTowards(from, to, speed)
            rBody.MovePosition(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
        }
        if (hit >= 5) 
        {
            gate.GetComponent<GateController>().EnemyWins();
        }
    }
    
    //When enemy hits player
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Obstacle") //Obstacle check
        {
            rBody.AddForce(-transform.up * thrust);
        }

        if (collider.gameObject.tag == "Player") //Player check
        { 
            Debug.Log("HIT " + (hit += 1));
            rBody.AddForce(-transform.up * thrust);
        }
    }
}
