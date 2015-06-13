using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Champion{

	static readonly string urlData = "";

	/** Champions class attributes **/

	public enum Roles{ assassin , marksman, support , jungler, tank , mage , fighter};
	public enum Position{ Top , Jungle , Mid , Support , Adc};

	// Basic properties
	public string name;
	private int difficulty;
	private Position position;
	private Roles[] roles;

	// Abilities retrieved from database order ASC (the top 9 abilities are displayed)
	public Dictionary<string,int> abilities;

	/*
	// Main abilities
	public int engage;
	public int disengage;
	public int sustain;
	public int scaling;
	public int poke;
	public int tanking;
	public int locking;
	public int waveClear;
	public int siege;

	// Secondary abilities
	public int peeling;
	public int diving;
	public int bursting;
	public int areaDamage;
	public int mobility;

	// Extra bonus
	public int metaGameBonus;
	*/

	// Request champion data from database
	public void getChampionData(){



	}
}
