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
			//searchPartButton.Click += SearchPartButton_Click;
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
			//searchProductButton.Click += SearchProductButton_Click;
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
			addPartForm.Show();
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
			addProductForm.Show();
		}

		// Create a method that redirects to the Modify Part Form when the Modify Part Button is clicked 
		// this method will pass the ;
		private void ModifyPartButton_Click(object sender, EventArgs e)
		{
			// create modify part form instance and pass the inventory and the selected part
			if(selectedPart != null)
			{
				ModifyPartForm modifyPartForm = new ModifyPartForm(selectedPart, inventory);
				if(modifyPartForm.ShowDialog() == DialogResult.OK)
				{
					// refresh the grid view
					partsGridView.Refresh();
				}
			}
			else
			{
				MessageBox.Show("Please select a part to modify.");
			}
		}

		// Modify Product Button Click
		private void ModifyProductButton_Click(object sender, EventArgs e)
		{
			ModifyProductForm modifyProductForm = new ModifyProductForm();
			modifyProductForm.Show();
		}

		// create a method that delete a part from the grid when the Delete Part Button is clicked
		private void DeletePartButton_Click(object sender, EventArgs e)
		{
			//Logic to delete a part from the grid
			if(partsGridView.SelectedRows.Count > 0)
			{
				int selectdIndex = partsGridView.SelectedRows[0].Index;
				if(selectdIndex != -1)
				{
					// Confirm deletion from the user
					DialogResult confirmResult = MessageBox.Show("Are you sure you want ot delete this part?", "Confirm Delete",
						MessageBoxButtons.YesNo);
					if(confirmResult == DialogResult.Yes)
					{
						Part selectedPart = (Part)partsGridView.Rows[selectdIndex].DataBoundItem;
						inventory.DeletePart(selectedPart);
						// refresh the grid view
						partsGridView.DataSource = null;
						partsGridView.DataSource = inventory.AllParts;
					}
				}
			}
			else
			{
				MessageBox.Show("Please select a part to delete.");
			}

		}


		// Delete Product Button Click
		private void DeleteProductButton_Click(object sender, EventArgs e)
		{
			// Logic to delete a product
		}

		// Exit Button Click
		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion

	}

}
