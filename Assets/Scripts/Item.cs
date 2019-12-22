﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
	public string objectName;
	public Sprite sprite;
	public int quantity;
	public bool stackable;
	public ItemType itemType;

	public enum ItemType { COIN, HEALTH }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
