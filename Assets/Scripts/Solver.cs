using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static double Evaluate(string expression)
     {
         var doc = new System.Xml.XPath.XPathDocument(new System.IO.StringReader("<r/>"));
         var nav = doc.CreateNavigator();
         var newString = expression;
         newString = (new System.Text.RegularExpressions.Regex(@"([\+\-\*])")).Replace(newString, " ${1} ");
         newString = newString.Replace("/", " div ").Replace("%", " mod ");
         return (double)nav.Evaluate("number(" + newString + ")");
     } 
}
