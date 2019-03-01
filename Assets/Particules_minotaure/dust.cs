using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour
{
    public GameObject poussière;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        
        

        if (timer > 10)
        {
            Instantiate(poussière);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        Debug.Log(timer);
    }
}
