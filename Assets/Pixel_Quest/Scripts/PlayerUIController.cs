using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public Image heartImage;
    public TextMeshProUGUI coinText;

    public void UpdateText(string newText)
    {
        coinText.text = newText;
    }

    // Start is called before the first frame update
    public void StartUI()
    {
        heartImage = GameObject.Find("HeartImage").GetComponent<Image>();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateHealth (float currentHealth, float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }
}
