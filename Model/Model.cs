using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace InventoryManagement.Model
{
	public abstract class Part
	{
		// this is the part properties model
		public int PartID { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int InStock { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }

	}

	public class InHouse : Part
	{
		public int MachineID { get; set; }
	}

	public class Outsourced : Part
	{
		public string CompanyName { get; set; }
	}

	public class Product
	{
		// this is the product properties 
		public int ProductID { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int InStock { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }
		
		// this is the binding list created for the parts that will store the save parts
		public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();

		public void AddAssociatedPart(Part part)
		{
			AssociatedParts.Add(part);
		}

		// this method will remove the part by finding its parts id 
		public bool RemoveAssociatedPart(int partID)
		{
			var part = AssociatedParts.FirstOrDefault(p => p.PartID == partID);
			if (part != null)
			{
				AssociatedParts.Remove(part);
				return true;
			}
			return false;
		}

		// this method uses the part id to look up the part 
		public Part LookupAssociatePart(int partID)
		{
			return AssociatedParts.FirstOrDefault(p => p.PartID == partID);
		}
	}

	public class Inventory
	{
		public BindingList<Product> Products { get; set; } = new BindingList<Product>();
		public BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

		// auto increment the part id
		public int GetNextPartID()
		{
			return AllParts.Any() ? AllParts.Max(part => part.PartID) + 1 : 1;
		}

		// auto increment the product id
		public int GetNextProductID()
		{
			return Products.Any() ? Products.Max(product => product.ProductID) + 1 : 1;
		}

		// this method is to search for part by name in the binding list
		public List<Part> SearchPart(string searchString)
		{
			return AllParts.Where(part => part.Name.ToLower().Contains(searchString.ToLower())).ToList();
		}

		// this method is to search for product by name in the binding list
		public List<Product> SearchProduct(string searchString)
		{
			return Products.Where(product => product.Name.ToLower().Contains(searchString.ToLower())).ToList();
		}

		// this method is to search for associated part by name in the binding list
		public List<Part> SearchAssociatedPart(string searchString, BindingList<Part> associatedParts)
		{
			return associatedParts.Where(part => part.Name.ToLower().Contains(searchString.ToLower())).ToList();
		}
		public void AddProduct(Product product)
		{
			Products.Add(product);
		}

		public bool RemoveProduct(int productID)
		{
			var product = Products.FirstOrDefault(p => p.ProductID == productID);
			if (product != null)
			{
				Products.Remove(product);
				return true;
			}
			return false;
		}

		public Product LookupProduct(int productID)
		{
			return Products.FirstOrDefault(p => p.ProductID == productID);
		}
		
		// this method uses the productid to find the product, the updatedProduct param is the updated product data that will save if the product is found
		public void UpdateProduct(int productID, Product updatedProduct)
		{
			var product = Products.FirstOrDefault(p => p.ProductID == productID);
			if (product != null)
			{
				int index = Products.IndexOf(product);
				Products[index] = updatedProduct;
			}
		}
		// after the add part form is save the data will be store here for reference
		public void AddPart(Part part)
		{
			AllParts.Add(part);
		}

		// if user click the delete button for the part is true, this method removes the part from the binding list
		public bool DeletePart(Part part)
		{
			return AllParts.Remove(part);
		}

		// this method is to search for part by id
		public Part LookupPart(int partID)
		{
			return AllParts.FirstOrDefault(p => p.PartID == partID);
		}
		// this method uses the partid to find the part, the updatedPart param is the updated part data that will save if the part is found

		public void UpdatePart(int partID, Part updatedPart)
		{
			var part = AllParts.FirstOrDefault(p =>p.PartID == partID);
			if(part != null)
			{
				int index = AllParts.IndexOf(part);
				AllParts[index] = updatedPart;
			}
		}
	}

}
