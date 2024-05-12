using InventoryManagement.Model;
using System;
using System.CodeDom;
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
	public partial class AddPartForm : Form
	{
		private RadioButton inHouseRadioButton, outsourceRadioButton;
		private Button saveButton, cancelButton;
		private TextBox idTextBox, nameTextBox, inventoryTextBox, priceTextBox, maxTextBox, minTextBox, companyOrMachineTextBox;
		private Label idLabel, nameLabel, inventoryLabel, priceLabel, maxLabel, minLabel, titleLabel, companyOrMachineLabel;
		private Inventory inventory;

		// pass the instance of the Inventory Model to the AddPartForm constructor
		public AddPartForm(Inventory inventory)
		{
			InitializeComponents();
			this.inventory = inventory;

		}
		private void InitializeComponents()
		{
			// Form Size
			Text = "Part";
			Size = new System.Drawing.Size(400, 500);

			// Title Label
			titleLabel = new Label();
			titleLabel.Text = "Add Part";
			titleLabel.Location = new System.Drawing.Point(160, 10);
			titleLabel.Size = new System.Drawing.Size(80, 30);
			Controls.Add(titleLabel);

			// In-House Radio Button
			inHouseRadioButton = new RadioButton();
			inHouseRadioButton.Text = "In-House";
			inHouseRadioButton.Location = new System.Drawing.Point(50, 50);
			inHouseRadioButton.Size = new System.Drawing.Size(100, 30);
			inHouseRadioButton.CheckedChanged += InHouseRadioButton_CheckedChanged;
			Controls.Add(inHouseRadioButton);

			// Outsource Radio Button
			outsourceRadioButton = new RadioButton();
			outsourceRadioButton.Text = "Outsourced";
			outsourceRadioButton.Location = new System.Drawing.Point(160, 50);
			outsourceRadioButton.Size = new System.Drawing.Size(100, 30);
			Controls.Add(outsourceRadioButton);

			//Part Details Labels and TextBoxes I am using the CreateLabelAndTextBox method to create the labels and textboxes for the part details
			CreateLabelAndTextBox(out idLabel, out idTextBox, "ID", 80);
			CreateLabelAndTextBox(out nameLabel, out nameTextBox, "Name", 120);
			CreateLabelAndTextBox(out inventoryLabel, out inventoryTextBox, "Inventory", 160);
			CreateLabelAndTextBox(out priceLabel, out priceTextBox, "Price", 200);
			CreateLabelAndTextBox(out maxLabel, out maxTextBox, "Max", 240);
			CreateLabelAndTextBox(out minLabel, out minTextBox, "Min", 280);
			CreateLabelAndTextBox(out companyOrMachineLabel, out companyOrMachineTextBox, "Machine ID", 320);

			// Save Button
			saveButton = new Button();
			saveButton.Text = "Save";
			saveButton.Location = new System.Drawing.Point(100, 400);
			saveButton.Size = new System.Drawing.Size(80, 30);
			saveButton.Click += saveButton_Click;
			Controls.Add(saveButton);

			// Cancel Button
			cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Location = new System.Drawing.Point(220, 400);
			cancelButton.Size = new System.Drawing.Size(80, 30);
			cancelButton.Click += cancelButton_Click;
			Controls.Add(cancelButton);
		}
		// Create Label and TextBox Method for Part Details
		private void CreateLabelAndTextBox(out Label label, out TextBox textbox, string labelText, int posY)
		{
			// Label for Part Details
			label = new Label();
			label.Text = labelText;
			label.Location = new System.Drawing.Point(50, posY);
			label.Size = new System.Drawing.Size(100, 20);
			Controls.Add(label);

			// TextBox for Part Details
			textbox = new TextBox();
			textbox.Location = new System.Drawing.Point(160, posY);
			textbox.Size = new System.Drawing.Size(180, 20);
			Controls.Add(textbox);

		}

		// In-House Radio Button Checked Changed
		private void InHouseRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (inHouseRadioButton.Checked)
			{
				companyOrMachineLabel.Text = "Machine ID";
			}
			else
			{
				companyOrMachineLabel.Text = "Company Name";
			}
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

		// create a method to save the part information to the Inventory Model.AddPart method to store in the binding list
		private void saveButton_Click(object sender, EventArgs e)
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

			// Logic to save the part information
			Part part;
			if (inHouseRadioButton.Checked)
			{
				part = new InHouse();
				((InHouse)part).MachineID = int.Parse(companyOrMachineTextBox.Text);
			}
			else
			{
				part = new Outsourced();
				((Outsourced)part).CompanyName = companyOrMachineTextBox.Text;
			}
			part.PartID = int.Parse(idTextBox.Text);
			part.Name = nameTextBox.Text;
			part.InStock = int.Parse(inventoryTextBox.Text);
			part.Price = decimal.Parse(priceTextBox.Text);
			part.Max = int.Parse(maxTextBox.Text);
			part.Min = int.Parse(minTextBox.Text);

			// Add the part to the Inventory Model with a object reference to the Inventory Model
			inventory.AddPart(part);

			// Redirect to the Main Form
			Close();

		}

		// Cancel Button Click Event
		private void cancelButton_Click(object sender, EventArgs e)
		{
			// Logic to cancel the part information
			Close();
		}
	}
}
