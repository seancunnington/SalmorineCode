namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LeftIndLights : MonoBehaviour
    {
        //reference to the ship's Left and Right buttonCount
        private GameObject shipHullRef;

        //float indicator of when this object will light up
        public float indicator;

        Material m_Material;
        Color darkGrey;

        // Use this for initialization
        void Start()
        {
            m_Material = GetComponent<Renderer>().material;
            shipHullRef = GameObject.Find("ShipHull");
            darkGrey = new Color(0.25f, 0.25f, 0.25f, 1f);
        }

        // Update is called once per frame
        void Update()
        {

            //if indicator == ship's buttonCount, then light up
            if (shipHullRef.GetComponent<MovePiece>().step_count_right < 0)
            {
                if (indicator >= shipHullRef.GetComponent<MovePiece>().step_count_right)
                {
                    m_Material.color = Color.yellow;
                }
            }
            if (indicator < shipHullRef.GetComponent<MovePiece>().step_count_right)
            {
                m_Material.color = darkGrey;
            }
        }
    }
}