using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PruebasPlayMode
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PruebasPlayMode1()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(2);

        Assert.AreEqual(2, Probador.Suma(1, 1));
        Assert.AreEqual(0, Probador.Suma(0, 0));
        Assert.AreEqual(-1, Probador.Suma(1, -2));
        Assert.AreEqual(-1, Probador.Suma(-2, 1));
        //Assert.AreEqual(PoolManager.Instance.MaximoDeBalitas, 20);
    }

    [UnityTest]
    public IEnumerator PruebasPlayMode2()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(4);
        Assert.IsFalse(Probador.EsCorrecto()); 
    }
}
