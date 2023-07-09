using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator myAnim;

    bool movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = false;
        playerIdles();
        movePoint.parent = null;
    }

    public void PlayerWakeUp()
    {
        movement = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (movement == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        playerMoves();
                    }
                }

                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        playerMoves();
                    }
                }
            }
        }
    }

    void playerMoves()
    {
        myAnim.Play("NoHandWalkingZombie");
    }

    void playerIdles()
    {
        myAnim.Play("Zombie_Idle_No_Arm_animation");
    }
}
