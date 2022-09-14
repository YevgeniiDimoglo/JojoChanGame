using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUse : MonoBehaviour
{
    public Character2DConrtoller JojoChan;
    public Character2DConrtoller JojoChanShadow;

    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        JojoChan.gameObject.SetActive(true);
        JojoChanShadow.gameObject.SetActive(false);
        currentTime = .0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (JojoChan.CharacterState != 2)
            {
                JojoChan.CharacterState = 2;
                JojoChanShadow.gameObject.SetActive(true);
                JojoChanShadow.transform.position = JojoChan.transform.position;
            }
            else
            {
                JojoChan.gameObject.SetActive(true);
                JojoChan.CharacterState = 1;
                JojoChanShadow.gameObject.SetActive(false);
                JojoChan.transform.position = JojoChanShadow.transform.position;
            }
        }

        if (JojoChan.CharacterState == 2)
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime < 0)
        {
            JojoChan.gameObject.SetActive(true);
            JojoChan.CharacterState = 1;
            JojoChanShadow.gameObject.SetActive(false);
            JojoChan.transform.position = JojoChanShadow.transform.position;
            currentTime = 0.0f;
        }
    }
}
