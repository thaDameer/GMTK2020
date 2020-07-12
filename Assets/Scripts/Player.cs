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

    public int _maxHealth = 20; 

    [SerializeField]
    private float _speed = 0.5f;
    [SerializeField]
    private float _waterDepletionRate = 0.1f; 

    public int health = 20;
    public float amountOfWater = 10;

    

    [SerializeField]
    public bool attacking = false;
    public bool isDead = false; 

    [SerializeField]
    Animator animator;
    [SerializeField]
    TrailRenderer trailRenderer;
    public GameObject attackParty;
    public Collider weaponCollider;
    //SFX
    public AudioSource audioSource;
    public AudioClip slashFX;
    public AudioSource audioSourceWatering;
    public AudioClip waterFX;

    private Material originalMaterial;
    public Material hitMaterial;
    public SkinnedMeshRenderer meshRenderer;

    void Start()
    {
        //_controller = GetComponent<CharacterController>();
        //_weapon = GetComponentInChildren<GameObject>();
        //_water = GetComponentInChildren<ParticleSystem>();
        _weapon.SetActive(false);
        health = _maxHealth;
        originalMaterial = meshRenderer.material;
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
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
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
        if (attacking || canDamage) return;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !attacking) //Attack
        {
            audioSource.PlayOneShot(slashFX);
            animator.SetTrigger("attack");
            StartCoroutine("AttackRoutine");  
        }

    }
    bool canDamage;
    IEnumerator AttackRoutine()
    {
        _weapon.SetActive(true);
        var speedTemp = _speed;
        attacking = true; 
        _speed = 0;
        trailRenderer.emitting = true;
        //ATTACK AUDIO CLIP


        yield return new WaitForSeconds(0.1f);
        canDamage = true;
        attacking = false; 
        _weapon.SetActive(false);
        _speed = speedTemp;
        yield return new WaitForSeconds(0.2f);
        trailRenderer.emitting = false;
        canDamage = false;
        
    }
    bool enemyInRange;
    private void OnTriggerStay(Collider other)
    {

        if (!canDamage) return;
      
        var enemy = other.GetComponent<Plants>();
        if (enemy)
        {
            var party = Instantiate(attackParty, other.transform.position, Quaternion.identity);

            Destroy(party, 1f);
            enemy.TakeDamage(1);
            canDamage = false;
            attacking = false;
        }
       
     
        var grass = other.GetComponent<Grass>();
        if (grass)
        {
            grass.CutGrass();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enemyInRange = false;
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            enemyInRange = false;
        }
    }


    void Watering()
    {

        if(Input.GetKey(KeyCode.Mouse1) && amountOfWater > 0)
        {
            _water.Emit(2);
            animator.SetTrigger("watering");
            amountOfWater -= _waterDepletionRate * Time.deltaTime;
            GameManager.instance.uiHandler.UpdateWaterLevelUI(amountOfWater);
            if (!audioSourceWatering.isPlaying)
            {
                audioSourceWatering.Play();
            }
            
            // WATERING AUDIO CLIP

        }

        if(Input.GetKeyUp(KeyCode.Mouse1) || amountOfWater == 0)
        {
            audioSourceWatering.Stop();
        }
        
    }

    private void PlayerDead()
    {
        if (!isDead)
        {
            animator.SetBool("isDead",isDead);
            isDead = true;
        }

        //PLAY ANIMATION 
    }

    public void PlayerDamage()
    {
        health -= 1;
        GameManager.instance.cameraScript.CameraShake();
        animator.SetTrigger("damage");
        GameManager.instance.uiHandler.UpdateHealth(health);
        StartCoroutine(TakeDamage_CO());
        StartCoroutine(TakeDamage_CO());
        if(health <= 0)
        {
            PlayerDead(); 
        }
    }
    IEnumerator TakeDamage_CO()
    {
        meshRenderer.material = hitMaterial;
        yield return new WaitForSeconds(0.05f);
        meshRenderer.material = originalMaterial;
        yield return new WaitForSeconds(0.05f);
        meshRenderer.material = hitMaterial;
        yield return new WaitForSeconds(0.05f);
        meshRenderer.material = originalMaterial;
       
    }

    public void PickupHealth()
    {
        health += 4;
        GameManager.instance.uiHandler.UpdateHealth(health);
        if(health > _maxHealth)
        {
            health = _maxHealth; 
        }
    }

    public void PickupWater()
    {
        amountOfWater += 2;

        if(amountOfWater > 10) //10 = maxWater?
        {
            amountOfWater = 10; 
        }
        GameManager.instance.uiHandler.UpdateWaterLevelUI(amountOfWater);
    }

}
