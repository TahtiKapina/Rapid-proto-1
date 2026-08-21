using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public void TestPass()
    {
        Pass();
    }
    public void TestReject()
    {
        Reject();
    }

    public void Pass()
    {
        Debug.Log("Passed");
    }

    public void Reject()
    {
        Debug.Log("Rejected");
    }
}
