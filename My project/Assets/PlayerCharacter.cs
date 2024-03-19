using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    public bool notDead = true;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        health -= damage;
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

    // Update is called once per frame
    void Update()
    {
        
    }


}

