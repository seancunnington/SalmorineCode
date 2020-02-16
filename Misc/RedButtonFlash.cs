namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RedButtonFlash : MonoBehaviour
    {

        Material mat;
        Renderer rend;
        float emission;
        Color baseColor;
        Color finalColor;
        Color resetColor;

        public GameObject audioMasterRef;
        public GameObject shipHullRef;

        private void Start()
        {
            audioMasterRef = GameObject.Find("VO_AudioMaster");
            shipHullRef = GameObject.Find("ShipHull");
            resetColor = new Vector4(0.3f, 0.183f, 0.183f, 1);
        }


        void OscillateEmission()
        {
            rend = GetComponent<Renderer>();
            mat = GetComponent<Renderer>().material;
            emission = Mathf.PingPong(Time.time, 1.0f);

            baseColor = new Vector4(1f, 0.5f, 0.5f, 1f);
            finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            mat.SetColor("_EmissionColor", finalColor);
        }

        // Update is called once per frame
        void Update()
        {
            if (shipHullRef.GetComponent<MovePiece>().bigRedButton == false)
            {
                if (audioMasterRef.GetComponent<AudioMaster>().canPlay5 == true)
                {
                    OscillateEmission();
                }
            } else
            {
                mat.SetColor("_EmissionColor", resetColor);
                mat.SetColor("_Color", Color.red);
            }

        }

    }
}
