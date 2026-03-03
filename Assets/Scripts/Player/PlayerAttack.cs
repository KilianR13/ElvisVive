using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;

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
            animator.SetTrigger("BasicAttack");
        }

        yield return null;

    }
}
