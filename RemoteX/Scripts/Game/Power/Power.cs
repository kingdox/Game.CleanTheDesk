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
    public GameObject powerFeedback;


    private void Awake()
    {
        powerBar = FindObjectOfType<PowerBar>();
        powerFeedback.SetActive(false);

    }

    public void WasPressed() => isPressed = true;

    public void SetAnimation(RuntimeAnimatorController ctrl)
    {
        power_anim.runtimeAnimatorController = ctrl;

        power_anim.gameObject.SetActive(false);

    }

    public void SetPowerBarLimit(int limit) => powerBar.limit = limit;

    public void UpdatePowerBarCount(int count) => powerBar.powerCount = count;


    public void OnOffPowerAnimation(bool condition) {

        power_anim.gameObject.SetActive(condition);
    }
    public void OnOffFeedbackAnimation(bool condition) {

        //powerFeedback.SetActive(condition);
        //Image powBG = power_anim.transform.parent.GetComponent<Image>();




    }

}







