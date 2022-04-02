using Assets.Sources.Model;
using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private GamePresenter _gamePrefab;
    [SerializeField] private BankPresenter _bankPrefab;
    [SerializeField] private BoardPresenter _boardPrefab;
    [SerializeField] private CardsColumnPresenter _cardsColumnPrefab;
    [SerializeField] private CardPresenter _cardPrefab;

    public void CreateGameState(GameState game)
    {
        Create(_gamePrefab, game);
    }

    public void CreateBank(Bank bank)
    {
        Create(_bankPrefab, bank);
    }

    public void CreateBoard(Board board)
    {
        Create(_boardPrefab, board);
    }

    public void CreateCardsColumn(CardsColumn cardsColumn)
    {
        Create(_cardsColumnPrefab, cardsColumn);
    }

    public void CreateCard(Card card)
    {
        Create(_cardPrefab, card);
    }

    private void Create<TModel>(Presenter<TModel> presenter, TModel model)
        where TModel : Transformable
    {
        Instantiate(presenter).Init(model);
    }
}
