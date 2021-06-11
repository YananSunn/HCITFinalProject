using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Text.RegularExpressions;

public class speechCommand : MonoBehaviour
{
    public string recognizedString;
    public AudioSource audio;
    public AudioClip[] clips;
    public AudioSource feedback;
    public AudioSource searchAudio;
    public AudioClip[] feedback_clips;
    private int index = 0;
    public List<int> favorites;
    public bool command = false;
    private bool inSearch = false;
    public string[] clipName;
    public GameObject searchResult;

    string patternPlay = @"play";
    string patternPause = @"pause";
    string patternNext = @"next";
    string patternLike = @"like";
    string patternTurnUp = @"turn up";
    string patternTurnDown = @"turn down";
    string patternChange = @"change to";
    string patternSearch = @"search";
    string patternExit = @"exit";

    // Start is called before the first frame update
    void Start()
    {
        audio.clip = clips[0];
    }

    // Update is called once per frame
    void Update()
    {
        //recognizedString = GetComponent<SpeechRecognition>().recognizedString;
        /*        string pattern = @"play";
                bool isMatch = Regex.IsMatch(recognizedString, pattern);*/
        if (command)
        {
            // search keywords
            if (inSearch)
            {
                // exit
                if (Regex.IsMatch(recognizedString, patternExit))
                {
                    searchAudio.Stop();
                    audio.Play();
                    searchResult.GetComponent<Text>().text = "";
                    inSearch = false;
                }
                else
                {
                    recognizedString = recognizedString.Replace(" ", "");
                    string patternKeyWords1 = "-" + recognizedString + "-";
                    string patternKeyWords2 = recognizedString + "-";
                    string patternKeyWords3 = "-" + recognizedString;
                    searchResult.GetComponent<Text>().text = patternKeyWords1 + "qaq1" + patternKeyWords2 + "qaq2" + patternKeyWords3 + "qaq3 /n";
                    for (int i = 0; i < clipName.Length; i++)
                    {
                        searchResult.GetComponent<Text>().text = searchResult.GetComponent<Text>().text + clipName[i] + " " +clipName[i].IndexOf(patternKeyWords1).ToString() + clipName[i].IndexOf(patternKeyWords2).ToString() + clipName[i].IndexOf(patternKeyWords3).ToString() + "qwq/n";
                        if (clipName[i].IndexOf(patternKeyWords1) >= 0 || clipName[i].IndexOf(patternKeyWords2) >= 0 || clipName[i].IndexOf(patternKeyWords3) >= 0)
                        {
                            searchAudio.clip = clips[i];
                            searchAudio.Play();
                            // searchResult.GetComponent<Text>().text = clipName[i];
                        }
                    }
                }
            }
            // play
            else if (Regex.IsMatch(recognizedString, patternPlay))
            {
                if (!audio.isPlaying)
                    audio.Play();
            }
            // pause
            else if (Regex.IsMatch(recognizedString, patternPause))
            {
                audio.Pause();
            }
            // next
            else if (Regex.IsMatch(recognizedString, patternNext))
            {
                audio.Stop();
                index += 1;
                if (index >= 9)
                    index = 0;
                audio.clip = clips[index];
                audio.Play();
            }
            // turn up
            else if (Regex.IsMatch(recognizedString, patternTurnUp))
            {
                audio.volume += 0.1f;
            }
            // turn down
            else if (Regex.IsMatch(recognizedString, patternTurnDown))
            {
                audio.volume -= 0.1f;
            }
            // like
            else if (Regex.IsMatch(recognizedString, patternLike))
            {
                favorites.Add(index);
                feedback.clip = feedback_clips[0];
                feedback.Play();
            }
            // change
            else if (Regex.IsMatch(recognizedString, patternChange))
            {
                // get the category
                recognizedString = recognizedString.Remove(0, recognizedString.IndexOf("change to")).Replace("change to", "").Replace(" ", "");
                if (recognizedString == "art")
                {
                    audio.Stop();
                    index = 0;
                    audio.clip = clips[index];
                    audio.Play();
                }
                else if (recognizedString == "health")
                {
                    audio.Stop();
                    index = 3;
                    audio.clip = clips[index];
                    audio.Play();
                }
                else if (recognizedString == "technology")
                {
                    audio.Stop();
                    index = 6;
                    audio.clip = clips[index];
                    audio.Play();
                }
                else if (recognizedString == "collection")
                {
                    audio.Stop();
                    index = favorites[0];
                    audio.clip = clips[index];
                    audio.Play();
                }
            }
            // search
            else if (Regex.IsMatch(recognizedString, patternSearch))
            {
                audio.Pause();
                feedback.clip = feedback_clips[1];
                feedback.Play();
                inSearch = true;
            }
            command = false;
        }
    }

    public void setString(string s)
    {
        recognizedString = s;
        command = true;
    }
}
