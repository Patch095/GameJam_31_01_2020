using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOutOfPosition : MonoBehaviour
{
    public string ObjName;

    GameObject objToRepos;
    bool ObjOutPos = true;
    bool objIsTake;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        objToRepos = GameObject.Find(ObjName);
    }

    // Update is called once per frame
    void Update()
    {
        objIsTake = objToRepos.GetComponent<DropObject>().IsTake;

        if (ObjOutPos)
        {
            anim.SetBool("ObjOutPos", true);
        }
        else
        {
            anim.SetBool("ObjOutPos", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //objIsTake = other.gameObject.GetComponent<DropObject>().IsTake;

        if(other.name == ObjName && !objIsTake)
        {
            ObjOutPos = false;
        }
        else
        {
            ObjOutPos = true;
        }
    }
}
