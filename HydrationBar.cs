using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
public class HydrationBar : MonoBehaviour
{
    private Slider slider;
    public Text hungerCounter;
    public GameObject playerState;

    private float currentHydration, maxHydration;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        currentHydration = playerState.GetComponent<PlayerState>().currentHydration;
        maxHydration = playerState.GetComponent<PlayerState>().maxHydration;

        float fillValue = currentHydration / maxHydration;
        slider.value = fillValue;

        hungerCounter.text = currentHydration + "%";
    }
}
