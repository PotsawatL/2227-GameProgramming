using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI liveText;

    public void UpdateLives(int live)
    {
        liveText.text = $"Lives: {live}";
    }

}

