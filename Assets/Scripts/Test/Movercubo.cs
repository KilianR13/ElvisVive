using System.Collections;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
public class Movercubo : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float timeIn1;

    float timeOut1;

    float timeIn2;

    float timeOut2;

    Vector3 posicionFinal1;

    Vector3 posicionFinal2;

    [SerializeField] TextMeshProUGUI texto;
    
    
    void Start()
    {
        //StartCoroutine(Mover());

        Esperar();

               // posicionFinal1 = this.gameObject.transform.position + new Vector3(10, 0, 10);
    }

    void Update()
    {
        /*VicGenLib.Calc.Movement.SimplerLerp(this.gameObject, this.gameObject.transform.position, posicionFinal1, 2, timeIn1, out timeOut1);

        timeIn1 = timeOut1;

        if (gameObject.transform.position.z < 2362.56)

        texto.text = timeIn1.ToString();*/


    }

    /*IEnumerator Mover()
    {

        for (int i = 0; i < 66; i++)
        {
            this.gameObject.transform.position += new Vector3 (0,0, 0.25f);

            yield return new WaitForSeconds (0.033f);
        }
    }*/

    private async UniTask MiFuncion()
    {
        await Esperar();
    }

    public async UniTask Esperar()
    {
        for (int i = 0; i < 200; i++)
        {
            this.gameObject.transform.position += new Vector3 (0,0, 0.05f);

            await UniTask.WaitForSeconds(0.005f);
        }
    }
}

