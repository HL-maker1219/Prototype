using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDetection : MonoBehaviour
{
    public Transform playerSpot;
    private int playerLayermask = 1 << 10;
    public bool Col = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Col = Physics2D.Linecast(this.transform.position, playerSpot.position, playerLayermask);
        Debug.DrawLine(this.transform.position, playerSpot.position, Color.red);

        

        if (Col)
        {
            flip();
        }

    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
