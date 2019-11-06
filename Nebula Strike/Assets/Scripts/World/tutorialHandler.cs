using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialHandler : MonoBehaviour
{
    public Image tutorialScreen;
    public Sprite[] TutorialSprites;
    public GameObject gun = null;
    public GameObject cloak = null;
    public GameObject shotgun = null;
    public GameObject mg2 = null;
    public GameObject cannon = null;
    public bool cloakPickedup = false;
    public bool shotgunPickedup = false;
    public bool mg2Pickedup = false;
    public bool cannonPickedup = false;
    public Scene scene;
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "tutorial1")
        {
            if (gun == null && GlobalsManager.Instance.tut1Complete == false)
            {
                tutorialScreen.sprite = TutorialSprites[1];
                GlobalsManager.Instance.tut1Complete = true;
            }
        }
     
        else if (cloak == null && cloakPickedup == false)
        {
            tutorialScreen.sprite = TutorialSprites[6];
            cloakPickedup = true;
            tutorialScreen.enabled = true;
            StartCoroutine("Wait");
        }
        else if (shotgun == null && shotgunPickedup == false)
        {
            tutorialScreen.sprite = TutorialSprites[4];
            shotgunPickedup = true;
            tutorialScreen.enabled = true;
            StartCoroutine("Wait");
        }
        else if (mg2 == null && mg2Pickedup == false)
        {
            tutorialScreen.sprite = TutorialSprites[3];
            mg2Pickedup = true;
            tutorialScreen.enabled = true;
            StartCoroutine("Wait");
        }
        else if (cannon == null && cannonPickedup == false)
        {
            tutorialScreen.sprite = TutorialSprites[5];
            cannonPickedup = true;
            tutorialScreen.enabled = true;
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6f);
        tutorialScreen.enabled = false;
    }
}
