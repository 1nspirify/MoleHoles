using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PointsCollector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PointsCollectorText;

    public int Points = 0;
    public int GreyMouse;
    public int BlackMouse = 15;
    public int WhiteMouse = 10;

    // Start is called before the first frame update
    void Update()
    {
        PointsCollectorText.text = "POINTS: " + Points.ToString();
    }

 
    public void PointsAdd()
    {
        Points += BlackMouse;
        Debug.Log("Points added: " + Points);
    }

    public void PointsRemove()
    {
        Points -= WhiteMouse;
    }
}
