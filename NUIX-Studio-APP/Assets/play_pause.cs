using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class play_pause : MonoBehaviour
{
    private bool ifPlay = false;
    private int index = 0;
    public AudioSource[] music;
    public Sprite play;
    public Sprite pause;

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
        ifPlay = !ifPlay;
        if (ifPlay)
        {
            music[index].Play();
            GetComponent<Image>().sprite = pause;
        }
        else
        {
            music[index].Pause();
            GetComponent<Image>().sprite = play;
        }    
    }

    public void change_volume(float f)
    {
        music[index].volume = f;
    }

    public void stop()
    {
        music[index].Stop();
    }

    public void next_news(int i)
    {
        music[index].Stop();
        index = i;
        music[index].Play();
    }

    public void cate_art()
    {
        music[index].Stop();
        index = 0;
        music[index].Play();
    }

    public void cate_health()
    {
        music[index].Stop();
        index = 3;
        music[index].Play();
    }

    public void cate_tech()
    {
        music[index].Stop();
        index = 6;
        music[index].Play();
    }
}
