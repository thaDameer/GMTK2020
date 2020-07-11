using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController _controller;

    [SerializeField]
    private ParticleSystem _water; 

    [SerializeField]
    private GameObject _weapon;
    public float gravity = -9.81f;

    [SerializeField]
    private float _speed = 0.5f;
    [SerializeField]
    private float _waterDepletionRate = 0.1f; 

    public int health = 3;
    public float amountOfWater = 10;

    [SerializeField]
    private bool attacking = false;

    [SerializeField]
    Animator animator;
    [SerializeField]
    TrailRenderer trailRenderer;


    void Start()
    {
        //_controller = GetComponent<CharacterController>();
        //_weapon = GetComponentInChildren<GameObject>();
        //_water = GetComponentInChildren<ParticleSystem>();
        trailRenderer.emitting = false;
        _weapon.SetActive(false); 
    }

    void Update()
    {
        Move();
        Rotate();
        Attack();
        Watering(); 
    }


    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(horizontalMovement, 0, verticalMovement);
        animator.SetFloat("movementX", horizontalMovement);
        animator.SetFloat("movementY", verticalMovement);
        _controller.Move(new Vector3(horizontalMovement, gravity, verticalMovement) * Time.deltaTime * _speed);
    }

    void Rotate() //rotates with mouse
    {
        if (!attacking)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitPos = hit.point;
                var targetRotation = Quaternion.LookRotation(hitPos - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;

                transform.rotation = targetRotation;// Quaternion.Slerp(transform.rotation, targetRotation,10);
            }
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking) //Attack
        {
            animator.SetTrigger("attack");
            StartCoroutine("AttackRoutine");  
        }

    }
    float attackTime = 0.25f;
    IEnumerator AttackRoutine()
    {

        trailRenderer.emitting = true;
        _weapon.SetActive(true);
        var speedTemp = _speed;
        attacking = true; 
        _speed = 0; 
        //ATTACK AUDIO CLIP


        yield return new WaitForSeconds(attackTime);

        attacking = false;
        _weapon.SetActive(false);
        _speed = speedTemp;
        yield return new WaitForSeconds(0.3f);
        trailRenderer.emitting = false;
        yield break;
    }

    void Watering()
    {

        Debug.Log("Watering"); 
        if(Input.GetKey(KeyCode.Mouse1) && amountOfWater > 0)
        {
            _water.Emit(2);
            amountOfWater -= _waterDepletionRate * Time.deltaTime; 

            // WATERING AUDIO CLIP

        }
        
    }
}
