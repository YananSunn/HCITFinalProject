using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class next : MonoBehaviour
{
    private int index = 0;
    public GameObject play_pause;

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
        index += 1;
        if (index >= 9)
            index = 0;
        play_pause.GetComponent<play_pause>().next_news(index);
    }
}
