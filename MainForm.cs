using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagement.Model;

namespace InventoryManagement
{
	public partial class MainForm : Form
	{
		private Button addPartButton, modifyPartButton, deletePartButton, searchPartButton, addProductButton, modifyProductButton, deleteProductButton, searchProductButton, exitButton;
		private ListBox partsList, productList;
		private DataGridView partsGridView, productsGridView;
		private TextBox searchPartsBox, searchProductsBox;
		private Label partsLabel, productsLabel, titleLabel, formLabel;
		private Part selectedPart;
		private Inventory inventory = new Inventory();
		private Product newProduct = new Product();
		public MainForm()
		{
			InitializeComponents();
			// this method call setup datagridview manually when autogeneratecolumns is set to false
			PartsDataGridViewColumns();
			// this method call setup datagridview manually when autogeneratecolumns is set to false
			ProductsDataGridViewColumns();
			/// this method is to initialize the data and create instances
			InitializePartsDataGridView();
			// this method is to initialize the data and create instances for products
			InitializeProductsDataGridView();
		}
		#region Initialize Data
		private void InitializePartsDataGridView()
		{
			// automatic column generation
			partsGridView.AutoGenerateColumns = false;

			// bind the grid view data source to the binding list of parts
			partsGridView.DataSource = inventory.AllParts;

			// the selectionchange event will be triggered when the user selects a row in the grid
			partsGridView.SelectionChanged += PartsGridView_SelectionChanged;

		}
		private void InitializeProductsDataGridView()
		{
			// automatic column generation
			productsGridView.AutoGenerateColumns = false;

			// bind the grid view data source to the binding list of products
			productsGridView.DataSource = inventory.Products;

			// disable the default row
			productsGridView.AllowUserToAddRows = false;

			// the selectionchange event will be triggered when the user selects a row in the grid
			productsGridView.SelectionChanged += ProductsGridView_SelectionChanged;
		}
		#endregion

