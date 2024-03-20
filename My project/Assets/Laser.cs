using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int selfDelete;
    // Start is called before the first frame update
    void Start()
    {
        selfDelete = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, selfDelete);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
