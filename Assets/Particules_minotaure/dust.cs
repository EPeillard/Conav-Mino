using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dust : MonoBehaviour
{
    public GameObject dust_effect;
    public GameObject[] walls;
    public GameObject minotaurNoise;

    private float timer = 0;
    private bool isSpawn;
    private int i = 0;

    private GameObject parent;
    private GameObject clone;
    private GameObject noise;
    
    private void Start()
    {
        //on remplit le tableau avec les objets taggué Wall qui sont les GameObjects où l'on souhaite faire spawn
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    private void Update()
    {

        timer += Time.deltaTime;
        //Toutes les 30 secondes on fait spawn la poussiere
        if (timer >30 && !isSpawn)
        {
            
            i = i % walls.Length;
            parent = walls[i];
            clone = Instantiate(dust_effect);
            noise = Instantiate(minotaurNoise);
            clone.transform.parent = parent.transform;
            noise.transform.parent = parent.transform;
            //selon le mur on fait spawn la poussiere à un endroit précis car la transform du mur et son mesh ne coincident pas 
            switch (parent.name)
            {
                case "entranceDoor":
                    clone.transform.localPosition = new Vector3(0.0f, 2.2f, -0.25f);
                    noise.transform.localPosition = new Vector3(0.0f, 2.2f, -0.25f);

                    break;
                case "exitDoor":
                    clone.transform.localPosition = new Vector3(0.0f, 2.2f, 0.30f);
                    noise.transform.localPosition = new Vector3(0.0f, 2.2f, 0.30f);
                    clone.transform.localEulerAngles = new Vector3(180.0f, -180.0f, 90.0f);
                    break;
                case "Wall 1":
                    clone.transform.localPosition = new Vector3(0.35f, 2.4f, -0.83f);
                    noise.transform.localPosition = new Vector3(0.35f, 2.4f, -0.83f);
                    clone.transform.localEulerAngles = new Vector3(180.0f, 180.0f, 90.0f);
                    break;
                case "Wall 2":
                    clone.transform.localPosition = new Vector3(0.14f, 2.4f, -0.84f);
                    noise.transform.localPosition = new Vector3(0.14f, 2.4f, -0.84f);
                    clone.transform.localEulerAngles = new Vector3(180.0f, 0.0f, 90.0f);
                    break;
                case "Wall 3":
                    clone.transform.localPosition = new Vector3(-4.9f, 2.8f, -0.87f);
                    noise.transform.localPosition = new Vector3(-4.9f, 2.8f, -0.87f);
                    clone.transform.localEulerAngles = new Vector3(180.0f, 180.0f, 90.0f);
                    break;
                case "Broken Wall 1":
                    clone.transform.localPosition = new Vector3(-4.16f, 2.8f, -0.84f);
                    noise.transform.localPosition = new Vector3(-4.16f, 2.8f, -0.84f);
                    clone.transform.localEulerAngles = new Vector3(180.0f, 0.0f, 90.0f);
                    break;
            }

            timer = 0;
            i++;
            isSpawn = true;
        }
        // si une poussierer est spawn on attend 11 secondes et on la détruit
        if (isSpawn && timer >11)
        {
            Destroy(clone);
            Destroy(noise);
            isSpawn = false;
            timer = 0;

        }
    }
}
