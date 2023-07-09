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
                start.SetActive(false);
                Debug.Log(current + " starts!");
                player.GetComponent<PlayerController2>().PlayerWakeUp();
            }

            else if (lose.activeSelf)
            {
                lose.SetActive(false);
                Debug.Log("Restarting " + current + "!");
                SceneManager.LoadScene(current.name);
            }

            else if (win.activeSelf)
            {
                win.SetActive(false);
                Debug.Log("Continuing to LV " + nextLv + "!");
                SceneManager.LoadScene(nextLv.name);
            }
        }
    }
}
