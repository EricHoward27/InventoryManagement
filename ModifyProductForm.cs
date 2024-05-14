using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
	public partial class ModifyProductForm : Form
	{
		private Button saveButton, cancelButton, addButton, deleteButton, searchButton;
		private TextBox idTextBox, nameTextBox, inventoryTextBox, priceTextBox, maxTextBox, minTextBox, searchTextBox;
		private DataGridView allPartsGridView, associatedPartsGridView;
		private Label idLabel, nameLabel, inventoryLabel, priceLabel, maxLabel, minLabel, titleLabel, allPartsLabel, associatedPartsLabel;
		private Inventory inventory;
		private Product product;

		public ModifyProductForm(Product product, Inventory inventory)
		{
			this.inventory = inventory;

			this.product = product;

			InitializeComponents();

			SetupAllPartsDataViewColumns();

			SetupAssociatedPartsDataViewColumns();

			PopulateFields();

			InitializeAllPartsDataGridView();

			InitializeAssociatedPartsDataGridView();
		}

		private void SetupAllPartsDataViewColumns()
		{
			// All Parts DataGridColumns
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "PartID",
				HeaderText = "Part ID",
				DataPropertyName = "PartID"
			});
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Name",
				HeaderText = "Part Name",
				DataPropertyName = "Name"
			});
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Price",
				HeaderText = "Price",
				DataPropertyName = "Price"
			});
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "InStock",
				HeaderText = "Inventory Level",
				DataPropertyName = "InStock"
			});
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Min",
				HeaderText = "Min",
				DataPropertyName = "Min"
			});
			allPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Max",
				HeaderText = "Max",
				DataPropertyName = "Max"
			});


		}

		// Setup Associated Parts Data View Columns
		private void SetupAssociatedPartsDataViewColumns()
		{
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "PartID",
				HeaderText = "Part ID",
				DataPropertyName = "PartID"
			});
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Name",
				HeaderText = "Part Name",
				DataPropertyName = "Name"
			});
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Price",
				HeaderText = "Price",
				DataPropertyName = "Price"
			});
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "InStock",
				HeaderText = "Inventory Level",
				DataPropertyName = "InStock"
			});
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Min",
				HeaderText = "Min",
				DataPropertyName = "Min"
			});
			associatedPartsGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = "Max",
				HeaderText = "Max",
				DataPropertyName = "Max"
			});
		}

		private void InitializeAllPartsDataGridView()
		{
			allPartsGridView.AutoGenerateColumns = false;

			allPartsGridView.DataSource = inventory.AllParts;

			// selection change event for the all parts grid view
			//allPartsGridView.SelectionChanged += allPartsGridView_SelectionChanged;
		}

		private void InitializeAssociatedPartsDataGridView()
		{
			associatedPartsGridView.AutoGenerateColumns = false;

			associatedPartsGridView.DataSource = product.AssociatedParts;

			// selection change event for the associated parts grid view
			//associatedPartsGridView.SelectionChanged += associatedPartsGridView_SelectionChanged;
		}

		public void InitializeComponents()
		{
			// Product Form Size
			Text = "Product";
			Size = new System.Drawing.Size(1500, 700);

			// Title Label
			titleLabel = new Label();
			titleLabel.Text = "Modify Product";
			titleLabel.Location = new System.Drawing.Point(40, 20);
			titleLabel.Size = new System.Drawing.Size(80, 30);
			Controls.Add(titleLabel);

			// All Parts Label
			allPartsLabel = new Label();
			allPartsLabel.Text = "All candidate Parts";
			allPartsLabel.Location = new System.Drawing.Point(700, 50);
			allPartsLabel.Size = new System.Drawing.Size(150, 30);
			Controls.Add(allPartsLabel);

			// All Parts DataGridView
			allPartsGridView = new DataGridView();
			allPartsGridView.Location = new System.Drawing.Point(700, 80);
			allPartsGridView.Size = new System.Drawing.Size(635, 200);
			Controls.Add(allPartsGridView);

			// Associated Parts Label
			associatedPartsLabel = new Label();
			associatedPartsLabel.Text = "Associated Parts";
			associatedPartsLabel.Location = new System.Drawing.Point(700, 300);
			associatedPartsLabel.Size = new System.Drawing.Size(150, 30);
			Controls.Add(associatedPartsLabel);

			// Associated Parts DataGridView
			associatedPartsGridView = new DataGridView();
			associatedPartsGridView.Location = new System.Drawing.Point(700, 330);
			associatedPartsGridView.Size = new System.Drawing.Size(635, 200);
			Controls.Add(associatedPartsGridView);

			// Associate Parts Search Box
			searchTextBox = new TextBox();
			searchTextBox.Location = new System.Drawing.Point(1180, 50);
			searchTextBox.Size = new System.Drawing.Size(150, 75);
			Controls.Add(searchTextBox);

			// Search Button
			searchButton = new Button();
			searchButton.Text = "Search";
			searchButton.Location = new System.Drawing.Point(1100, 50);
			searchButton.Size = new System.Drawing.Size(75, 25);
			searchButton.Click += searchButton_Click;
			Controls.Add(searchButton);

			// Add Button
			addButton = new Button();
			addButton.Text = "Add";
			addButton.Location = new System.Drawing.Point(1225, 290);
			addButton.Size = new System.Drawing.Size(80, 35);
			addButton.Click += addButton_Click;
			Controls.Add(addButton);

			// Delete Button
			deleteButton = new Button();
			deleteButton.Text = "Delete";
			deleteButton.Location = new System.Drawing.Point(1225, 550);
			deleteButton.Size = new System.Drawing.Size(80, 35);
			deleteButton.Click += deleteButton_Click;
			Controls.Add(deleteButton);

			// Cancel Button
			cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Location = new System.Drawing.Point(1225, 600);
			cancelButton.Size = new System.Drawing.Size(80, 35);
			cancelButton.Click += cancelButton_Click;
			Controls.Add(cancelButton);

			// Save Button
			saveButton = new Button();
			saveButton.Text = "Save";
			saveButton.Location = new System.Drawing.Point(1135, 600);
			saveButton.Size = new System.Drawing.Size(80, 35);
			saveButton.Click += saveButton_Click;
			Controls.Add(saveButton);

			// Product Details Labels and TextBoxes
			CreateLabelAndTextBox(out idLabel, out idTextBox, "ID", 80);
			idTextBox.Enabled = false;
			idTextBox.ReadOnly = true;
			CreateLabelAndTextBox(out nameLabel, out nameTextBox, "Name", 120);
			CreateLabelAndTextBox(out inventoryLabel, out inventoryTextBox, "Inventory", 160);
			CreateLabelAndTextBox(out priceLabel, out priceTextBox, "Price", 200);
			CreateLabelAndTextBox(out maxLabel, out maxTextBox, "Max", 240);
			CreateLabelAndTextBox(out minLabel, out minTextBox, "Min", 280);
		}

		// Event Handlers
		private void CreateLabelAndTextBox(out Label label, out TextBox textBox, string labelText, int posY)
		{
			// Label for Product Details
			label = new Label();
			label.Text = labelText;
			label.Location = new System.Drawing.Point(40, posY);
			label.Size = new System.Drawing.Size(100, 20);
			Controls.Add(label);

			// TextBox for Product Details
			textBox = new TextBox();
			textBox.Location = new System.Drawing.Point(160, posY);
			textBox.Size = new System.Drawing.Size(180, 20);
			Controls.Add(textBox);
		}

		// Populate Fields
		private void PopulateFields()
		{
			// populate the product details
			idTextBox.Text = product.ProductID.ToString();
			nameTextBox.Text = product.Name;
			inventoryTextBox.Text = product.InStock.ToString();
			priceTextBox.Text = product.Price.ToString();
			maxTextBox.Text = product.Max.ToString();
			minTextBox.Text = product.Min.ToString();
		}

		// validation methods to handle user input errors
		private bool IsNumericValid(string input, out int result)
		{
			return int.TryParse(input, out result);
		}

		private bool IsDecimalValid(string input, out decimal result)
		{
			return decimal.TryParse(input, out result);
		}



		// save button click event
		private void saveButton_Click(object sender, EventArgs e	)
		{
			int inStock, min, max;
			decimal price;

			// validate if the user input is a valid numeric value for each text box field that requires it
			if (!IsNumericValid(inventoryTextBox.Text, out inStock) || !IsDecimalValid(priceTextBox.Text, out price) ||
				!IsNumericValid(minTextBox.Text, out min) || !IsNumericValid(maxTextBox.Text, out max))
			{
				MessageBox.Show("Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (min > max)
			{
				MessageBox.Show("Minimum value cannot be greater than the maximum value.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (inStock < min || inStock > max)
			{
				MessageBox.Show("Inventory value must be within the minimum and maximum range.", "Invalid Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				// pass the product details to the product object
				product.Name = nameTextBox.Text;
				product.InStock = int.Parse(inventoryTextBox.Text);
				product.Price = decimal.Parse(priceTextBox.Text);
				product.Max = int.Parse(maxTextBox.Text);
				product.Min = int.Parse(minTextBox.Text);

				// update the product in the inventory
				inventory.UpdateProduct(product.ProductID, product);

				// close the modify product form
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// add button click event
		private void addButton_Click(object sender, EventArgs e)
		{
			if(allPartsGridView.SelectedRows.Count > 0)
			{
				// get the selected part
				Part selectedPart = (Part)allPartsGridView.SelectedRows[0].DataBoundItem;

				// add the selected part to the product
				product.AddAssociatedPart(selectedPart);

				// refresh the associated parts grid view
				associatedPartsGridView.DataSource = null;

				associatedPartsGridView.DataSource = product.AssociatedParts;
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			if(associatedPartsGridView.SelectedRows.Count > 0)
			{
				// get the selected part
				Part selectedPart = (Part)associatedPartsGridView.SelectedRows[0].DataBoundItem;

				// remove the selected part from the product
				product.RemoveAssociatedPart(selectedPart.PartID);

				// refresh the associated parts grid view
				associatedPartsGridView.DataSource = null;

				associatedPartsGridView.DataSource = product.AssociatedParts;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Search Button Click Event
		private void searchButton_Click(object sender, EventArgs e)
		{
			string searchText = searchTextBox.Text.ToLower();
			var foundParts = inventory.SearchAssociatedPart(searchText, product.AssociatedParts);
			associatedPartsGridView.DataSource = foundParts;

			// highlight the matching row
			foreach (DataGridViewRow row in associatedPartsGridView.Rows)
			{
				if (row.Cells["Name"].Value.ToString().ToLower().Contains(searchText))
				{
					// select the matching row
					allPartsGridView.Rows[row.Index].Selected = true;

					row.DefaultCellStyle.BackColor = Color.Yellow;
				}
				else
				{
					row.DefaultCellStyle.BackColor = Color.White;
				}
			}
			if (foundParts.Count == 0)
			{
				MessageBox.Show("No associated parts found matching the search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}
	}
}
