using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    private PlayerManager _playerManager;
    private CharacterStats _myStats;

    private void Start()
    {
        _playerManager = PlayerManager.Instance;
        _myStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = _playerManager.Player.GetComponent<CharacterCombat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(_myStats);
        }
    }
}
