using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour 
{
	public enum pieceTypes {pawn, bishop, knight, rook, queen, king}

	public Vector2 piecePosition = Vector2.zero;

	private Color lastColor;
	
	private bool isSelected = false;

	private Tile pieceTile;

	/*protected virtual void OnMouseDown()
	{
		//pieceTile.gridPosition
		isSelected = !isSelected;
		ChangeTileView(isSelected,pieceTile);
	}

	void ChangeTileView(bool status, Tile currentTile)
	{
		if(status)
		{
			lastColor = currentTile.transform.renderer.material.color;
			currentTile.transform.renderer.material.color = Color.blue;
		}
		else
			currentTile.transform.renderer.material.color = lastColor;
	}*/
}
