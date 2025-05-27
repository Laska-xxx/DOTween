using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private int timer;
    [SerializeField] private Image timerImage;

    private void Start()
    {
        timerImage.DOFillAmount(0f, timer).SetEase(Ease.Linear);
    }

}
