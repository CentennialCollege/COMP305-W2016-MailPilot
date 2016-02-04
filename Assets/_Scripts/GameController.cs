using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._endGame ();
			} else {
				this.LivesLabel.text = "lives: " + this._livesValue;
			}
		}
	}
		
	// PUBLIC INSTANCE VARIABLES
	public int cloudNumber = 3;
	public CloudController cloud;
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public PlaneController plane;
	public IslandController island;

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
		this.GameOverLabel.enabled = false;


		for (int cloudCount = 0; cloudCount < this.cloudNumber; cloudCount++) {
			Instantiate (cloud.gameObject);
		}
	}

	private void _endGame() {
		this.GameOverLabel.enabled = true;
		this.plane.gameObject.SetActive (false);
		this.island.gameObject.SetActive (false);
	}
}
