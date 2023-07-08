using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject dSwitch;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        door.SetActive(true);
        Debug.Log("Open sesamee");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
         Debug.Log("Door switch was hit");
         sprite.color = new Color(1, 0, 0, 1);
         door.SetActive(false);
    }
}