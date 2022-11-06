using MVCWebApplication.Models;

namespace MVCWebApplication.Services;

public interface IToDoList
{
	void AddItem(ToDoItem item);
	void RemoveItem(int index);
	IEnumerable<ToDoItem> GetItems();
}


public class ToDoList : IToDoList
{

	public ToDoList()
	{
		_items.Add(new ToDoItem() { 
			Description = "Buy a drink"
		});
	}

	private List<ToDoItem> _items = new();

	public void AddItem(ToDoItem item)
	{
		_items.Add(item);
	}

	public IEnumerable<ToDoItem> GetItems()
	{
		for (int i = 0; i < _items.Count; i++)
		{
			yield return _items[i];
		}
	}

	public void RemoveItem(int index)
	{
		_items.RemoveAt(index);
	}

}