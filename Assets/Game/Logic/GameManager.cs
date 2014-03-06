using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public GameObject tilePrefab;
	public GameObject pawnPrefab;

	public int boardSize = 8;
	public int maxBoardSize = 20;

	//llenar con piezas en donde corresponda
	public Piece[][] vecBoard;

	public Transform tileContainer;

	private int activePlayerIndex = 0;

	private List<List<Tile>> board = new List<List<Tile>>();
	private List<Player> players = new List<Player>();

	private bool isWhite = true;

	void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		MapSizeLimiter();
		GenerateMap();
		GeneratePieces();
	}

	void Update()
	{
		//Players[activePlayerIndex].TurnUpdate();
	}

	void GenerateMap()//TODO:cambiar a matriz o fijarme para que la puedo usar
	{
		vecBoard = new Piece[boardSize][boardSize];
		board = new List<List<Tile>>();
		for (int i = 0; i < boardSize; i++)
		{
			List<Tile> row = new List<Tile>();
			isWhite = !isWhite;
			for (int j = 0; j < boardSize; j++)
			{
				Tile tile = ((GameObject)Instantiate(tilePrefab,new Vector3(i,j,0),Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				//Tile tile = (Tile)Instantiate(tilePrefab,new Vector3(i,j,0),Quaternion.Euler(new Vector3()));
				tile.gridPosition = new Vector2(i,j);
				tile.transform.parent = tileContainer;

				if(isWhite)
					tile.renderer.material = tile.whiteMaterial;//cambiaRRRRR
				else
					tile.renderer.material = tile.blackMaterial;
				isWhite = !isWhite;
			}
			board.Add (row);
		}
	}

	void MapSizeLimiter()
	{
		if(boardSize > maxBoardSize)
			boardSize = maxBoardSize;
	}

	void GeneratePieces()
	{
		GeneratePawns();
	}

	void GeneratePawns()
	{
		int j = 1;
		for(int i = 0; i < boardSize; i++)
		{
			Pawn pawn = ((GameObject)Instantiate(pawnPrefab, new Vector3(i-0.12f,j,-1),Quaternion.Euler (new Vector3(270,0,0)))).GetComponent<Pawn>();
			pawn.piecePosition = new Vector2 (i,j);
		}
	}

	void NextPlayerTurn()
	{
		if(activePlayerIndex + 1 < players.Count)
			activePlayerIndex++;
		else
			activePlayerIndex = 0;
	}
}
