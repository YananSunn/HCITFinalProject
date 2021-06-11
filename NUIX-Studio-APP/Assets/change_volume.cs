using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Microsoft.MixedReality.Toolkit.UI;

public class change_volume : MonoBehaviour
{
    public GameObject sliderObj;
    public Slider mySlider;
    public GameObject play_pause;
    private bool sliderAppear = false;
    public GameObject pinchSlider;

    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = 0.7f;
        sliderObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mySlider.value = pinchSlider.GetComponent<PinchSlider>().sliderValue;
        play_pause.GetComponent<play_pause>().change_volume(mySlider.value);
    }

    public void appear_slider()
    {
        sliderAppear = !sliderAppear;
        sliderObj.SetActive(sliderAppear);
    }

    //public void con_sound()
    //{
    //    play_pause.GetComponent<play_pause>().change_volume(mySlider.value);
    //}

    //public void con_sound(SliderEventData eventData)
    //{
    //    play_pause.GetComponent<play_pause>().change_volume(eventData.NewValue);
    //}
}
