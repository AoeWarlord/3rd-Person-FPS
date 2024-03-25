using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        //Get reference to wandering AI script
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null )
        {
            behavior.SetALive(false);
        }
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {

        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(0.1f);

        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
