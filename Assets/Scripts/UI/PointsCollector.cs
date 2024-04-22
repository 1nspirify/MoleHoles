using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PointsCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PointsCollectorText;

    public int Points = 0;
   
    public int Mole = 25;
    public int Bomb = 15;

    // Start is called before the first frame update
    void Update()
    {
        PointsCollectorText.text = "POINTS: " + Points.ToString();
    }

 
    public void PointsAdd()
    {
        Points += Mole;
        Debug.Log("Points added: " + Points);
    }

    public void PointsRemove()
    {
        Points -= Bomb;
    }
}
