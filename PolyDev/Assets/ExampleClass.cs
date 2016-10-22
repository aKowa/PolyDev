using UnityEngine;

public enum IngredientUnit
{
	Spoon,
	Cup,
	Bowl,
	Piece
}

[System.Serializable]
public class Ingredient
{
	public string name;
	public int amount = 1;
	public IngredientUnit unit;
}

public class ExampleClass : MonoBehaviour
{
	public DerivedClass derivedClass;

	//public Ingredient potionResult;
	//public Ingredient[] potionIngredients;
}
