﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GlobalsManager.Instance.mg1notYetAdded = true;
            GlobalsManager.Instance.mg2notYetAdded = true;
            GlobalsManager.Instance.tractorbeamnotYetAdded = true;
            GlobalsManager.Instance.mg1Equipped = false;
            GlobalsManager.Instance.mg2Equipped = false;
            GlobalsManager.Instance.tractorbeamEquipped = false;
            GlobalsManager.Instance.mg1 = false;
            GlobalsManager.Instance.mg2 = false;
            GlobalsManager.Instance.tractorBeam = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
