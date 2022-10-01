using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void ProcessTimer(float currentTimer, float maxTimer)
    {
        var timerPercentage = currentTimer / maxTimer;

        fillImage.fillAmount = timerPercentage;
    }
}
