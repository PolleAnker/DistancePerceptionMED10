using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentResizer : MonoBehaviour
{
    public GameObject environment;
    public bool scaleInaccurately = false;
    public bool resetScale = false;
    
    void Update()
    {
        if(scaleInaccurately){
            scaleInaccurately = false;
            environment.transform.localScale = Vector3.one;
            float randomMultiplier = Random.Range(0.8f, 2.1f);
            environment.transform.localScale *= randomMultiplier;
            print("Environment scaled by factor " + randomMultiplier);
        }
        if(resetScale){
            resetScale = false;
            environment.transform.localScale = Vector3.one;
            print("Environment scale was reset");
        }
    }
}
