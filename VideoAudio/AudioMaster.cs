namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AudioMaster : MonoBehaviour {

        private GameObject shipHullRef;

        private GameObject vo_Intro;
        private GameObject vo_Tutorial;
        private GameObject vo_TotalBug_1;
        private GameObject vo_TotalBug_2;
        private GameObject vo_TotalBug_3;
        private GameObject vo_TotalBug_4;

        private bool played1;
        private bool played2;
        private bool played3;
        private bool played4;
        private bool played5;
        public bool canPlay5;

        // Use this for initialization
        void Start() {
            Debug.Log("started AudioMaster");

            shipHullRef = GameObject.Find("ShipHull");

            vo_Intro = GameObject.Find("VO_Intro");
            vo_Tutorial = GameObject.Find("VO_Tutorial");
            vo_TotalBug_1 = GameObject.Find("VO_TotalBug_1");
            vo_TotalBug_2 = GameObject.Find("VO_TotalBug_2");
            vo_TotalBug_3 = GameObject.Find("VO_TotalBug_3");
            vo_TotalBug_4 = GameObject.Find("VO_TotalBug_4");

            vo_Intro.SetActive(false);
            vo_Tutorial.SetActive(false);
            vo_TotalBug_1.SetActive(false);
            vo_TotalBug_2.SetActive(false);
            vo_TotalBug_3.SetActive(false);
            vo_TotalBug_4.SetActive(false);

            played1 = false;
            played2 = false;
            played3 = false;
            played4 = false;
            played5 = false;
            canPlay5 = false;

            Debug.Log("before invoke function");
            Invoke("PlayIntroAudio", 15);
            Debug.Log("after Invoke function");
        }

        void PlayIntroAudio()
        {
            Debug.Log("started intro");
            vo_Intro.SetActive(true);
            Invoke("StopIntroAudio", 75);
        }

        void StopIntroAudio()
        {
            canPlay5 = true;
            Debug.Log("ended intro");
            vo_Intro.SetActive(false);
        }

        /////////////////////////
        void PlayBug1()
        {
            vo_TotalBug_1.SetActive(true);
            played1 = true;
            Invoke("StopBug1", 30);
        }

        void StopBug1()
        {
            vo_TotalBug_1.SetActive(false);
        }


        /////////////////////////
        void PlayBug2()
        {
            vo_TotalBug_2.SetActive(true);
            played2 = true;
            Invoke("StopBug2", 35);
        }

        void StopBug2()
        {
            vo_TotalBug_2.SetActive(false);
        }


        /////////////////////////
        void PlayBug3()
        {
            vo_TotalBug_3.SetActive(true);
            played3 = true;
            Invoke("StopBug3", 50);
        }

        void StopBug3()
        {
            vo_TotalBug_3.SetActive(false);
        }


        /////////////////////////
        void PlayBug4()
        {
            vo_TotalBug_4.SetActive(true);
            played4 = true;
            Invoke("StopBug4", 40);
        }

        void StopBug4()
        {
            vo_TotalBug_4.SetActive(false);
        }


        /////////////////////////
        //same implemenation for shipHullRef.GetComponent<MovePiece>().bigRedButton == true;
        void PlayTut()
        {
            vo_Tutorial.SetActive(true);
            played5 = true;
            Invoke("StopTut", 60);
        }

        void StopTut()
        {
            vo_Tutorial.SetActive(false);
        }

        
        /////////////////////////


        // Update is called once per frame
        void Update() {
            if (shipHullRef.GetComponent<MovePiece>().totalBugCount == 1 && played1 == false)
                PlayBug1();

            if (shipHullRef.GetComponent<MovePiece>().totalBugCount == 2 && played2 == false)
                PlayBug2();

            if (shipHullRef.GetComponent<MovePiece>().totalBugCount == 3 && played3 == false)
                PlayBug3();

            if (shipHullRef.GetComponent<MovePiece>().totalBugCount == 4 && played4 == false)
                PlayBug4();

            if (shipHullRef.GetComponent<MovePiece>().bigRedButton == true && played5 == false)
                PlayTut();
        }
    }
}
