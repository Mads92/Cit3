using System;
using System.Collections.Generic;
namespace Assignment3;
  
public class Category 
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Category(int cid, string name)
	{
		this.Id = cid;
		this.Name = name;
	}
}

public class CategoryService
{
	List<Category> categories;

	public List<Category> GetCategories()
	{
		return categories;
	}
	public Category? GetCategory(int cid)
	{
		return categories.Find(c => c.Id == cid);
	}

	
    public bool UpdateCategory(int id, string newName)
	{
		if (!categories.Contains(GetCategory(id)))
		{
			return false;
		}
		else
		{
			GetCategory(id).Name = newName;
			return true;
		}
	}
	public bool DeleteCategory(int id) 
	{
		if (!categories.Contains(GetCategory(id))){
			return false;
		}
		else
		{
            categories.Remove(GetCategory(id));
			return true;
        }
	}

    public bool CreateCategory(int id, string name)
	{
		if (categories.Contains(GetCategory(id))){
			return false;
		}
		else
		{
			Category c = new Category(id, name);
			categories.Add(c);
			return true;
		}
	}

    public CategoryService()
	{
		//Create a new list of Category objects
		categories = new List<Category>();

		//Insert the given categories from the assignment description
		Category beverages = new Category(1, "Beverages");
		Category condiments = new Category(2, "Condiments");
		Category confections = new Category(3, "Confections");
		
		categories.Add(beverages);
		categories.Add(condiments);
		categories.Add(confections);

	}
	
}