		#region Setup Data Grid View Columns
		private void PartsDataGridViewColumns()
		{
			// Part Columns
			// manually setup the columns if autogeneratecolumns is set to false
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "PartID",
				DataPropertyName = "PartID",
				HeaderText = "ID"
			});
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Name",
				DataPropertyName = "Name",
				HeaderText = "Name"
			});
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Price",
				DataPropertyName = "Price",
				HeaderText = "Price"
			});
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "InStock",
				DataPropertyName = "InStock",
				HeaderText = "In Stock"
			});
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Min",
				DataPropertyName = "Min",
				HeaderText = "Min"
			});
			partsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Max",
				DataPropertyName = "Max",
				HeaderText = "Max"
			});

			

		}
		private void ProductsDataGridViewColumns()
		{
			// Product Columns
			// manually setup the columns if autogeneratecolumns is set to false
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "ProductID",
				DataPropertyName = "ProductID",
				HeaderText = "ID"
			});
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Name",
				DataPropertyName = "Name",
				HeaderText = "Name"
			});
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Price",
				DataPropertyName = "Price",
				HeaderText = "Price"
			});
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "InStock",
				DataPropertyName = "InStock",
				HeaderText = "In Stock"
			});
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Min",
				DataPropertyName = "Min",
				HeaderText = "Min"
			});
			productsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Max",
				DataPropertyName = "Max",
				HeaderText = "Max"
			});
		}
		#endregion
		private void InitializeComponents()
		{
			#region Main Form Section
			// Form Size
			Text = "Main";
			Size = new System.Drawing.Size(1500, 600);
			// Form Title
			formLabel = new Label();
			formLabel.Text = "Inventory Management System";
			formLabel.Location = new System.Drawing.Point(40, 20);
			formLabel.Size = new System.Drawing.Size(200, 20);
			Controls.Add(formLabel);
			

			// Title Label
			titleLabel = new Label();
			titleLabel.Text = "Inventory Management System";
			titleLabel.Location = new System.Drawing.Point(300, 10);
			titleLabel.Size = new System.Drawing.Size(200, 20);
			#endregion

			#region Parts Grid View Section
			// Parts label
			partsLabel = new Label();
			partsLabel.Text = "Parts";
			partsLabel.Location = new System.Drawing.Point(50, 50);
			partsLabel.Size = new System.Drawing.Size(100, 20);
			Controls.Add(partsLabel);

			//Parts Grid View
			partsGridView = new DataGridView();
			partsGridView.Location = new System.Drawing.Point(50, 80);
			partsGridView.Size = new System.Drawing.Size(635, 300);
			partsGridView.AutoGenerateColumns = false;
			Controls.Add(partsGridView);

			// Search Parts Box
			searchPartsBox = new TextBox();
			searchPartsBox.Location = new System.Drawing.Point(535, 50);
			searchPartsBox.Size = new System.Drawing.Size(150, 75);
			Controls.Add(searchPartsBox);


			// Add Part Button
			addPartButton = new Button();
			addPartButton.Text = "Add";
			addPartButton.Location = new System.Drawing.Point(500, 380);
			addPartButton.Size = new System.Drawing.Size(55, 25);
			addPartButton.Click += AddPartButton_Click;
			Controls.Add(addPartButton);


			// Modify Part Button
			modifyPartButton = new Button();
			modifyPartButton.Text = "Modify";
			modifyPartButton.Location = new System.Drawing.Point(565, 380);
			modifyPartButton.Size = new System.Drawing.Size(55, 25);
			modifyPartButton.Click += ModifyPartButton_Click;
			Controls.Add(modifyPartButton);

			// Delete Part Button
			deletePartButton = new Button();
			deletePartButton.Text = "Delete";
			deletePartButton.Location = new System.Drawing.Point(630, 380);
			deletePartButton.Size = new System.Drawing.Size(55, 25);
			deletePartButton.Click += DeletePartButton_Click;
			Controls.Add(deletePartButton);

			


			// Search Part Button
			searchPartButton = new Button();
			searchPartButton.Text = "Search";
			searchPartButton.Location = new System.Drawing.Point(455, 50);
			searchPartButton.Size = new System.Drawing.Size(75, 25);
			searchPartButton.Click += searchPartButton_Click;
			Controls.Add(searchPartButton);
			#endregion

			#region Products Grid View Section

			// Products label
			productsLabel = new Label();
			productsLabel.Text = "Products";
			productsLabel.Location = new System.Drawing.Point(700, 50);
			productsLabel.Size = new System.Drawing.Size(100, 20);
			Controls.Add(productsLabel);

			//Products Grid View
			productsGridView = new DataGridView();
			productsGridView.Location = new System.Drawing.Point(700, 80);
			productsGridView.Size = new System.Drawing.Size(635, 300);
			productsGridView.AutoGenerateColumns = false;
			Controls.Add(productsGridView);

			// Search Products Box
			searchProductsBox = new TextBox();
			searchProductsBox.Location = new System.Drawing.Point(1180, 50);
			searchProductsBox.Size = new System.Drawing.Size(150, 75);
			Controls.Add(searchProductsBox);

			// Add Product Button
			addProductButton = new Button();
			addProductButton.Text = "Add";
			addProductButton.Location = new System.Drawing.Point(1150, 380);
			addProductButton.Size = new System.Drawing.Size(55, 25);
			addProductButton.Click += AddProductButton_Click;
			Controls.Add(addProductButton);

			// Modify Product Button
			modifyProductButton = new Button();
			modifyProductButton.Text = "Modify";
			modifyProductButton.Location = new System.Drawing.Point(1215, 380);
			modifyProductButton.Size = new System.Drawing.Size(55, 25);
			modifyProductButton.Click += ModifyProductButton_Click;
			Controls.Add(modifyProductButton);

			// Delete Product Button
			deleteProductButton = new Button();
			deleteProductButton.Text = "Delete";
			deleteProductButton.Location = new System.Drawing.Point(1280, 380);
			deleteProductButton.Size = new System.Drawing.Size(55, 25);
			deleteProductButton.Click += DeleteProductButton_Click;
			Controls.Add(deleteProductButton);

			// Search Product Button
			searchProductButton = new Button();
			searchProductButton.Text = "Search";
			searchProductButton.Location = new System.Drawing.Point(1100, 50);
			searchProductButton.Size = new System.Drawing.Size(75, 25);
			searchProductButton.Click += searchProductButton_Click;
			Controls.Add(searchProductButton);
			#endregion

			// Exit Button right bottom corner
			exitButton = new Button();
			exitButton.Text = "Exit";
			exitButton.Location = new System.Drawing.Point(1300, 500);
			exitButton.Size = new System.Drawing.Size(75, 25);
			exitButton.Click += ExitButton_Click;
			Controls.Add(exitButton);
		}
		#region Event Handlers
		// event handler for the selection change event of the grid view
		private void PartsGridView_SelectionChanged(object sender, EventArgs e)
		{
			if(partsGridView.SelectedRows.Count > 0)
			{
				int partId = Convert.ToInt32(partsGridView.SelectedRows[0].Cells["PartID"].Value);
				selectedPart = inventory.AllParts.FirstOrDefault(p => p.PartID == partId);
			}
		}

		// event handler for the selection change event of the grid view
		private void ProductsGridView_SelectionChanged(object sender, EventArgs e)
		{
			// Logic to select a product
			if(productsGridView.SelectedRows.Count > 0)
			{
				int productId = Convert.ToInt32(productsGridView.SelectedRows[0].Cells["ProductID"].Value);
				newProduct = inventory.Products.FirstOrDefault(p => p.ProductID == productId);
			}
		}

		// I created a instance of the Inventory class in the model to pass it over to the AddPartForm constructor
		// so essentially user will click add part button which will open the addpartform, user enter details and click save
		// the save button will handle the new part object the addpartform method addparttoinventory will add the part to the inventory
		private void AddPartButton_Click(object sender, EventArgs e)
		{
			AddPartForm addPartForm = new AddPartForm(inventory);
			if(addPartForm.ShowDialog() == DialogResult.OK)
			{
				// refresh the parts grid view to show the newly added part
				partsGridView.DataSource = null;
				partsGridView.DataSource = inventory.AllParts;
			}
		}

		// This method is used to add the new part to the inventory class in the model(Inventory.AddPart) AddPart method 
		// will store the part in the binding list AllParts
		public void AddPartToInventory(Part part)
		{
			inventory.AddPart(part);

		}
		// Add Product Button Click
		private void AddProductButton_Click(object sender, EventArgs e)
		{
			AddProductForm addProductForm = new AddProductForm(newProduct, inventory);
			if(addProductForm.ShowDialog() == DialogResult.OK)
			{
				// refresh the products grid view to show the newly added product
				productsGridView.DataSource = null;
				productsGridView.DataSource = inventory.Products;
			}
		}

		// Create a method that redirects to the Modify Part Form when the Modify Part Button is clicked 
		private void ModifyPartButton_Click(object sender, EventArgs e)
		{
			if (partsGridView.SelectedRows.Count > 0)
			{
				// retrieve the selected part
				Part selectedPart = (Part)partsGridView.SelectedRows[0].DataBoundItem;
				// create modify part form instance and pass the inventory and the selected part
				if (selectedPart != null)
				{
					ModifyPartForm modifyPartForm = new ModifyPartForm(selectedPart, inventory);
					if (modifyPartForm.ShowDialog() == DialogResult.OK)
					{
						// refresh the parts grid view to show the modified part
						partsGridView.DataSource = null;
						partsGridView.DataSource = inventory.AllParts;
					}
				}
				else
				{
					MessageBox.Show("Please select a part to modify.", "No Part Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		// Modify Product Button Click
		private void ModifyProductButton_Click(object sender, EventArgs e)
		{
			
			if(productsGridView.SelectedRows.Count > 0)
			{
				if(productsGridView.SelectedRows.Count > 0)
				{
					Product selectedProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;
					if(selectedProduct != null)
					{
						ModifyProductForm modifyProductForm = new ModifyProductForm(selectedProduct, inventory);
						if (modifyProductForm.ShowDialog() == DialogResult.OK)
						{
							// refresh the products grid view to show the modified product
							productsGridView.DataSource = null;
							productsGridView.DataSource = inventory.Products;
						}
					}
						
				}
				else
				{
					MessageBox.Show("Please select a product to modify.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
				
				
			
		}

		// create a method that delete a part from the grid when the Delete Part Button is clicked
		private void DeletePartButton_Click(object sender, EventArgs e)
		{
			if(partsGridView.SelectedRows.Count > 0)
			{
				Part selectedPart = (Part)partsGridView.SelectedRows[0].DataBoundItem;
				if(selectedPart != null)
				{
					// check if the part is associated with a product
					foreach(Product product in inventory.Products)
					{
						if(product.AssociatedParts.Contains(selectedPart))
						{
							MessageBox.Show("Cannot delete part because it is associated with a product.", "Deletion Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					// Confirm deletion from the user
					DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this part?", "Confirm Delete",
											MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (confirmResult == DialogResult.Yes)
					{
						inventory.DeletePart(selectedPart);
						// refresh the parts grid view to reflect the deletion
						partsGridView.DataSource = null;
						partsGridView.DataSource = inventory.AllParts;
					}
				}
				
			}
			else
			{
				MessageBox.Show("Please select a part to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}


		// Delete Product Button Click
		private void DeleteProductButton_Click(object sender, EventArgs e)
		{
			// Logic to delete a product
			if(productsGridView.SelectedRows.Count > 0)
			{
				// retrieve the selected product
				Product selectedProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;
				if(selectedProduct != null)
				{
					// Confirm deletion from the user
					DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (confirmResult == DialogResult.Yes)
					{
						inventory.RemoveProduct(selectedProduct.ProductID);
						//reresh the products grid view to reflect the deletion
						productsGridView.DataSource = null;
						productsGridView.DataSource = inventory.Products;
					}
				}
			}
			else
			{
				MessageBox.Show("Please select a product to delete.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Exit Button Click
		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Search Part Button Click event
		private void searchPartButton_Click(object sender, EventArgs e)
		{
			string searchText = searchPartsBox.Text;
			var foundParts = inventory.SearchPart(searchText);
			partsGridView.DataSource = foundParts;

			// display a matching row and highlight it
			foreach(DataGridViewRow row in partsGridView.Rows)
			{
				if (row.Cells["Name"].Value.ToString().ToLower().Contains(searchText))
				{
					// select the row
					partsGridView.Rows[row.Index].Selected = true;

					row.DefaultCellStyle.BackColor = Color.Cyan;


				}
				else
				{
					row.DefaultCellStyle.BackColor = Color.White;
				}
			}

			if (foundParts.Count == 0)
			{
				MessageBox.Show("No parts found matching the search criteria.", "Search Result",
										MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Search Product Button Click event
		private void searchProductButton_Click(object sender, EventArgs e)
		{
			string searchText = searchProductsBox.Text;
			var foundProducts = inventory.SearchProduct(searchText);
			productsGridView.DataSource = foundProducts;

			// display a matching row and highlight it
			foreach (DataGridViewRow row in productsGridView.Rows)
			{
				if (row.Cells["Name"].Value.ToString().ToLower().Contains(searchText))
				{
					// select the row
					productsGridView.Rows[row.Index].Selected = true;

					// change the background color of the row that matches the search criteria
					row.DefaultCellStyle.BackColor = Color.Cyan;
				}
				else
				{
					row.DefaultCellStyle.BackColor = Color.White;
				}
			}

			if (foundProducts.Count == 0)
			{
				MessageBox.Show("No products found matching the search criteria.", "Search Result",
										MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		#endregion

	}

}
