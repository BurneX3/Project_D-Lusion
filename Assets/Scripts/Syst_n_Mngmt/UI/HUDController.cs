using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    public Image lifeBar, parryIcon;
    public float lerpDuration;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateParryCooldown(float timer, float duration)
    {
        float cooldownRatio = Mathf.InverseLerp(duration, 0, timer);
        parryIcon.fillAmount = cooldownRatio;
    }

    public void UpdateLifeBar(int currentHealth, int maxHealth)
    {
        float healthRatio = Mathf.InverseLerp(0, maxHealth, currentHealth);

        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, healthRatio, lerpDuration);
    }

    /*IEnumerator UpdateLife(int currentHealth, int maxHealth)
    {
        float t = 0;
        float healthRatio = Mathf.InverseLerp(0, maxHealth, currentHealth);

        while(true)
        {
            yield return null;

            t += Time.deltaTime;
            lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, healthRatio, t/lerpDuration);

            if(t > lerpDuration)
            {
                break;
            }
        }
    }*/
}
