using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUse : MonoBehaviour
{
    GameObject JojoChan;
    GameObject JojoChanShadow;

    // Start is called before the first frame update
    void Start()
    {
        JojoChan = GameObject.Find("JoJoChan");
        JojoChanShadow = GameObject.Find("JoJoChanShadow");

        JojoChan.SetActive(true);
        JojoChanShadow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (JojoChan.activeSelf == true)
            {
                JojoChan.SetActive(false);
                JojoChanShadow.SetActive(true);
                JojoChanShadow.transform.position = JojoChan.transform.position;
            }
            else
            {
                JojoChan.SetActive(true);
                JojoChanShadow.SetActive(false);
                JojoChan.transform.position = JojoChanShadow.transform.position;
            }
        }
    }
}
