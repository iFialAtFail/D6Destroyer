using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    public TargetRuntimeSet Set;
    public GameEvent loseALifeEvent;

    public int scoreValue = 100;
    public Renderer theRenderer;
    public List<Color> colors;
    public Rigidbody Rigidbody;
    public Collider Collider;

    public event EventHandler TargetDiedEvent;

    private GameManager gameManager;
    public GameManager GameManager
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            return gameManager;
        }
    }

    public virtual void Start()
    {
        scoreValue = UnityEngine.Random.Range(1, 11);
        ChangeColor(scoreValue);
        Set.Add(this);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Projectile") return;
        Destroy(collision.gameObject.gameObject);
        TakeDamage();
        ChangeColor(scoreValue);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag != "Projectile") return;
        TakeDamage();
        ChangeColor(scoreValue);
	}

	public virtual void TakeDamage()
    {
        if (this.GameManager.InstantKill)
        {
            this.GameManager.Hits += scoreValue;
            scoreValue = 0;
        }
        else if (this.GameManager.DoubleBurn)
        {
            scoreValue -= 2;
            this.GameManager.Hits += 2;
        }
        else
        {
            scoreValue--;
            this.GameManager.Hits++;
        }

        if (scoreValue < 1)
        {
            TargetDiedEvent?.Invoke(null, null);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Just kill the target without worrying about score.
    /// </summary>
    public void JustKill(){
        TargetDiedEvent?.Invoke(null, null);
        Destroy(this.gameObject);
    }

    public virtual void ChangeColor(int score)
    {
        if (theRenderer == null) return;

        switch (score)
        {
            case 1:
                theRenderer.material.color = colors[0];
                break;
            case 2:
                theRenderer.material.color = colors[1];
                break;
            case 3:
                theRenderer.material.color = colors[2];
                break;
            case 4:
                theRenderer.material.color = colors[3];
                break;
            case 5:
                theRenderer.material.color = colors[4];
                break;
            case 6:
                theRenderer.material.color = colors[5];
                break;
            case 7:
                theRenderer.material.color = colors[6];
                break;
            case 8:
                theRenderer.material.color = colors[7];
                break;
            case 9:
                theRenderer.material.color = colors[8];
                break;

            default:
                theRenderer.material.color = colors[9];
                break;
        }
    }

    /// <summary>
    /// Handles the death of a target. We simply destroy the target at this point.
    /// and raise the lose a life event.
    /// </summary>
    public virtual void HandleDeath()
    {
        if (loseALifeEvent != null)
        {
            loseALifeEvent.Raise();
        }
        Destroy(this.gameObject);
    }


    protected virtual void OnDestroy()
    {
        
        if (Set.Items.Contains(this))
            Set.Remove(this);


    }

}