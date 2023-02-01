using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;
    private bool finishedLevel = false;

    private GameObject clearSign;

    private void Start()
    {
        clearSign = this.gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (finishedLevel)
        {
            timeElapsed += Time.deltaTime;
        }
        
        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(0);
            clearSign.SetActive(false);
            Cursor.visible = true;
        }

        if (timeElapsed > delayBeforeLoading * 0.5f)
        {
            clearSign.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null && player.state.Equals(0))
        {
            finishedLevel = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && player.state.Equals(0))
        {
            finishedLevel = true;
        }
    }
}
