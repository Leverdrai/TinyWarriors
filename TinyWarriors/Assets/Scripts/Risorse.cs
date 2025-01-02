using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Risorse
{

    private int risorsa;
    private int maxHealth;

    public Risorse(int risorsa)
    {
        this.risorsa = risorsa;
        maxHealth = risorsa;
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    public int Risorsa
    {
        get
        {
            return risorsa;
        }

        set
        {
            if (value >= 0 && value <= maxHealth)
                risorsa = value;
            else if (value < 0)
                risorsa = 0;
            else
                risorsa = maxHealth;
        }
    }
}
