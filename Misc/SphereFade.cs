namespace VRTK {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    /// <summary>
    /// FOR THIS ALL TO WORK
    ///   ---  ShipHull needs to be placed at: 
    ///         Transform --  x:4373.6    y:      z:-112.06
    ///         Rotation  --  x:0         y:      z:0
    /// </summary>


    public class SphereFade : MonoBehaviour {
        
        private GameObject shipHullRef;
        private Vector3 moveDirection;
        bool startFade;

        private float alphaLevel;
        private Color fadeColor;
        Material mat;

        // Use this for initialization
        void Start() {
            shipHullRef = GameObject.Find("ShipHull");
            moveDirection = new Vector3(0, 0, 0);
            startFade = false;

            alphaLevel = 1f;
            fadeColor = new Vector4(1f, 1f, 1f, alphaLevel);
            mat = GetComponent<Renderer>().material;

            Invoke("MoveShipDown", 5);
        }


        void MoveShipDown()
        {
            moveDirection = new Vector3(0, -0.09f, 0);

            
           // Invoke("StopShip", 18);
        }

        void StopShip()
        {
            moveDirection = new Vector3(0, 0, 0);
            Destroy(this);
        }

        // Update is called once per frame
        void Update() {

            //start fading sphere when fish reaches water surface
            if (shipHullRef.GetComponent<Transform>().position.y <= 599.5f)
                startFade = true;                

            if ( startFade == true && alphaLevel > 0) { 
                alphaLevel = alphaLevel - 0.04f;
            }

            //stop lowering the fish when reached view point
            if (shipHullRef.GetComponent<Transform>().position.y <= 581.5f)
                StopShip();

            fadeColor = new Vector4(1f, 1f, 1f, alphaLevel);
            mat.color = fadeColor;
            shipHullRef.GetComponent<CharacterController>().Move(moveDirection);

        }
        
    }
}