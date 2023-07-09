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

    public Animator myAnim;

    private Transform target; //Target that enemy follows
    private int hit = 0; //Amount of times enemy has hit player
    bool isfollowing;

    private void Start()
    {
        //myAnim = GetComponent<Animator>(); // Controller plays sleep at the start
        Debug.Log("Enemy sleeps");
        myAnim.Play("dog_sleep-animation");
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
        myAnim.Play("dog_runs_animation");
        isfollowing = true;
    }

    public void EnemyFollow()
    {
            // Enemy slows down movement when close to player
            if (Vector2.Distance(transform.position, target.position) > distance)
            {
               transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //MoveTowards(from, to, speed)
            //rBody.MovePosition(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
            }
        if (hit >= 5)
        {
            gate.GetComponent<GateController>().EnemyWins();
        }
    }

    //When enemy hits player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") //Player check
        {
            Debug.Log("HIT " + (hit += 1));

            //float x = transform.position.x * Mathf.Sin(Time.time * .1f) * .1f;
            //float y = transform.position.y;
            //float z = transform.position.z;

            //enemy.transform.position = new Vector3(x, y, z);
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle") //Player check
        {
            Debug.Log("HIT WALL");
        }
    }
}
