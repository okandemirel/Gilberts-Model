using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textLeft, textRight;

    [SerializeField]
    private Image barFill, barOutline, circle1, circle2;

    [SerializeField]
    private Color color, backgroundColor;

    private int level;

    private float currentAmount = 0;

    private Coroutine routine;


    private void Start()
    {
        level = LevelManager.main.thisLevel;
    }

    void OnEnable()
    {
        InitColor();
        currentAmount = 0;
        barFill.fillAmount = currentAmount;
        UpdateLevel(level);
    }
    void InitColor()
    {
        circle1.color = color;
        circle2.color = color;

        barFill.color = color;
        barOutline.color = color;
        textLeft.color = backgroundColor;
        textRight.color = color; 
    }

    public void UpdateProgress(float amount, float duration = 0.1f)
    {
        if(routine != null)
        {
            StopCoroutine(routine);
        }

        float target = currentAmount + amount;
        FillRoutine(target, duration);
    }

    private void FillRoutine(float target, float duration)
    {
        float time = 0;
        float tempAmount = currentAmount;
        float diff = target - tempAmount;
        currentAmount = target;

        while (time < duration)
        {
            time += Time.deltaTime;
            float percent = time / duration;
            DoTweenController.BarFill(barFill, tempAmount + diff * percent, time);
        }

        if(currentAmount >= 1)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        UpdateLevel(level + 1);
        UpdateProgress(-1, .2f);
    }

    private void UpdateLevel(int level)
    {
        level = PlayerPrefs.GetInt("level") + 1;
        int nextLevel = PlayerPrefs.GetInt("level") + 2;
        textLeft.text = level.ToString();
        textRight.text = nextLevel.ToString();
    }
}
