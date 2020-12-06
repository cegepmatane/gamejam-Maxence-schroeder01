using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text MessageAfficher;

    public void SetMessage(string messsage)
    {
        MessageAfficher.text = messsage;
        StartCoroutine(TimeBeforeUnsetMessage());
    }

    private IEnumerator TimeBeforeUnsetMessage()
    {
        yield return new WaitForSeconds(5);
        UnSetMessage();
    }

    private void UnSetMessage()
    {
        MessageAfficher.text = "";
    }

}
