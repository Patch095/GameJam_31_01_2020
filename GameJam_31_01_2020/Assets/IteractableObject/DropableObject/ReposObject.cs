using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposObject : MonoBehaviour
{
    public string NameObj;
    public float SpeedToRepos = 1;
    public Transform objToRepos;

    public bool objIsTake = false;

    bool objOnPos;
    bool isTriggeredFromGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        objToRepos = GameObject.Find(NameObj).transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distToObj = Vector3.Distance(transform.position, objToRepos.position);

        objIsTake = objToRepos.GetComponent<DropObject>().IsTake;

        if(distToObj <= 0.2f && !isTriggeredFromGhost && !objIsTake)
        {
            objToRepos.position = Vector3.Lerp(objToRepos.position, transform.position, SpeedToRepos * Time.deltaTime);
            objToRepos.rotation = Quaternion.Slerp(objToRepos.rotation, transform.rotation, SpeedToRepos * Time.deltaTime);
            objToRepos.GetComponent<DropObject>().isRepos = true;
        }
        else
        {
            objToRepos.GetComponent<DropObject>().isRepos = false;
        }
    }
}
