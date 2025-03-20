using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStatus status;

    private void Awake()
    {
        status = GetComponent<CharacterStatus>();
    }
}
