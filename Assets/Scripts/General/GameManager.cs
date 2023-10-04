using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool playing;
    public bool firstPlay;
    [SerializeField] GameObject tetherBall;
    ScoreManager scoreManagerScript;
    GameController gameController;
    GameObject blockStorage;
    BlockSpawner blockSpawner;
    UIManager uimanagerScript;
    PhysicsManager physicsManagerScript;

    [SerializeField] Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "test";
        firstPlay = true;
        playing = false;
        gameController = FindObjectOfType<GameController>();
        scoreManagerScript = FindObjectOfType<ScoreManager>();
        blockSpawner = FindObjectOfType<BlockSpawner>();
        uimanagerScript = FindObjectOfType<UIManager>();
        physicsManagerScript = FindObjectOfType<PhysicsManager>();
        blockStorage = GameObject.Find("Blocks");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playing == false)
            {
                if (firstPlay == true)
                {
                    uimanagerScript.FirstPlay();
                    NewGame();
                    firstPlay = false;
                    return;

                }
                if (firstPlay == false)
                {
                    uimanagerScript.NewGame();
                    NewGame();
                }
            }
            else
            {
                return;
            }
        }
    }

    public void lose()
    {
        if(playing == true)
        {
            playing = false;
            uimanagerScript.LoseGame();
            blockSpawner.StopAllCoroutines();
            //Time.timeScale = 0;                   This line was causing errors with text fade.
        }
    }

    void NewGame()
    {
        if(playing == false)
        {
            foreach (Transform block in blockStorage.transform)
            {
                StartCoroutine(block.GetComponent<BlockScript>().fadeOut());
                Destroy(block.gameObject);
            }
            playing = true;
            scoreManagerScript.score = 0;
            Time.timeScale = 1;
            gameController.rotationValue = -100;
            tetherBall.transform.rotation = (new Quaternion(0, 0, 0, 0));
            blockSpawner.StartCoroutine(blockSpawner.spawnRandomBlock());
            
        }
    }
    public void screenTapped()
    {
        debugText.text = "1";
        if (playing == false)
            {
                if (firstPlay == true)
                {
                    uimanagerScript.FirstPlay();
                    NewGame();
                    firstPlay = false;
                    return;
                }
                if (firstPlay == false)
                {
                    uimanagerScript.NewGame();
                    NewGame();
                }
                }
    }
}
