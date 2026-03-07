using System.Collections;
using System.Numerics;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject ataqueMetal;

    [SerializeField] private GameObject ataqueDodecafonia;

    [SerializeField] private GameObject ataqueLeitmotif;

    [Header ("No tocar")]
    [SerializeField] private float cooldownMetal;

    public float cooldownMetalAsignado;

    [Header ("No tocar")]
    [SerializeField] private float cooldownDodecafonia;

    public float cooldownDodecafoniaAsignado;

    [Header ("No tocar")]
    [SerializeField] private float cooldownLeitmotif;

    public float cooldownLeitmotifAsignado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Temporizadores();
    }

    public IEnumerator MainAttack()
    {
        
        if (Input.GetMouseButtonDown(0) == true)
        {

            cooldownMetal = cooldownMetalAsignado; //2

            GameObject objeto = Instantiate(ataqueMetal, this.gameObject.transform.position + new UnityEngine.Vector3(0,3,0), quaternion.identity);

            Debug.Log($"rotacion {this.gameObject.transform.localRotation.x}, {this.gameObject.transform.localRotation.y}");

            objeto.transform.Rotate(90, this.gameObject.transform.rotation.eulerAngles.y,0);

            MoverAtaqueMetal(objeto);

            animator.SetTrigger("BasicAttack");
        }

        yield return null;

    }

    public IEnumerator DodecafonicAttack()
    {
        if (Input.GetMouseButtonDown(1) == true)
        {
            cooldownDodecafonia = cooldownDodecafoniaAsignado; //10

            GameObject objeto = Instantiate(ataqueDodecafonia, this.gameObject.transform.position + new UnityEngine.Vector3(0,3,0), quaternion.identity);

            Debug.Log($"rotacion {this.gameObject.transform.localRotation.x}, {this.gameObject.transform.localRotation.y}");

            objeto.transform.Rotate(90, this.gameObject.transform.rotation.eulerAngles.y,0);

            MoverAtaqueDodecafonico(objeto);

            animator.SetTrigger("BasicAttack");
        }

        yield return null;
    }

    public IEnumerator LeitmotifAttack()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            cooldownLeitmotif = cooldownLeitmotifAsignado; //15

            GameObject objeto = Instantiate(ataqueLeitmotif, this.gameObject.transform.position + new UnityEngine.Vector3(0,3,0), quaternion.identity);

            Debug.Log($"rotacion {this.gameObject.transform.localRotation.x}, {this.gameObject.transform.localRotation.y}");

            objeto.transform.Rotate(90, this.gameObject.transform.rotation.eulerAngles.y,0);

            MoverAtaqueLeitMotif(objeto);

            animator.SetTrigger("BasicAttack");
        }

        yield return null;
    }

    public async Task<UniTask> MoverAtaqueMetal(GameObject objeto)
    {   
        while (true)
        {
            objeto.transform.position += objeto.transform.up * Time.deltaTime * 10f;
            
            await UniTask.Delay(1);
        }
        
    }

    public async Task<UniTask> MoverAtaqueDodecafonico(GameObject objeto)
    {   
        while (true)
        {
            objeto.transform.position += objeto.transform.up * Time.deltaTime * 50f;
            
            await UniTask.Delay(1);
        }
        
    }

    public async Task<UniTask> MoverAtaqueLeitMotif(GameObject objeto)
    {   
        while (true)
        {
            objeto.transform.position += objeto.transform.up * Time.deltaTime * 100f;
            
            await UniTask.Delay(1);
        }
        
    }

    private void Temporizadores()
    {

        //ataque metal

        if (cooldownMetal > -0.1f)
        {
            if (this.gameObject.GetComponent<PlayerStats>().potenciado)
            {
                cooldownMetal -= Time.deltaTime * 5;
            }
            else
            {
                cooldownMetal -= Time.deltaTime;
            }
        }
        

        if (cooldownMetal <= 0)
        StartCoroutine(MainAttack());

        if (cooldownLeitmotif > -0.1f)
        {
            if (this.gameObject.GetComponent<PlayerStats>().potenciado)
            {
                cooldownLeitmotif -= Time.deltaTime * 5;
            }
            else
            {
                cooldownLeitmotif -= Time.deltaTime;
            }
        }

        if (cooldownLeitmotif <= 0)
        StartCoroutine(LeitmotifAttack());

        if (cooldownDodecafonia > -0.1f)
        cooldownDodecafonia-= Time.deltaTime;

        if (cooldownDodecafonia <= 0)
        StartCoroutine(DodecafonicAttack());
    }

}
