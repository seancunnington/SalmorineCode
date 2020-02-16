using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoInput : MonoBehaviour {

    private GameObject go_check;
    private GameObject cassette0;
    private GameObject cassette1;
    private GameObject cassette2;
    private GameObject cassette3;
    private GameObject cassette4;

    public List<GameObject> Children;

    // Use this for initialization
    void Start () {
        print("VideoInput has started");
        cassette0 = GameObject.Find("VideoPlay0");
        cassette1 = GameObject.Find("VideoPlay1");
        cassette2 = GameObject.Find("VideoPlay2");
        cassette3 = GameObject.Find("VideoPlay3");
        cassette4 = GameObject.Find("VideoPlay4");
        cassette0.SetActive(false);
        cassette1.SetActive(false);
        cassette2.SetActive(false);
        cassette3.SetActive(false);
        cassette4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Transform child in transform)
        {
            if (child.tag == "Video0")
            {
                //print("found first video");
                cassette0.SetActive(true);
            }
            if (child.tag == "Video1")
            {
                //print("found second video");
                cassette1.SetActive(true);
            }
            if (child.tag == "Video2")
            {
                //print("found second video");
                cassette2.SetActive(true);
            }
            if (child.tag == "Video3")
            {
                //print("found third video");
                cassette3.SetActive(true);
            }
            if (child.tag == "Video4")
            {
                //print("found fourth video");
                cassette4.SetActive(true);
            }
        }

        if(transform.childCount == 1)
        {
            cassette0.SetActive(false);
            cassette1.SetActive(false);
            cassette2.SetActive(false);
            cassette3.SetActive(false);
            cassette4.SetActive(false);
        }
    }


}
