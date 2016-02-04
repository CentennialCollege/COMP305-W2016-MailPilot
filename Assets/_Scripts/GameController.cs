using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _livesValue;

	[SerializeField]
	private AudioSource _gameOverSound;

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
	public PlaneController plane;
	public IslandController island;
	public Text LivesLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton;

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
		this.HighScoreLabel.enabled = false;
		this.RestartButton.gameObject.SetActive(false);


		for (int cloudCount = 0; cloudCount < this.cloudNumber; cloudCount++) {
			Instantiate (cloud.gameObject);
		}
	}

	private void _endGame() {
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;
		this.GameOverLabel.enabled = true;
		this.HighScoreLabel.enabled = true;
		this.LivesLabel.enabled = false;
		this.ScoreLabel.enabled = false;
		this.plane.gameObject.SetActive (false);
		this.island.gameObject.SetActive (false);
		this._gameOverSound.Play ();
		this.RestartButton.gameObject.SetActive (true);
	}

	// PUBLIC METHODS

	public void RestartButtonClick() {
		Application.LoadLevel ("Main");
	}
}
