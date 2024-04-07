using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
   // private Vector3 cameraOffsetVector;

    // Start is called before the first frame update
    void Start()
    {
        //cameraOffsetVector = Camera.main.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (target.transform.position + new Vector3(10, 6, 1));
        //Camera.main.transform.position = transform.position + cameraOffsetVector;
    }
}
