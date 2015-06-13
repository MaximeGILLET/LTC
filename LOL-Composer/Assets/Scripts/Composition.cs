using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine.UI;


public class Composition : MonoBehaviour {

	public Slider[] slider;
	public Slider[] globalSlider;
	public AnimationCurve sliderCurve;

	//We make a static variable to our Composition instance
	public static Composition instance { get; private set; }
	
	//When the object awakens, we assign the static variable
	void Awake() 
	{
		instance = this;
	}

	//public static Dictionary<string,Champion> roster;
	public static  List<Champion> roster;//maybe use dictionnary
	public bool dirty = false;
	
	public Dictionary<string,int> golbalAbilities;

	/*
	// Main abilities
	private int engage;
	private int disengage;
	private int sustain;
	private int scaling;
	private int poke;
	private int tanking;
	private int locking;
	private int waveClear;
	private int siege;
	
	// Secondary abilities
	private int peeling;
	private int diving;
	private int bursting;
	private int areaDamage;
	private int mobility;
	
	// Extra bonus
	private int metaGameBonus;
	*/

	void Start(){

		roster = new List<Champion>();
		updateStats ();

	}

	// Update stats of the composition
	private void updateStats(){

		foreach (var prop in golbalAbilities) {

			golbalAbilities[prop.Key] = meanProperty(prop.Key);
		}

		/*
		var props = instance.GetType().GetFields (BindingFlags.NonPublic|BindingFlags.Instance);
		Debug.Log(props.Length);
		foreach (var prop in props) {

			prop.SetValue(instance,meanProperty(prop));
		}*/

	}

	// Return the average of the property in the roster for the given key
	private int meanProperty(string key){

		int meanValue = 0;
		
		foreach (var champ in roster) {
			
			if(champ != null)
				meanValue += champ.abilities[key]/roster.Count;
			
		}
		
		return meanValue;
	}

	// Return the average of the property in the roster for the given field
	/*
	private int meanProperty(FieldInfo field){
		int meanValue = 0;

		foreach (var champ in roster) {

			if(champ != null)
			meanValue += (int)field.GetValue(champ)/roster.Length;


		}

		return meanValue;
	}*/

	public void addChampionToRoster(Champion newChamp){

		roster.Add (newChamp);
	}

	public void removeChampionFromRoster(Champion champ){

		roster.Remove(champ);
	}

	public void replaceChampionInRoster(Champion oldChamp , Champion newChamp){

		roster.Remove(oldChamp);
		roster.Add (newChamp);
	
	}

	void Update(){


	}

	// Animate sliders for the selected champions
	IEnumerator animateSliders(){

		foreach( var elmt in slider){
			
			
			elmt.image.fillAmount = 0;
		}

		while (slider[0].image.fillAmount <1) {

			foreach( var elmt in slider){


				elmt.image.fillAmount += 0.1f;
			}

			yield return new WaitForSeconds(0.02f);
		}


	}

	// Animate sliders for the composition
	IEnumerator animateGlobalSliders(){
		
		foreach( var elmt in globalSlider){
			
			
			elmt.image.fillAmount = 0;
		}

		while (globalSlider[0].image.fillAmount <1) {
			
			foreach( var elmt in globalSlider){
				
				
				elmt.image.fillAmount += 0.1f;
			}
			
			yield return new WaitForSeconds(0.02f);
		}
	}

}
