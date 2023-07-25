using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform itemHolder;
    public float rayDist;
    private bool toggleHolding;


    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        toggleHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            switchToggle();
        }
        
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, new Vector2(x,y), rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Interactable")
        {
            if (toggleHolding)
            {
                grabCheck.collider.gameObject.transform.parent = itemHolder;
                grabCheck.collider.gameObject.transform.position = itemHolder.position;
                //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
            }
        }
        
    }

    void switchToggle()
    {
        if (toggleHolding)
        {
            toggleHolding = false;
        }
        else
        {
            toggleHolding = true;
        }
    }
}
