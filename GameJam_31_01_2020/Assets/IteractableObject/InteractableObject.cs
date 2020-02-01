using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    Animator anim;
    
    public float i;

    public float accumolator;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        i = 1;
        accumolator = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        i += accumolator;
        i = Mathf.Clamp01(i);
        anim.SetFloat("status", i);
    }


    public void Trigger_anim(int value)
    {
        accumolator = value;
    }
}
