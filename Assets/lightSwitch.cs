using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public Light directionalLight;
    bool fadeIn;

    [Header("Light Switch (Press to use)")]
    public bool flipSwitch = false;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(flipSwitch)
        {
            if(directionalLight.intensity < 0.1)
            {
                fadeIn = true;
            }
            else
            {
                fadeIn = false;
            }

            StartCoroutine(fadeInAndOut(directionalLight, fadeIn, 1f));
        }
    }

    IEnumerator fadeInAndOut(Light lightToFade, bool fadeIn, float duration)
    {
        flipSwitch = false;
        float minLuminosity = 0f; // min intensity
        float maxLuminosity = 4.8f; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);

            if (lightToFade.intensity == 4.8f) 
            {
                print("Light is ON");
            }
            else if (lightToFade.intensity == 0f)
            {
                print("Light is OFF");
            }

            yield return null;
        }
    }
}
