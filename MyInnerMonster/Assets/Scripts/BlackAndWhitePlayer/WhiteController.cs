using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WhiteController : MonoBehaviour
{
	[SerializeField] private float _jumpHight = 700f;
	[Range(0, 0.3f)] [SerializeField] private float _movementSmoothing = 0.05f;



	[SerializeField] private LayerMask _groundLayerMask;
	[SerializeField] private Transform _groundCheckTransform;

	private const float _groundCheckRadius = 0.1f;
	public bool _lookAtRight = true;

	public bool _isGrounded;

	private Rigidbody2D _rigidbody;
	private Vector2 _velocity = Vector2.zero;


	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;
	public UnityEvent IsFallingEvent;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
		if (IsFallingEvent == null)
			IsFallingEvent = new UnityEvent();
	}
	private void FixedUpdate()
	{
		bool wasGrounded = _isGrounded;
		_isGrounded = false;


		if (Physics2D.OverlapCircleAll(_groundCheckTransform.position, _groundCheckRadius, _groundLayerMask).Length != 0)
		{
			_isGrounded = true;
			if (wasGrounded)
			{
				OnLandEvent.Invoke();
			}
		}
		else if (_rigidbody.velocity.y < 0)
		{
			IsFallingEvent.Invoke();
		}

	}

	bool isRunSoundPlaying = false;
	public void Move(float move, bool jump)
	{
		//run sound!
		if (Mathf.Abs(move) > 0.0001f && !isRunSoundPlaying)
        {
			FindObjectOfType<AudioManager>().Play("run");
			isRunSoundPlaying = true;
		} else if (Mathf.Abs(move) < 0.0001f)
        {
			FindObjectOfType<AudioManager>().Pause("run");
			isRunSoundPlaying = false;
		}


		Vector2 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
		_rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, _movementSmoothing);

		ChangeDirection(move);
		Jump(jump);
	}
	private void Flip()
	{
		_lookAtRight = !_lookAtRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private void ChangeDirection(float move)
	{
		if (move > 0 && !_lookAtRight)
		{
			Flip();
		}
		else if (move < 0 && _lookAtRight)
		{
			Flip();
		}
	}
	private void Jump(bool jump)
	{
		if (_isGrounded && jump)
		{
			//FindObjectOfType<AudioManager>().Play("jump");
			_isGrounded = false;
			_rigidbody.AddForce(new Vector2(0f, _jumpHight));
		}
	}
}