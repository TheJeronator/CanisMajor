using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialHandler : MonoBehaviour
{
    public Image tutorialScreen;
    public Sprite[] TutorialSprites;
    public GameObject gun = null;
    public GameObject beam = null;
    void Update()
    {
        if (gun == null && GlobalsManager.Instance.tut1Complete == false)
        {
            tutorialScreen.sprite = TutorialSprites[1];
            GlobalsManager.Instance.tut1Complete = true;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6f);
        tutorialScreen.enabled = false;
    }
}
