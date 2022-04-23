using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PruebasEditor1
{
    // A Test behaves as an ordinary method
    // este es un método de pruebas
    // Adentro va a tener una serie de asserts 
    // assert - afirmación
    // tratar de hacer al menos un test por método 
    // tratar de hacer 1 script de pruebas por clase 
    [Test]
    public void Pruebita1()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(2, Probador.Suma(1, 1));
        Assert.AreEqual(0, Probador.Suma(0, 0));
        Assert.AreEqual(-1, Probador.Suma(1, -2));
        Assert.AreEqual(-1, Probador.Suma(-2, 1));
    }

    [Test]
    public void Pruebita2()
    {
        // Use the Assert class to test conditions
        Assert.IsFalse(Probador.EsCorrecto());
    }
}
