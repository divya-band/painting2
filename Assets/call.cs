using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class call : MonoBehaviour
{
    private List<GameObject> colors = new List<GameObject>();
    public static Color color;
    public static bool isLine = true;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && colors.Count>0)
        {
            color = colors[0].GetComponent<Renderer>().material.color;
            print("hi");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        print("REE");
        if (collision.gameObject.tag == "color")
        {
            colors.Add(collision.gameObject);
            print("plz work");
        }

        if (collision.gameObject.tag == "brush")
        {
            if (cube == collision.gameObject)
            {
                isLine = false;
            }

            else
            {
                isLine = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "color")
        {
            colors.Remove(collision.gameObject);
        }
    }
}
