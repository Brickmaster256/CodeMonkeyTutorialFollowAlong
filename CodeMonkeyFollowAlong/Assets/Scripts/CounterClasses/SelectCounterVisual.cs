using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        PlayerController.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerController.OnSelectedCounterChangedEventArgs e)
    {
       if(e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            HIde();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void HIde()
    {
        visualGameObject.SetActive(false);
    }
}
