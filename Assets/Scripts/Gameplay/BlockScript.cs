using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public float speed = 1f;
    public Rigidbody2D rb;
    public Vector2 up = new Vector2 (0, 100);
    public GameManager gameManager;

    SpriteRenderer rend;

    Sprite blockSprite;

    float duration = 0.5f;

    Color blockColor;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        //Setting the color properties for fading out
        blockColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.playing == false)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        if(gameManager.playing == true)
        {
            moveBlock(up);
        }
    }

    void moveBlock(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public IEnumerator fadeOut()
    {
        GameObject block = this.gameObject;
        for (float t = 0.01f; t < duration; t += Time.deltaTime)
        {
            blockColor = Color.Lerp(new Color(1, 1, 1), Color.clear, Mathf.Min(1, t / duration));
            yield return null;
        }
        yield return new WaitForSeconds(duration);
    }
}
