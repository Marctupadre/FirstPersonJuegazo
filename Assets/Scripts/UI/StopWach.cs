using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StopWach : MonoBehaviour
{
    public float timer = 0;

    public Text textTimer;

    public TextMeshProUGUI textMeshProUGUI;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        textTimer.text = "" + timer.ToString("f1");

        textMeshProUGUI.text = "" + timer.ToString("f1");
    }
}
