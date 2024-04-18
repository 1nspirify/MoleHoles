using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointsEffect : MonoBehaviour
{
    [SerializeField] private GameObject _pointsAddition;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    public void HandleObjectTapped()
    {
        
        Instantiate(_pointsAddition, transform.position, Quaternion.identity);
    }
}