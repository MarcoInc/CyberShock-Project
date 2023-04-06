using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooleanConverter{
	//used to set a bool value
	public static void SetBool(string name, bool booleanValue) {
		PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
	}
	//used to get a bool value 
	public static bool GetBool(string name)  {
	    return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}
	//overloading 
	public static bool GetBool(string name, bool defaultValue){
	    if(PlayerPrefs.HasKey(name)){
	        return GetBool(name);
	    } 
	    return defaultValue;
	}
}
