using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerPlatformerController : PhysicsObject
{
    public float MaxSpeed = 7;
    public float JumpTakeOffSpeed = 7;
    public int PointPerItem = 10;
    public Text ScoreText;
    public Tilemap ColliderTilemap;
    public Tilemap CheckpointTilemap;
    public bool Flip;

    public Text DebugPos, DebugColliderPos;
    public Tilemap Debug;


    private GameObject Particule_Poussière;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private int _playerPoint = 0;
    private Vector2 _spawnPoint;
    

    // Use this for initialization
    void Awake()
    {
        Particule_Poussière = GameObject.Find("Particule_Poussière");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spawnPoint = GetComponent<Transform>().position;
        ColliderTilemap.GetComponent<TilemapRenderer>().enabled = false;
        CheckpointTilemap.GetComponent<TilemapRenderer>().enabled = false;
    }


    protected override void ComputeVelocity()
    {
        DebugPos.text = GetComponent<Transform>().position.ToString();
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = JumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (move.x > 0.01f)
        {
            if (_spriteRenderer.flipX == true)
            {
                Flip = false;
                _spriteRenderer.flipX = false;
            }
        }
        else if (move.x < -0.01f)
        {

            if (_spriteRenderer.flipX == false)
            {
                Flip = true;
                _spriteRenderer.flipX = true;
            }
        }
        
        //Propriétes de(s) effet(s) de particule

        if (_spriteRenderer.flipX)
        {
            Particule_Poussière.transform.eulerAngles = new Vector3(180, 0, 180);
        }
        else
        {
            Particule_Poussière.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        Particule_Poussière.SetActive(grounded);

        //Fin des Propriétes

        _animator.SetBool("Grounded", grounded);
        _animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / MaxSpeed);

        targetVelocity = move * MaxSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("objet"))
        {
            other.GetComponent<ParticleSystem>().Play();
            _playerPoint += PointPerItem;
            UpdateScoreText();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("collider"))
        {
            GetComponent<Transform>().position = _spawnPoint;
        }

        if (other.gameObject.CompareTag("checkpoint"))
        {
            Tilemap tilemap = other.GetComponent<Tilemap>();
            Vector3Int tilePosition = tilemap.WorldToCell(GetComponent<Transform>().position);
            Vector3Int[] tabTile = new Vector3Int[9];
            tabTile[0] = tilePosition;
            tabTile[1] = tilePosition + new Vector3Int(1, 0, 0);
            tabTile[2] = tilePosition + new Vector3Int(-1, 0, 0);
            tabTile[3] = tilePosition + new Vector3Int(0, 1, 0);
            tabTile[4] = tilePosition + new Vector3Int(0, -1, 0);
            tabTile[5] = tilePosition + new Vector3Int(-1, 1, 0);
            tabTile[6] = tilePosition + new Vector3Int(1, -1, 0);
            tabTile[7] = tilePosition + new Vector3Int(1, 1, 0);
            tabTile[8] = tilePosition + new Vector3Int(-1, -1, 0);
            foreach (Vector3Int tilePos in tabTile)
            {
                if (tilemap.HasTile(tilePos))
                {
                    UnityEngine.Debug.Log("tilePos");
                    UnityEngine.Debug.Log(tilePos);
                    tilePosition = tilePos;
                    UnityEngine.Debug.Log("tilemap.GetCellCenterWorld(tilePosition)");
                    UnityEngine.Debug.Log(tilemap.GetCellCenterWorld(tilePosition));
                    Vector3 tileWorldPosition = tilemap.GetCellCenterWorld(tilePosition) + new Vector3(0, 0.6f, 0);
                    _spawnPoint = tileWorldPosition;
                    DebugColliderPos.text = _spawnPoint.ToString();
                }
            }
        }
    }

    void UpdateScoreText()
    {
        ScoreText.text = "Score : " + _playerPoint.ToString();
    }
}