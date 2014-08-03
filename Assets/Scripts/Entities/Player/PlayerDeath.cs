using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof(CharacterMotor))]
public class PlayerDeath : Death
{
    public float SecondsUntilDestroy = .5f;
    public AudioClipArray DeathSound;

    public override void OnDeath()
    {
        IsAlive = false;
        DeathSound.PlayRandomAtPoint(transform.position);

        GetComponent<Animator>().SetBool("dead", true);

        GetComponent<CharacterMotor>().enabled = false;

        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;

        collider.enabled = false;
        
        StartCoroutine(WaitUntilDestroy());
    }

    private IEnumerator WaitUntilDestroy()
    {
        yield return new WaitForSeconds(SecondsUntilDestroy*.25f);
        Map.Instance.PlayerSpawn.Spawn();
            
        yield return new WaitForSeconds(SecondsUntilDestroy*.75f);
        Destroy(gameObject);
    }
}