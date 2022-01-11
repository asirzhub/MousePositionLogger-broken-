using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followMouse : MonoBehaviour
{
    Text g;
    private void Start()
    {
        g = this.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        g.text = Input.mousePosition.x.ToString() + ", " + Input.mousePosition.y.ToString();
    }
}
