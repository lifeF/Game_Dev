using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestCamaraMovement : MonoBehaviour  {
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator TestCamaraMovementWithEnumeratorPasses() {
        Setup();
        yield return new WaitForSeconds(5);   
    }

    void  Setup(){
        Instantiate(Resources.Load<GameObject>("Plane"));
        Instantiate(Resources.Load<GameObject>("Main Camera"));
        Instantiate(Resources.Load<GameObject>("Directional Light"));
    }
}
