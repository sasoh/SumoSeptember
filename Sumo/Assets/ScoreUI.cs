//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
	[Serializable]
	public enum Player
	{
		One = 1, 
		Two = 2
	}

	public Text text;
	public Player player;

	private string _originalText;

	public void Start() {
		_originalText = text.text;
	}

	public void Update() {
		int value;
		if (player == Player.One) {
			value = MatchManagerScript.Instance.Score1;
		} else {
			value = MatchManagerScript.Instance.Score2;
		}
		text.text = string.Format(_originalText, value);
	}

}

