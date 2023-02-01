using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    [SerializeField]
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") // Tag: Player
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
