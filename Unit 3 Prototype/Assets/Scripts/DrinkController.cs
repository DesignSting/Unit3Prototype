using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkController : MonoBehaviour {

    private int drinkAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Runner")
        {
            int drinksHeld = other.GetComponentInParent<PlayerMovement>().ShowDrinks();

            if (drinksHeld <= 5)
            {
                other.GetComponentInParent<PlayerMovement>().AddDrink(drinkAmount);
                Destroy(gameObject);
            }

        }
    }
}
