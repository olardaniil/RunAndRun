using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = Math.Round(player.transform.position.z).ToString();
    }
}
