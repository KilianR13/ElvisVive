using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class LanzarProyectil : MonoBehaviour
{

    public GameObject player;

    public List<GameObject> proyectiles;

    public bool playerInRange;

    public int randomInt;

    public float tiempoSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(SpawnProyectil());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    IEnumerator SpawnProyectil()
    {
            while (true)
            {
                yield return new WaitForSeconds(tiempoSpawn);

                if (playerInRange)
                {
                    randomInt = UnityEngine.Random.Range(0,5);

                    GameObject proyectil = Instantiate(proyectiles[randomInt]);

                    proyectil.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1,  this.gameObject.transform.position.z);

                    if (this.gameObject.GetComponent<BossesStats>().confuso)
                    {
                        float x = UnityEngine.Random.Range(0,360);
                        float y = UnityEngine.Random.Range(0,360);
                        float z = UnityEngine.Random.Range(0,360);

                        proyectil.transform.rotation = quaternion.Euler(x,y,z); 
                    }

                    else
                    {
                        proyectil.transform.LookAt(player.transform.GetChild(1).gameObject.transform);
                    }

                    MoverProyectil(proyectil);

                }
                
            }
    }

    async UniTask MoverProyectil(GameObject proyectil)
    {
        while (true)
        {
            
            proyectil.transform.Translate(60 * Time.deltaTime * Vector3.forward);

            await UniTask.Delay(2);

        }
        
    }
}
