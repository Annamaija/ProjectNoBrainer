using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject start;
    public GameObject lose;
    public GameObject win;
    public GameObject player;

    public Object current;
    public Object nextLv;

    public AudioClip soundLV;
    public AudioClip soundWin;
    public AudioClip soundLose;

    public void Start()
    {
        start.SetActive(true);
    }
    public void Update()
    {

        if (Input.GetKey(KeyCode.Return))
        {
            if (start.activeSelf)
            {
                AudioSource.PlayClipAtPoint(soundLV, transform.position);
                start.SetActive(false);
                Debug.Log(current + " starts!");
                player.GetComponent<PlayerController2>().PlayerWakeUp();
            }

            else if (lose.activeSelf)
            {
                AudioSource.PlayClipAtPoint(soundLose, transform.position);
                lose.SetActive(false);
                Debug.Log("Restarting " + current + "!");
                SceneManager.LoadScene(current.name);
            }

            else if (win.activeSelf)
            {
                AudioSource.PlayClipAtPoint(soundWin, transform.position);
                win.SetActive(false);
                Debug.Log("Continuing to LV " + nextLv + "!");
                SceneManager.LoadScene(nextLv.name);
            }
        }
    }
}
