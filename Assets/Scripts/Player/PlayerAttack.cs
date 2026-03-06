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

    public float cooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > -0.1f)
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        
        if (Input.GetMouseButtonDown(0) == true)
        {

            cooldown = 2;

            GameObject objeto = Instantiate(ataque, this.gameObject.transform.position + new UnityEngine.Vector3(0,3,0), quaternion.identity);

            Debug.Log($"rotacion {this.gameObject.transform.localRotation.x}, {this.gameObject.transform.localRotation.y}");

            objeto.transform.Rotate(90, this.gameObject.transform.rotation.eulerAngles.y,0);

            MoverAtaque(objeto);

            animator.SetTrigger("BasicAttack");
        }

        yield return null;

    }

    public async Task<UniTask> MoverAtaque(GameObject objeto)
    {   
        while (true)
        {
            objeto.transform.position += objeto.transform.up * Time.deltaTime * 10f;
            
            await UniTask.Delay(1);
        }
        
    }

}
