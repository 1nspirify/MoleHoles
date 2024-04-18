using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventScript : MonoBehaviour
{
    public GameObject Effect;

   

    private void Start()
    {
       
       
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    public void HandleObjectTapped()
    {

 
        Instantiate(Effect, transform.position, Quaternion.identity);
       

    }
}