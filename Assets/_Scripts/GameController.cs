using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _livesValue;

	// PUBLIC ACCESS METHODS
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			Debug.Log (this._scoreValue);
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			Debug.Log (this._livesValue);
		}
	}
		

	// PUBLIC INSTANCE VARIABLES
	public int cloudNumber = 3;
	public CloudController cloud;


	// Use this for initialization
	void Start () {
		this._initialize ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//PRIVATE METHODS ++++++++++++++++++

	//Initial Method
	private void _initialize() {
		this.ScoreValue = 0;
		this.LivesValue = 5;


		for (int cloudCount = 0; cloudCount < this.cloudNumber; cloudCount++) {
			Instantiate (cloud.gameObject);
		}
	}
}
