using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public int VelX;
    public int VelZ;
    public float MaxVel;

    GameObject WallX, WallZ;

    Transform Player;
    Transform ObjInteractive;
    
    Vector3 offset;
    


    float Fraction;
    float xMin;
    float zMin;
    float xMax;
    float zMax;

    private string ObjName;

    private float x;
    private float z;
    private float time;
    private float angle;

    private bool IsThrowed;


    // Start is called before the first frame update
    void Start()
    {
        WallX = GameObject.Find("WallX");
        WallZ = GameObject.Find("WallZ");

        //transform.position = new Vector3(-5, 0, -5);

        xMin = -Vector3.Distance(transform.position, WallX.transform.position) * 0.5f;
        zMin = -Vector3.Distance(transform.position, WallZ.transform.position) * 0.5f;

        x = Random.Range(-MaxVel, MaxVel);
        z = Random.Range(-MaxVel, MaxVel);
        angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Vector3 Offset = new Vector3(0, 1, 0);
        if (other.name == "Player")
            return;
        else
        {
            Vector3 dist = other.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, dist, Fraction * Time.deltaTime);
            ObjInteractive = other.transform;
            ObjName = other.name;
            ThrowObj();
        }

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        ThrowObj();
    }
    private void Movement()
    {
        xMax = Vector3.Distance(transform.position, WallX.transform.position + offset);
        zMax = Vector3.Distance(transform.position, WallZ.transform.position + offset);

        time += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-MaxVel, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        if (transform.localPosition.z > zMax)
        {
            z = Random.Range(-MaxVel, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        if (transform.localPosition.z < zMin)
        {
            z = Random.Range(0.0f, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        if (time > 1.0f)
        {
            x = Random.Range(-MaxVel, MaxVel);
            z = Random.Range(-MaxVel, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
    }
    private void ThrowObj()
    {
        Player = transform.Find("Player");
        //Vector3 distToPlayer = Player.position - transform.position;
 
        IsThrowed = true;
        //transform.position = Vector3.Lerp(transform.position, distToPlayer, Fraction * Time.deltaTime);

    }
}

