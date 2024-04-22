using System.Collections.Generic;
using UnityEngine;

public class TargetForHat : MonoBehaviour
{
    public List<GameObject> hats; // ������ �����
    public GameObject Target;
    private GameObject currentHat; // ������ �� ������� �����

    private void Start()
    {
        SetRandomHat();
    }

    private void SetRandomHat()
    {
        if (hats.Count > 0)
        {
            // �������� ��������� ����� �� ������
            GameObject randomHat = hats[Random.Range(0, hats.Count)];

            // ������� ��������� ��������� ����� � ��������� ������ �� ���
            currentHat = Instantiate(randomHat, Target.transform.position, Quaternion.identity);
           
        }
        else
        {
            Debug.LogWarning("No hats available for TargetForHat.");
        }
    }

    private void Update()
    {
        // ���������, ��� ����� ���������� � ������ �� �������� ���� Target
        if (currentHat && Target)
        {
            currentHat.transform.position = Target.transform.position;
            currentHat.transform.rotation = Target.transform.rotation;
            currentHat.transform.localScale = Target.transform.localScale;

           
        }
    }

    private void OnDestroy()
    {
        // ���������� ������� ����� ��� �������� ������������� �������
        Destroy(currentHat);
    }
}
