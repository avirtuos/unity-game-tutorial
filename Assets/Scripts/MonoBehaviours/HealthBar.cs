using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
	public HitPoints hitPoints;
	[HideInInspector]
	public Player character;
	public Image meterImage;
	public Text hpText;
	float maxHitPoints;


    // Start is called before the first frame update
    void Start()
    {
		if (character != null)
		{
			maxHitPoints = character.maxHitPoints;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(character != null)
		{
			meterImage.fillAmount = hitPoints.value / maxHitPoints;
			hpText.text = "LUCA: " + (meterImage.fillAmount * 100);
		}
    }
}
