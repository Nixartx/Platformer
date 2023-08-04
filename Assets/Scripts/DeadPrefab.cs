using System.Collections;
using UnityEngine;

public class DeadPrefab : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        StartCoroutine(CorpseDestroyCooldown());
    }

    IEnumerator CorpseDestroyCooldown()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(CorpseDestroy());
    }

    IEnumerator CorpseDestroy()
    {
        Color color = _spriteRenderer.color;
        
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(.5f);
            color.a = color.a == 0 ? 1 : 0;
            _spriteRenderer.color = color;
        }
        Destroy(gameObject);
    }


}
