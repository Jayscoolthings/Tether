using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{

    [SerializeField] private GameObject blockList;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public IEnumerator Gravity()// No time for the gravity to take place.
    {
        foreach(Transform block in blockList.transform)
        {
            Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        yield return new WaitForSeconds(3);
    }
}
