using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    public Animator Endanim;

    public void LaunchEnd()
    {
        StartCoroutine("EndAnim");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(5f);
        Endanim.Play("TheEnd");
    }
}
