using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class next_news : MonoBehaviour
{
    public GameObject panel2;
    private bool panel2Open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyButtonEvent()
    {
        panel2Open = !panel2Open;
        panel2.SetActive(panel2Open);
    }
}
