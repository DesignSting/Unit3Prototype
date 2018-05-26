using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour {

    public int tipAmount;

    public GameObject playerRunner;

    public void Start()
    {
        tipAmount = Random.Range(1, 6);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            int drinksHeld = other.GetComponentInParent<PlayerMovement>().ShowDrinks();

            if(drinksHeld >0)
            {
                other.GetComponentInParent<PlayerMovement>().AddTips(tipAmount);
                other.GetComponentInParent<PlayerMovement>().SubDrinks();
            }
            else if(drinksHeld <= 0)
            {
                other.GetComponentInParent<PlayerMovement>().AddTips(-tipAmount);
            }

        }
    }
}
