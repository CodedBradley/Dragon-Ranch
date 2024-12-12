using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance {  get; set; }

    //----Health-----

    public float currentHealth;
    public float maxHealth;

    //---Hunger----

    public float currentHunger;
    public float maxHunger;
    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;
    //----Hydration----

    public float currentHydration;
    public float maxHydration;
    public bool isHydrationActive;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentHydration = maxHydration;

        StartCoroutine(decreaseHydration());
    }

    IEnumerator decreaseHydration()
    {
        while(true)
        { //change hydration depletion here --- might not even use this
            currentHydration -= 1;
            yield return new WaitForSeconds(600);
        }
    }

    void Update()
    {  //change distance depletion here --- might not even use this either but its nifty
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if(distanceTravelled >= 500)
        {
            distanceTravelled = 0;
            currentHunger -= 1;
        }
        
  
        //this is just to test if the damage works/health bar works -- will prob use this
        if(Input.GetKeyDown(KeyCode.N))
        {
            currentHealth -= 10;
            
            Debug.Log("Lemme bounce on it");
        }
    }


    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void setHunger(float newHunger)
    {
        currentHunger = newHunger;
    }

    public void setHydration(float newHydration)
    {
        currentHydration = newHydration;
    }
}
