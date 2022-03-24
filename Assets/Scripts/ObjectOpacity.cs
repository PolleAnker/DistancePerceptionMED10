using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOpacity: MonoBehaviour
{
    public Renderer blinder;
    private Material blinderMat;
    private Color opaqueColour = new Color(0,0,0,1);
    private Color transparentColour = new Color(0,0,0,0);

    [Header("Press to go between tranparent and opaque")]
    public bool fade = false;    

    // Start is called before the first frame update
    void Awake()
    {
        blinderMat = blinder.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(fade)
        {
            if(blinderMat.color.a <= 0.1f)
            {
                StartCoroutine(FadeFromTo(transparentColour, opaqueColour, 1f));    // Fade from transparent to non-transparent
            }
            else if(blinderMat.color.a >= 0.9f)
            {
                StartCoroutine(FadeFromTo(opaqueColour, transparentColour, 1f));    // Fade from non-transparent to transparent
            }
        }
    }

    IEnumerator FadeFromTo(Color fromColour, Color toColour, float duration) {
        fade = false;   // Make sure the fade bool is set to false / reset when starting fade

        for (float t=0f;t<duration;t+=Time.deltaTime) 
        {
            float normalizedTime = t/duration;
            blinderMat.color = Color.Lerp(fromColour, toColour, normalizedTime);
            yield return null;
        }
        blinderMat.color = toColour;    // Make sure the colour is set to the exact value we want (otherwise it'll be 0.001 or smth off)
    }
}
