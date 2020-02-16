using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour {

    private float alphaLevel;
    private Color fadeColor;
    Material mat;

    bool start;

	// Use this for initialization
	void Start () {
        alphaLevel = 1f;
        fadeColor = new Vector4(0, 0, 0, alphaLevel);
        mat = GetComponent<Renderer>().material;
        start = false;

        Invoke("StartFade", 3);
	}
	
    void StartFade()
    {
        start = true;
    }

	// Update is called once per frame
	void Update () {
        if( start == true && alphaLevel > 0)
            alphaLevel = alphaLevel - 0.005f;

        if (alphaLevel <= 0.005f)
            Destroy(this);

        fadeColor = new Vector4(0, 0, 0, alphaLevel);
        mat.color = fadeColor;
    }
}
