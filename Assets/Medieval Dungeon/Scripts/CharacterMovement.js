#pragma strict
var speed : float = 7; //player's movement speed
var gravity : float = 10; //amount of gravitational force applied to the player
var jumpSpeed : int = 5;
private var controller : CharacterController; //player's CharacterController component
private var moveDirection : Vector3 = Vector3.zero;

function Start () {
	controller = transform.GetComponent(CharacterController);
}

function Update () {
	//APPLY GRAVITY
	if(moveDirection.y > gravity * -1) {
		moveDirection.y -= gravity * Time.deltaTime;
	}
	controller.Move(moveDirection * Time.deltaTime);
	var forward = transform.TransformDirection(Vector3.forward);
	var left = transform.TransformDirection(Vector3.left);
	
	if(controller.isGrounded) {
		//Jump
		if(Input.GetKeyDown(KeyCode.Space)) {
			moveDirection.y = jumpSpeed;
		}
		//Walk
		else if(Input.GetKey("w")) {
			if(Input.GetKey(KeyCode.LeftShift)) {
				controller.SimpleMove(forward * speed);
			}
			else {
				controller.SimpleMove(forward * speed / 2);
			}
		}
		else if(Input.GetKey("s")) {
			if(Input.GetKey(KeyCode.LeftShift)) {
				controller.SimpleMove(forward * -speed);
			}
			else {
				controller.SimpleMove(forward * -speed / 2);
			}
		}
		else if(Input.GetKey("d")) {
			if(Input.GetKey(KeyCode.LeftShift)) {
				controller.SimpleMove(left * -speed);
			}
			else {
				controller.SimpleMove(left * -speed / 2);
			}
		}
		else if(Input.GetKey("a")) {
			if(Input.GetKey(KeyCode.LeftShift)) {
				controller.SimpleMove(left * speed);
			}
			else {
				controller.SimpleMove(left * speed / 2);
			}
		}
		
	}
	else {
		if(Input.GetKey("w")) {
			var relative : Vector3;
			relative = transform.TransformDirection(0,0,1);
			controller.Move(relative * Time.deltaTime * speed / 1.5);
			//controller.Move(forward * 2);
		}
	}
}
function OnControllerColliderHit (hit : ControllerColliderHit) {
	if(hit.transform.GetComponent.<Rigidbody>()) {
		hit.transform.GetComponent.<Rigidbody>().AddForce(10 * transform.forward);
	}
}