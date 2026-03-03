using System.Collections;
using UnityEngine;

public class ProyectileCleaning : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CleanProyectile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CleanProyectile()
    {
        yield return new WaitForSeconds(20f);

        if(this.gameObject != null)

        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(this.gameObject != null)
        {
            if (other.gameObject.CompareTag("Suelo"))
            {

            Destroy(this.gameObject);

            }
            
        }
    }
}
