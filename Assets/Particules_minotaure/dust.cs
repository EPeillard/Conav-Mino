using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dust : MonoBehaviour
{
    public GameObject poussiere;
    public GameObject[] murs;
    public Animator animator;

    private float timer = 0;
    private float lifetime = 0;
    private float timerDespawn = 0;
    private bool isSpawn;

    private int i = 0;

    private GameObject daddy;
    private GameObject clone;
    
    private void Start()
    {
        lifetime = poussiere.GetComponent<ParticleSystem>().main.duration + poussiere.GetComponent<ParticleSystem>().startLifetime;
        murs = GameObject.FindGameObjectsWithTag("wall");
        while (murs[i].name != "door")
        {
            i += 1;
            if (i == murs.Length)
            {
                Debug.LogError("ERREUR : Porte non détectée");
                break;
            }
        }
    }
    // Update is called once per frame

    private void Update()
    {

        timer += Time.deltaTime;
        
        if (timer > 10)
        {
            
            i = i % murs.Length;
            daddy = murs[i];
            clone = Instantiate(poussiere);
            clone.transform.parent = daddy.transform;

            //clone.transform.position += daddy.transform.position;

            clone.transform.localPosition = new Vector3(0, 0, 0.5f);
            clone.transform.position += new Vector3(0, daddy.GetComponent<Renderer>().bounds.size.y * 0.8f, 0);
            clone.transform.position += daddy.transform.position - clone.transform.position;
            clone.transform.eulerAngles = new Vector3(180, daddy.transform.eulerAngles.y, 90);

            //TESTS UNITAIRES MDR
            Debug.LogError(" différence entre la position voulue et la position de la poussière" + (daddy.transform.position - clone.transform.position));
            

            timer = 0;
            i++;
            isSpawn = true;
        }
        if (isSpawn && timer >lifetime)
        {
            Destroy(clone);
        }
    }
}
