using System.Collections;
using System.Numerics;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private GameObject ataque;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        
        if (Input.GetMouseButtonDown(0) == true)
        {
            GameObject objeto = Instantiate(ataque, this.gameObject.transform.position + new UnityEngine.Vector3(0,5,0), this.gameObject.transform.rotation);

            objeto.transform.localRotation = quaternion.Euler(objeto.transform.localRotation.x, objeto.transform.localRotation.y, objeto.transform.localRotation.z);

            MoverAtaque(objeto);

            animator.SetTrigger("BasicAttack");
        }

        yield return null;

    }

    public async Task<UniTask> MoverAtaque(GameObject objeto)
    {   
        while (true)
        {
            objeto.transform.localPosition += new UnityEngine.Vector3(0.1f,0,0);
            
            await UniTask.Delay(1);
        }
        
    }

}
