using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersUI : MonoBehaviour
{
    GameObject tWolf;
    GameObject tWolf_small;
    GameObject snakeP;
    GameObject snakeP_small;
    GameObject mouseH;
    GameObject mouseH_small;
    GameObject kittyQ;
    GameObject kittyQ_small;
    GameObject kCrow;
    GameObject kCrow_small;

    // Start is called before the first frame update
    void Start()
    {
        tWolf = GameObject.Find("TWolf_symbol");
        tWolf_small = GameObject.Find("TWolf_symbol_small");
        snakeP = GameObject.Find("SnakeP_symbol");
        snakeP_small = GameObject.Find("SnakeP_symbol_small");
        mouseH = GameObject.Find("MouseH_symbol");
        mouseH_small = GameObject.Find("MouseH_symbol_small");
        kittyQ = GameObject.Find("KittyQ_symbol");
        kittyQ_small = GameObject.Find("KittyQ_symbol_small");
        kCrow = GameObject.Find("KCrow_symbol");
        kCrow_small = GameObject.Find("KCrow_symbol_small");

        tWolf.SetActive(true);
        tWolf_small.SetActive(false);
        snakeP.SetActive(false);
        snakeP_small.SetActive(true);
        mouseH.SetActive(false);
        mouseH_small.SetActive(true);
        kittyQ.SetActive(false);
        kittyQ_small.SetActive(true);
        kCrow.SetActive(false);
        kCrow_small.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            tWolf.SetActive(true);
            tWolf_small.SetActive(false);
            snakeP.SetActive(false);
            snakeP_small.SetActive(true);
            mouseH.SetActive(false);
            mouseH_small.SetActive(true);
            kittyQ.SetActive(false);
            kittyQ_small.SetActive(true);
            kCrow.SetActive(false);
            kCrow_small.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tWolf.SetActive(false);
            tWolf_small.SetActive(true);
            snakeP.SetActive(true);
            snakeP_small.SetActive(false);
            mouseH.SetActive(false);
            mouseH_small.SetActive(true);
            kittyQ.SetActive(false);
            kittyQ_small.SetActive(true);
            kCrow.SetActive(false);
            kCrow_small.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tWolf.SetActive(false);
            tWolf_small.SetActive(true);
            snakeP.SetActive(false);
            snakeP_small.SetActive(true);
            mouseH.SetActive(true);
            mouseH_small.SetActive(false);
            kittyQ.SetActive(false);
            kittyQ_small.SetActive(true);
            kCrow.SetActive(false);
            kCrow_small.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            tWolf.SetActive(false);
            tWolf_small.SetActive(true);
            snakeP.SetActive(false);
            snakeP_small.SetActive(true);
            mouseH.SetActive(false);
            mouseH_small.SetActive(true);
            kittyQ.SetActive(true);
            kittyQ_small.SetActive(false);
            kCrow.SetActive(false);
            kCrow_small.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            tWolf.SetActive(false);
            tWolf_small.SetActive(true);
            snakeP.SetActive(false);
            snakeP_small.SetActive(true);
            mouseH.SetActive(false);
            mouseH_small.SetActive(true);
            kittyQ.SetActive(false);
            kittyQ_small.SetActive(true);
            kCrow.SetActive(true);
            kCrow_small.SetActive(false);
        }
    }
}
