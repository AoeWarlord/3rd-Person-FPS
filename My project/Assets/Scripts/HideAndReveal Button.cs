using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HideandReveal_Button : MonoBehaviour
{
    PlayerCharacter alive;
    public Button button;
    private bool functional = true;
    // Start is called before the first frame update
    void Start()
    {
        alive = GetComponentInParent<PlayerCharacter>();
        button = GetComponent<Button>();
        button.gameObject.SetActive(true); // Button should be inactive at the start
    }

    // Update is called once per frame
    void Update()
    {
        functional = alive.notDead;
        if (functional == true)
        {
            button.gameObject.SetActive(false); // If player is alive, button is inactive
            Debug.Log("Player is alive");
        }
        if (functional == false)
        {
            button.gameObject.SetActive(true); // If player is not alive, button is active
            Debug.Log("Player is not alive");
        }
    }

}
