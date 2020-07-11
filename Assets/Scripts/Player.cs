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

    [SerializeField]
    private float _speed = 0.5f;
    [SerializeField]
    private float _waterDepletionRate = 0.1f; 

    public int health = 3;
    public float amountOfWater = 10;

    [SerializeField]
    private bool attacking = false; 





    void Start()
    {
        //_controller = GetComponent<CharacterController>();
        //_weapon = GetComponentInChildren<GameObject>();
        //_water = GetComponentInChildren<ParticleSystem>();
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
        _controller.Move(new Vector3(horizontalMovement * _speed, 0, verticalMovement * _speed));
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
        if (Input.GetKeyDown(KeyCode.Mouse0)) //Attack
        {
            StartCoroutine("AttackRoutine");  
        }

    }

    IEnumerator AttackRoutine()
    {
        _weapon.SetActive(true);
        var speedTemp = _speed;
        attacking = true; 
        _speed = 0; 
        //ATTACK AUDIO CLIP


        yield return new WaitForSeconds(0.4f);

        attacking = false; 
        _weapon.SetActive(false);
        _speed = speedTemp; 
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
