using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transmissionController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource transmissions;
    public GameObject perimeterTurret;
    public GameObject controlTower;
    public AudioClip[] transmissionList;
    public Sprite[] transmissionSprites;
    public Image transmissionScreen;
    public bool transmissionComplete;
    public bool controlTowerTransmission = false;
    public bool perimeterTurretTransmission = false;
    public bool finaltransmission = false;

    private void Start()
    {
        transmissions.clip = transmissionList[0];
        transmissions.Play();
    }
    void Update()
    {
        if (transmissions.isPlaying)
        {
            music.volume = 0.1f;
            transmissionScreen.enabled = true;
        } else
        {
            music.volume = 0.4f;
            transmissionScreen.enabled = false;
        }
        if (transmissions.clip == transmissionList[0])
        {
            if (transmissions.isPlaying == false)
            {
                transmissionComplete = false;
                StartCoroutine("Wait");
                transmissions.clip = transmissionList[1];
                transmissions.volume = 0.3f;
                transmissionScreen.sprite = transmissionSprites[1];
            }
        }
        if (transmissions.clip == transmissionList[1] && transmissionComplete == true)
        {
            if (transmissions.isPlaying == false)
            {
                transmissionComplete = false;
                Debug.Log("Transmission incoming...");
                StartCoroutine("Wait");
                transmissions.clip = transmissionList[2];
                transmissions.volume = 0.3f;
                transmissionScreen.sprite = transmissionSprites[2];
            }
        }
        if (perimeterTurret != null)
        {
            if (transmissionComplete == true && Vector3.Distance(transform.position, perimeterTurret.transform.position) < 50f && perimeterTurretTransmission == false)
            {
                if (transmissions.isPlaying == false)
                {
                    transmissionComplete = false;
                    Debug.Log("Transmission incoming...");
                    StartCoroutine("Wait");
                    transmissions.clip = transmissionList[3];
                    transmissions.volume = 0.3f;
                    transmissionScreen.sprite = transmissionSprites[3];
                    perimeterTurretTransmission = true;
                }
            }
        }
        if (controlTower != null)
        {
            if (transmissionComplete == true && Vector3.Distance(transform.position, controlTower.transform.position) < 40f && controlTowerTransmission == false)

                if (transmissions.isPlaying == false)
                {
                    transmissionComplete = false;
                    Debug.Log("Transmission incoming...");
                    StartCoroutine("Wait");
                    transmissions.clip = transmissionList[4];
                    transmissions.volume = 0.3f;
                    transmissionScreen.sprite = transmissionSprites[4];
                    controlTowerTransmission = true;
                }
        }
    

        if (GlobalsManager.Instance.level1Completed == true && transmissionComplete == true && finaltransmission == false)
        {
            if (transmissions.isPlaying == false)
            {
                transmissionComplete = false;
                Debug.Log("Transmission incoming...");
                StartCoroutine("Wait");
                transmissions.clip = transmissionList[5];
                transmissions.volume = 0.3f;
                transmissionScreen.sprite = transmissionSprites[5];
                finaltransmission = true;
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        transmissions.Play();
        transmissionComplete = true;
    }
}
