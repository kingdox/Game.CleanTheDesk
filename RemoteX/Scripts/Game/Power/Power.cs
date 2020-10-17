using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    private PowerBar powerBar;

    [Header("Power Info")]
    public bool isPressed = false;
    public Animator power_anim;

    private void Awake()
    {
        powerBar = FindObjectOfType<PowerBar>();

    }

    public void WasPressed() => isPressed = true;

    public void SetAnimation(RuntimeAnimatorController ctrl)
    {
        power_anim.runtimeAnimatorController = ctrl;
        //power_anim.Play("Stop");

    }

    public void SetPowerBarLimit(int limit) => powerBar.limit = limit;

    public void UpdatePowerBarCount(int count) => powerBar.powerCount = count;
}







