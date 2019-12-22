using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	public AudioClip moneySound;
	public AudioClip puddleSound;
	public AudioClip tornadoSound;
	public AudioClip explosionSound;
	AudioSource audioSource;
	public HealthBar healthBarPrefab;
	HealthBar healthBar;

    void Start()
	{
		audioSource = FindObjectOfType<AudioSource>();
		hitPoints.value = startingHitPoints;
		healthBar = Instantiate(healthBarPrefab);
		healthBar.character = this;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		print("COLLISION: " + collision.name + " " + collision.gameObject.CompareTag("WaterHazard"));
		if (collision.gameObject.CompareTag("CanBePickedUp"))
		{
			Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if(hitObject != null)
			{
				switch(hitObject.itemType){
					case Item.ItemType.COIN:
						audioSource.PlayOneShot(moneySound, 0.7f);
						break;
					case Item.ItemType.HEALTH:
						AdjustHitPoints(hitObject.quantity);
						break;
					default:
						break;
				}
				print("hit: " + hitObject.objectName);
				collision.gameObject.SetActive(false);
			}
		} else if (collision.gameObject.CompareTag("WaterHazard"))
		{
			AdjustHitPoints(-5);
			audioSource.PlayOneShot(puddleSound, 0.7f);
		}
		else if (collision.gameObject.CompareTag("Tornado"))
		{
			AdjustHitPoints(-5);
			audioSource.PlayOneShot(tornadoSound, 0.7f);
		}
		else if (collision.gameObject.CompareTag("FireMissle"))
		{
			AdjustHitPoints(-25);
			audioSource.PlayOneShot(explosionSound, 0.7f);
		}

	}

    public void AdjustHitPoints(int amount)
	{
		hitPoints.value = hitPoints.value + amount;
		if (hitPoints.value > maxHitPoints)
		{
			hitPoints.value = maxHitPoints;
		}
		print("adjusted hitpoints by: " + amount + ". New value: " + hitPoints.value);
	}
}
