using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //public GameObject Enemy;
    public float speed; //Enemy's movement speed
    public float distance; //Distance that enemy will stop moving from player
    //Vector2 movement;

    private Transform target; //Target that enemy follows
    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy starts moving");
        //rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy slows down movement when close to player
        if(Vector2.Distance(transform.position, target.position) > distance){ 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //MoveTowards(from, to, speed)
        }

         //movement.x = Input.GetAxis("Horizontal");
         //movement.y = Input.GetAxis("Vertical");
         //if(!isBouncing) rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    
    //When enemy hits player
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player"){
            Debug.Log("HIT");
        }

        //float bounce = 6f; //amount of force to apply
        //rb.AddForce(collider.contacts[0].normal* bounce);
        //isBouncing = true;
        //Invoke("StopBounce", 0.3f);
    }

    //void StopBounce()
    //{
    //    isBouncing = false;
    //}

}
