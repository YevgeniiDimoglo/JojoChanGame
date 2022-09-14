using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private Vector3 dragOrigin;

    private void Update()
    {
        PanCamera();
    }


    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);

            mainCamera.transform.position += difference;
        }
    }
}
