using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public List<GameObject> hats; // ������ �����
    private Dictionary<Transform, GameObject> hatDictionary = new Dictionary<Transform, GameObject>();

    private void Update()
    {
        // ��������� ����� ������ ��� �������� �������� � ����������� TargetForHat
        foreach (KeyValuePair<Transform, GameObject> kvp in hatDictionary)
        {
            if (kvp.Key.gameObject.activeInHierarchy)
            {
                kvp.Value.SetActive(true);
                kvp.Value.transform.position = kvp.Key.position; // �������� ����� �� ����� ������� TargetForHat
            }
            else
            {
                kvp.Value.SetActive(false);
            }
        }
    }

    private void Start()
    {
        // ������� �������, ��� ���� - Transform ������� � �������� TargetForHat, � �������� - �����
        foreach (Transform child in transform)
        {
            TargetForHat targetForHat = child.GetComponent<TargetForHat>();
            if (targetForHat != null)
            {
                GameObject randomHat = GetRandomHat();
                hatDictionary[child] = randomHat;
                randomHat.SetActive(false); // �������� ��������� ��� �����
            }
        }
    }

    private GameObject GetRandomHat()
    {
        // ���������� ��������� ����� �� ������
        int randomIndex = Random.Range(0, hats.Count);
        return hats[randomIndex];
    }
}