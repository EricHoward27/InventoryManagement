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
	public partial class ModifyPartForm : Form
	{
		private RadioButton inHouseRadioButton, outsourcedRadioButton;
		private Button saveButton, cancelButton;
		private TextBox idTextBox, nameTextBox, inventoryTextBox, priceTextBox, maxTextBox, minTextBox, companyOrMachineTextBox;
		private Label idLabel, nameLabel, inventoryLabel, priceLabel, maxLabel, minLabel, titleLabel, companyOrMachineLabel;
		private Part currentPart;
		private Inventory inventory;
		public ModifyPartForm(Part part,Inventory inventory)
		{
			currentPart = part;
			this.inventory = inventory;
			InitializeComponents();
			PopulateFormData(part);
		}
		
		private void InitializeComponents()
		{
			// Form title and size
			Text = "Modify Part";
			Size = new System.Drawing.Size(400, 500);

			// Title Label
			titleLabel = new Label();
			titleLabel.Text = "Modify Part";
			titleLabel.Location = new System.Drawing.Point(160, 10);
			titleLabel.Size = new System.Drawing.Size(100, 30);
			Controls.Add(titleLabel);

			// In House Radio Button
			inHouseRadioButton = new RadioButton();
			inHouseRadioButton.Text = "In-House";
			inHouseRadioButton.Location = new System.Drawing.Point(50, 50);
			inHouseRadioButton.Size = new System.Drawing.Size(100, 30);
			inHouseRadioButton.CheckedChanged += PartTypeRadioButton_CheckedChanged;
			Controls.Add(inHouseRadioButton);

			// OutSource Radio Button
			outsourcedRadioButton = new RadioButton();
			outsourcedRadioButton.Text = "OutSourced";
			outsourcedRadioButton.Location = new System.Drawing.Point(160, 50);
			outsourcedRadioButton.Size = new System.Drawing.Size(100, 30);
			Controls.Add(outsourcedRadioButton);

			// Labels and text boxes for part details
			CreateLabelAndTextBox(out idLabel, out idTextBox, "ID", 80);
			idTextBox.Enabled = false;
			idTextBox.ReadOnly = true;
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
			saveButton.Click += SaveButton_Click;
			Controls.Add(saveButton);

			// Cancel Button
			cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Location = new System.Drawing.Point(220, 400);
			cancelButton.Size = new System.Drawing.Size(80, 30);
			cancelButton.Click += CancelButton_Click;
			Controls.Add(cancelButton);
		}

		private void CreateLabelAndTextBox(out Label label, out TextBox textBox, string labelText, int posY)
		{
			label = new Label();
			label.Text = labelText;
			label.Location = new System.Drawing.Point(50, posY);
			label.Size = new System.Drawing.Size(100, 20);
			Controls.Add(label);

			textBox = new TextBox();
			textBox.Location = new System.Drawing.Point(160, posY);
			textBox.Size = new System.Drawing.Size(180, 20);
			// this will set the id field to disable so we can make modifications
			textBox.Enabled = true;
			textBox.ReadOnly = false;
			Controls.Add(textBox);
		}

		// change the state for radio button click event 
		private void PartTypeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			companyOrMachineLabel.Text = inHouseRadioButton.Checked ? "Machine ID" : "Company Name";
		}

		private void PopulateFormData(Part part)
		{
			// this method will populate the save data from add form
			idTextBox.Text = part.PartID.ToString();
			nameTextBox.Text = part.Name;
			inventoryTextBox.Text = part.InStock.ToString();
			priceTextBox.Text = part.Price.ToString();
			maxTextBox.Text = part.Max.ToString();
			minTextBox.Text = part.Min.ToString();

			// Now I am going to check if part is either in house or outsource
			if(part is InHouse inHousePart)
			{
				inHouseRadioButton.Checked = true;
				companyOrMachineTextBox.Text = inHousePart.MachineID.ToString();
			}
			else if(part is Outsourced outsourcedPart)
			{
				outsourcedRadioButton.Checked = true;
				companyOrMachineTextBox.Text = outsourcedPart.CompanyName;
			}
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			// Logic to save part info
			if(currentPart is InHouse && inHouseRadioButton.Checked)
			{
				((InHouse)currentPart).MachineID = int.Parse(companyOrMachineTextBox.Text);
			}
			else if (currentPart is Outsourced && outsourcedRadioButton.Checked)
			{
				((Outsourced)currentPart).CompanyName = companyOrMachineTextBox.Text;
			}

			currentPart.Name = nameTextBox.Text;
			currentPart.InStock = int.Parse(inventoryTextBox.Text);
			currentPart.Price = decimal.Parse(priceTextBox.Text);
			currentPart.Max = int.Parse(maxTextBox.Text);
			currentPart.Min = int.Parse(minTextBox.Text);

			// Update the part in the inventory
			inventory.UpdatePart(currentPart.PartID, currentPart);

			// Close the form and return to the main form
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
	
}
