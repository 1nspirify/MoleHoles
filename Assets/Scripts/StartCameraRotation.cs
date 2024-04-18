using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraRotation : MonoBehaviour
{
    public float SpeedRotation = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, SpeedRotation * Time.deltaTime, 0), Space.World);
    }
}
    