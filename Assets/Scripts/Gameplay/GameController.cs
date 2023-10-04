using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{

    float speed = 1;
    public int rotationValue;
    GameManager gameManager;

    bool buttonTouched;

    void Start()
    {
        rotationValue = 100;
        gameManager = FindObjectOfType<GameManager>();
        buttonTouched = false;
    }


    void Update()
    {
        if(gameManager.playing == true)
        {
            transform.Rotate(new Vector3(0, 0, rotationValue) * speed * Time.deltaTime); // on z axis, -100 = cw. 100 = cc.
        }
    }

    void switchDirection()
    {
        if (rotationValue == -100)
        {
            rotationValue = 100;
            return;
        }

        if (rotationValue == 100)
        {
            rotationValue = -100; 
        }
    }

    public void ScreenPressed()
    {
        if(gameManager.playing == true)
        {
            switchDirection();
        }
    }
}
