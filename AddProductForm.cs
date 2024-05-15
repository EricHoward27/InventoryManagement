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
	public partial class AddProductForm : Form
	{
		private Button saveButton, cancelButton, addButton, deleteButton, searchButton;
		private TextBox idTextBox, nameTextBox, inventoryTextBox, priceTextBox, maxTextBox, minTextBox, searchTextBox;
		private DataGridView allPartsGridView, associatedPartsGridView;
		private Label idLabel, nameLabel, inventoryLabel, priceLabel, maxLabel, minLabel, titleLabel, allPartsLabel, associatedPartsLabel;
		private Inventory inventory;
		private Product product;
		private ToolTip tooltip;
		public AddProductForm(Product product, Inventory inventory)
		{
			this.product = product;

			this.inventory = inventory;

			InitializeComponents();

			SetupAllPartsDataViewColumns();

			SetupAssociatedPartsDataViewColumns();

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

		private void InitializeComponents()
		{
			// Product Form Size
			Text = "Product";
			Size = new System.Drawing.Size(1500, 700);

			// Title Label
			titleLabel = new Label();
			titleLabel.Text = "Add Product";
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
			// init tooltip component
			tooltip = new ToolTip();
			CreateLabelAndTextBox(out idLabel, out idTextBox, "ID", 80);
			idTextBox.Text = inventory.GetNextPartID().ToString();
			idTextBox.Enabled = false;
			CreateLabelAndTextBox(out nameLabel, out nameTextBox, "Name", 120);
			SetRequiredField(nameTextBox, "Enter the name of the product.");
			CreateLabelAndTextBox(out inventoryLabel, out inventoryTextBox, "Inventory", 160);
			SetRequiredField(inventoryTextBox, "Enter the inventory count, must be a number.");
			CreateLabelAndTextBox(out priceLabel, out priceTextBox, "Price", 200);
			SetRequiredField(priceTextBox, "Enter the price, must be a numeric value.");
			CreateLabelAndTextBox(out maxLabel, out maxTextBox, "Max", 240);
			SetRequiredField(maxTextBox, "Enter the maximum inventory level.");
			CreateLabelAndTextBox(out minLabel, out minTextBox, "Min", 280);
			SetRequiredField(minTextBox, "Enter the minimum inventory level.");

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

		// helper methods to config required fields
		private void SetRequiredField(TextBox textBox, string tooltipText)
		{
			// set the background color to red to indicate a required field
			textBox.BackColor = Color.LightYellow;

			// set the tooltip for the required field
			tooltip.SetToolTip(textBox, tooltipText);
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

		private void saveButton_Click(object sender, EventArgs e)
		{
			int inStock, min, max;
			decimal price;

			// validate if the user input is a valid numeric value for each text box field that requires it
			if (!IsNumericValid(inventoryTextBox.Text, out inStock) || !IsDecimalValid(priceTextBox.Text, out price) ||
				! IsNumericValid(minTextBox.Text, out min) || !IsNumericValid(maxTextBox.Text, out max))
			{
				MessageBox.Show("Please enter valid numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if(min > max)
			{
				MessageBox.Show("Minimum value cannot be greater than the maximum value.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if(inStock < min || inStock > max)
			{
				MessageBox.Show("Inventory value must be within the minimum and maximum range.", "Invalid Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// validate that the product has at least one associated part'
			if (product.AssociatedParts.Count == 0)
			{
				MessageBox.Show("Please add at least one associated part to the product.", "No Associated Parts", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			// Save the product information to the Inventory Model.AddProduct method to store in the binding list
			try
			{
				// create new product instance and set the properties from the form
				Product newProduct = new Product
				{
					ProductID = int.Parse(idTextBox.Text),
					Name = nameTextBox.Text,
					Price = decimal.Parse(priceTextBox.Text),
					InStock = int.Parse(inventoryTextBox.Text),
					Min = int.Parse(minTextBox.Text),
					Max = int.Parse(maxTextBox.Text)
				};
				// add each associated part from the associated parts grid view to the new product
				foreach (DataGridViewRow row in associatedPartsGridView.Rows)
				{
					var part = (Part)row.DataBoundItem;
					newProduct.AddAssociatedPart(part);
				}
				// add the new product to the inventory
				inventory.AddProduct(newProduct);
				// close the form
				this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		// Cancel Button Click Event
		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Add Button Click Event
		private void addButton_Click(object sender, EventArgs e)
		{
			// retrieve the selected part from the all parts grid view
			if(allPartsGridView.SelectedRows.Count > 0)
			{
				Part selectedPart = (Part)allPartsGridView.SelectedRows[0].DataBoundItem;

				// add the selected part to the associated parts grid view
				product.AddAssociatedPart(selectedPart);

				// refresh the associated parts grid view to show the newly added part
				associatedPartsGridView.DataSource = null;
				associatedPartsGridView.DataSource = product.AssociatedParts;
			}
			else
			{
				MessageBox.Show("Please select a part to add.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Delete Button Click Event
		private void deleteButton_Click(object sender, EventArgs e)
		{
			if(associatedPartsGridView.SelectedRows.Count > 0)
			{
				// retrieve the selected part from the associated parts grid view
				Part selectedPart = (Part)associatedPartsGridView.SelectedRows[0].DataBoundItem;

				// confirm deletion from the user
				DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this part?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (confirmResult == DialogResult.Yes)
				{
					// remove the selected part from the associated parts grid view
					product.RemoveAssociatedPart(selectedPart.PartID);
				}

				// refresh the associated parts grid view to show the newly removed part
				associatedPartsGridView.DataSource = null;
				associatedPartsGridView.DataSource = product.AssociatedParts;
			}
			else
			{
				MessageBox.Show("Please select a part to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		// Search Button Click Event
		private void searchButton_Click(object sender, EventArgs e)
		{
			string searchText = searchTextBox.Text.ToLower();
			var foundParts = inventory.SearchAssociatedPart(searchText, product.AssociatedParts);
			associatedPartsGridView.DataSource = foundParts;

			// highlight the matching row
			foreach(DataGridViewRow row in associatedPartsGridView.Rows)
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
