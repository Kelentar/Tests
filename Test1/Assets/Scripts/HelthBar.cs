using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    // При потребі є можливість добавити градієнт для Hp
    //public Gradient gradient;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}