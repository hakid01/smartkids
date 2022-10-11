using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Captcha
{
    private static int n1 = 0;
    private static int n2 = 0;
    private static int solution = 0;

    private static bool operation = true; //  true = suma, false = resta

    private static string mathText = "";


    // Creamos aleatoriamente los valores de la operación matemática
    public static string CreateCaptcha()
    {
        if(Random.Range(0,100)%2 == 0)
        {
            operation = true;
        }
        else
        {
            operation = false;
        }

        // Valores dependiendo si es suma o resta
        if (operation)
        {
            // Captcha suma
            n1 = Random.Range(10, 100);
            n2 = Random.Range(10, 100);

            mathText = "" + n1 + " + " + n2 + " =";
            solution = n1 + n2;
        }
        else
        {
            // Captcha resta
            n1 = Random.Range(40, 100);
            n2 = Random.Range(10, n1);

            mathText = "" + n1 + " - " + n2 + " =";
            solution = n1 - n2;
        }

        return mathText;
    }
    public static int GetSolution()
    {
        return solution;
    }

    public static void SetDefaultSolution()
    {
        solution = 0;
    }

}
