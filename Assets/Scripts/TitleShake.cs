using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShake : MonoBehaviour
{
    float speed = 0.5f; //how fast it shakes
    float amount = 0.5f; //how much it shakes
    Vector3 startingPos;
    float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        startingPos.z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        x = startingPos.x;// + Mathf.Sin(Time.time * speed) * amount;
        y = startingPos.y; // + Mathf.Sin(Time.time * speed) * amount;
        z = startingPos.z + Mathf.Sin(Time.time * speed) * amount;
        transform.position = new Vector3(x,y,z);
    }
}
