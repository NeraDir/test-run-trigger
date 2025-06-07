using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewCharacter : MonoBehaviour,IMotion
{
    [SerializeField] private FollowerEntity m_CharacterPrefab;
    [SerializeField] private Transform m_SpawnPosition;
    [SerializeField] private Transform m_TargetPosition;

    public void Use()
    {
        AddCharacter();
    }

    private void AddCharacter()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        FollowerEntity spawnedBot = Instantiate(m_CharacterPrefab, m_SpawnPosition.position,Quaternion.identity);
        MoveCharacter(spawnedBot,m_TargetPosition);
    }

    private void MoveCharacter(FollowerEntity bot, Transform target)
    {
        bot.SetDestination(target.position);
        BotComponent botC = bot.GetComponent<BotComponent>();
        botC.Init();
        botC.Move();
    }
}
