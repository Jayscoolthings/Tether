using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseDetection : MonoBehaviour
{
    [SerializeField] GameObject gameManagerObject;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Block(Clone)")
        {
            gameManager.lose();
        }
    }
}
