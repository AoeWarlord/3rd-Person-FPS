using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    public bool notDead = true;
    public TMP_Text HP;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        if (notDead)
        {
            health -= damage;
        }
        Debug.Log($"Health: {health}");
        if (health > 0)
        {
            notDead = true;
        }
        else 
        { 
            notDead = false; 
        }
    }

    private void ShowHP()
    {
        HP.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ShowHP();
    }


}

