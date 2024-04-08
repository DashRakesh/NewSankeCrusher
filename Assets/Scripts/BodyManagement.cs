using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManagement : MonoBehaviour
{
    private int myOrder;
    private Transform head;
    public bool coirMaking = false;
    public ParticleSystem crushEffect;

    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        for(int i=0; i < head.GetComponent<CameraFollow>().bodyparts.Count; i++)
        {
            if(gameObject == head.GetComponent<CameraFollow>().bodyparts[i].gameObject)
            {
                myOrder = i;
            }
        }
    }
    private Vector3 movementVelocity;
  [Range(0.0f, 50.0f)] public float overTime = 0.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myOrder == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);
            
            transform.LookAt(head.transform.position);
        }
        else
        {
            transform.position =  Vector3.SmoothDamp(transform.position, head.GetComponent<CameraFollow>().bodyparts[myOrder-1].position, ref movementVelocity, overTime);
            transform.LookAt(head.transform.position);
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            coirMaking = true;
            Debug.Log(coirMaking);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (coirMaking== true) {

            if (other.tag == "Orb")
            {
                Debug.Log("HIt");
                Destroy(other.gameObject);
                coirMaking = false;
                crushEffect.Play();
            }

        }
       
    }
}
