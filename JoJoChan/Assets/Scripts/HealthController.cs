using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    public TMP_Text healthCounter;

    public Character2DConrtoller characterController;

    // Start is called before the first frame update
    void Start()
    {
        healthCounter.text = "Health: 100";
    }

    // Update is called once per frame
    void Update()
    {
        healthCounter.text = "Health: " + characterController.Health.ToString();
    }
}
