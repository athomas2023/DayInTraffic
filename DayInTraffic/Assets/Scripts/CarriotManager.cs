using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarriotManager : MonoBehaviour
{
    public int carriotCount = 0;
    public int needAmount = 0;
    public GameObject phone;
    public TextMeshProUGUI carriotText;

    void Start()
    {
        carriotText.text = carriotCount.ToString();
    }

    void Update()
    {
        if (carriotCount >= needAmount)
        {
            phone.SetActive(true);
        }
    }

    public void UpdateCarriotCount()
    {
        carriotCount++;
        carriotText.text = carriotCount.ToString();
    }
}