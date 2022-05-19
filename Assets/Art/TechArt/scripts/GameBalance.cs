using UnityEngine;

[CreateAssetMenu(fileName = "New game Balance", menuName = "Meus Trecos/Game Balance")]
public class GameBalance : ScriptableObject
{
    public float Tempo;
    public float Pontuacao;
    public Vector2 Posicao;
    public Vector2[] Posicoes;
    public Transform Transform;
}
