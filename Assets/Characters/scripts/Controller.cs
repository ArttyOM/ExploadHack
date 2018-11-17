using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]

public class Controller : MonoBehaviour 
{		
	[Header("Здоровье")] 
		public  float health = 100; //
		public bool alive = true;//
		[Header("Активно при смерти")] 
public GameObject DeathObj;
			
			
	private Rigidbody body;
	private Animator __animator;
	private float __speed;
	private float __Direction;
	private float __Sprinting;
	private float __jump;
	private bool __crouch;
	private bool __att;
 
	public void Start () {
		__animator = GetComponent<Animator> ();
	}	
		void Awake()
	{
		// выключаем курсор
		    Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
		// присваеваем значения компонента и замараживаем ему ратации
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
	}
	public void Update () {
		if(alive)
			{	
					if (health <= 0)
					{alive = false;	Die ();	}
			__speed = Input.GetAxis("Vertical");
			__Direction = Input.GetAxis("Horizontal");
			Sprinting ();
			Jumping ();
			Crouching ();
			Fire ();
			

			}

	}
	public void FixedUpdate (){
		__animator.SetFloat ("Speed", __speed);
		__animator.SetFloat ("Direction", __Direction);
		__animator.SetFloat ("Sprinting", __Sprinting);
		__animator.SetFloat ("Jump", __jump);
		__animator.SetBool ("Crouch", __crouch);
		__animator.SetBool ("Attack", __att);
	}
	public void Sprinting (){
		if (Input.GetKey(KeyCode.LeftShift)) {
		__Sprinting = 1.0f;
		} 
		else {
			__Sprinting = 0.0f;
				}
	}

	public void Jumping(){
		if (Input.GetKey(KeyCode.Space)){
		__jump = 1.0f;
		}
		else {
		__jump = 0.0f;
		}
	}
	public void Crouching (){
		if (Input.GetKey (KeyCode.C)) {
		__crouch = true;
		} else {
		__crouch = false;
		}
	}
	public void Fire (){
		if (Input.GetKey (KeyCode.Q)){
			__att = true;
		}
		else{
			__att = false;
		}
	}
	 

	
	
	void OnTriggerEnter(Collider other)	// действие, когда персонаж входит в тригер
		{ 
			if (other.tag == "DeadZone")		// таг  название тригера
			{ Die (); }
		}

	
	public void Die() {
		__animator.SetTrigger ("death"); 
		alive = false;
				DeathObj.SetActive (true);///
		Debug.Log("Вы умерли!!!");  
	}

	

//смена одежды
 
	
}
