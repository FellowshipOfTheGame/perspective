using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof(CharacterMotor))]
public class PlayerDeath : Death
{
    public float TimeUntilDestroy = .5f;

    public override void OnDeath()
    {
        GetComponent<Animator>().SetBool("dead", true);

        GetComponent<CharacterMotor>().enabled = false;

        rigidbody.velocity = Vector3.zero;
        rigidbody.useGravity = false;
        collider.enabled = false;
        
        StartCoroutine(WaitUntilDestroy());
    }

    private IEnumerator WaitUntilDestroy()
    {
        yield return new WaitForSeconds(TimeUntilDestroy*.25f);
        Map.Instance.PlayerSpawn.Spawn();
            
        yield return new WaitForSeconds(TimeUntilDestroy*.75f);
        Destroy(gameObject);
    }
}