using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winlevel : MonoBehaviour
{
    [SerializeField] GameObject _winPanel;
    private void Start()
    {
        _winPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        _winPanel.SetActive(false);
        if (other.gameObject.tag == "Player")
        {
            _winPanel.SetActive(true);

        }
    }
}
