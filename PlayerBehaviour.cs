using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(CommandProcessor))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerBehaviour : MonoBehaviour, IEntity
{
    [SerializeField] private float speed;
    
    [SerializeField] private Tilemap groundTM;
    [SerializeField] private Tilemap colliderTM;
    [SerializeField] private Tilemap waterTM;

    private ScoreManager scoreManager;

    private PlayerMovement controls;
    private Coroutine _coroutine;

    private CommandProcessor cp;

    private Vector2 playerInput;
    private Vector2 moveTo;

    private CircleCollider2D playerTrigger;
    private Collider2D logTrigger;
    private Collider2D prevLogTrigger;
    [SerializeField] private LayerMask logLayerMask;

    private Rigidbody2D rb;

    public Animator animator => GetComponent<Animator>();

    private void Awake()
    {
        cp = GetComponent<CommandProcessor>();
        controls = new PlayerMovement();
        prevLogTrigger = new Collider2D();
        rb = GetComponent<Rigidbody2D>();
        playerTrigger = GetComponent<CircleCollider2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        playerInput = Vector2.zero;

        controls.Player.Move.performed += ctx => OnPlayerMoveChange(ctx);
        //controls.Player.Undo.performed += ctx => OnPlayerUndo(ctx);
    }

    private void Update()
    {

        if (isWater())
        {
            logTrigger = Physics2D.OverlapPoint(transform.position, logLayerMask);
            if(Mathf.Approximately(Vector3.Distance(transform.position, moveTo), 0) && !logTrigger) die();
            if (logTrigger && logTrigger != prevLogTrigger)
            {
                //Debug.Log("hit");
                prevLogTrigger = logTrigger;
                logTrigger.gameObject.GetComponent<LogScript>().onLogEnter();
                if (_coroutine != null) StopCoroutine(_coroutine);
            }
        }
    }

    public void OnPlayerUndo(InputAction.CallbackContext input)
    {
        Debug.Log("undo called");
        cp.UndoCommand();
    }

    public void OnPlayerMoveChange(InputAction.CallbackContext input)
    {
        Debug.Log("move called");
        playerInput = input.ReadValue<Vector2>();
        if (transform.parent != null && playerInput.y == 0) return;
        transform.parent = null;
        if (!CanMove(playerInput)) return;
        addJump();
        moveTo = (Vector2)transform.position + playerInput;
        cp.ExecuteCommand(new MoveCommand(this, (Vector2)transform.position + playerInput));
        if(playerInput.y > 0) scoreManager.addScore(10);
        rotate(playerInput);
    }

    public void MoveTo(Vector3 start, Vector3 end)
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(MoveToAsync(start, end));
    }

    private IEnumerator MoveToAsync(Vector3 start, Vector3 end)
    {
        animator.SetFloat("Speed", 1);
        float elapsed = 0;
        while(elapsed < 1f)
        {
            transform.position = Vector3.Lerp(start, end, elapsed * speed);
            if (Vector3.Distance(transform.position, end) < 0.5) animator.SetFloat("Speed", 0);
            elapsed += Time.deltaTime;
            yield return null; 
        }
        transform.position = end;
    }

    void rotate(Vector2 input)
    {
        if (input.x == -1f)
        {
            transform.eulerAngles = Vector3.forward * 90f;
        }
        else if (input.x == 1f)
        {
            transform.eulerAngles = Vector3.forward * -90f;
        }
        else if (input.y == 1f)
        {
            transform.eulerAngles = Vector3.forward * 0f;
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTM.WorldToCell(transform.position + (Vector3) direction);
        if (!groundTM.HasTile(gridPosition) || colliderTM.HasTile(gridPosition)) return false;
        return true;
    }

    private bool isWater()
    {
        Vector3Int gridPosition = waterTM.WorldToCell(transform.position);
        if (waterTM.HasTile(gridPosition)) return true;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<VehicleMovementScript>())
        {
            addSquish();
            // play audio clip if name is "seanwalton"
            if (PlayerPrefs.GetString("name").ToLower().Equals("seanwalton")) GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("hi");
            die();
        }
        else if (collision.tag == "Bound")
        {
            die();
        }
    }

    private void addSquish()
    {
        PlayerPrefs.SetInt("squish", PlayerPrefs.GetInt("squish") + 1);
        PlayerPrefs.Save();
    }

    private void addJump()
    {
        PlayerPrefs.SetInt("jump", PlayerPrefs.GetInt("jump") + 1);
        PlayerPrefs.Save();
    }

    public void die()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        resetLocation();
        GameObject.Find("LivesText").GetComponent<LivesScript>().takeLife();
        GameObject.Find("TimerText").GetComponent<TimerScript>().resetTimer();
    }

    public void resetLocation()
    {
        transform.parent = null;
        transform.position = new Vector3(5, -8, 0);
    }
}
