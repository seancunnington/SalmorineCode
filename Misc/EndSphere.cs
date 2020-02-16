namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class EndSphere : MonoBehaviour
    {

        private GameObject shipHullRef;
        private Vector3 moveDirection;
        private GameObject riverRef;
        Collider riverCol;

        private float alphaLevel;
        private Color fadeColor;
        Material mat;

        bool startFade;

        // Use this for initialization
        void Start()
        {
            shipHullRef = GameObject.Find("ShipHull");
            riverRef = GameObject.Find("River_Middle");
            moveDirection = new Vector3(0, 0, 0);

            alphaLevel = 0f;
            fadeColor = new Vector4(0, 0, 0, alphaLevel);
            mat = GetComponent<Renderer>().material;

            startFade = false;
            //startCreditsFade = false;
        }


        void MoveShipUp()
        {
            moveDirection = new Vector3(0, 0.09f, 0);
            Destroy(riverRef.GetComponent<MeshCollider>());
            Invoke("StopShip", 14);
            Invoke("BeginTheFade", 5);
            Invoke("restartLevel", 25);
        }

        void StopShip()
        {
            moveDirection = new Vector3(0, 0, 0);
        }

        void BeginTheFade()
        {
            startFade = true;
        }

        void restartLevel()
        {
            SceneManager.LoadScene("TestScene");
        }

        // Update is called once per frame
        void Update()
        {
            if (shipHullRef.GetComponent<MovePiece>().endStart == true)
            {
                MoveShipUp();
                shipHullRef.GetComponent<MovePiece>().endStart = false;
            }

            if (startFade == true)
            {
                if (alphaLevel < 1)
                    alphaLevel = alphaLevel + 0.015f;
            }

            fadeColor = new Vector4(0, 0, 0, alphaLevel);
            mat.color = fadeColor;
            shipHullRef.GetComponent<CharacterController>().Move(moveDirection);

        }
    }
}