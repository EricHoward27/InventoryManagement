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
		private ToolTip tooltip;
		public ModifyPartForm(Part part,Inventory inventory)
		{
			currentPart = part;
			this.inventory = inventory;
			InitializeComponents();
			PopulateFormData(part);


			// Check if part is InHouse or Outsourced
			if (part is InHouse inHousePart)
			{
				inHouseRadioButton.Checked = true;
				companyOrMachineTextBox.Text = inHousePart.MachineID.ToString();
				companyOrMachineLabel.Text = "Machine ID";
			}
			else if (part is Outsourced outsourcedPart)
			{
				outsourcedRadioButton.Checked = true;
				companyOrMachineTextBox.Text = outsourcedPart.CompanyName;
				companyOrMachineLabel.Text = "Company Name";
			}
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
			inHouseRadioButton.Checked = true;
			inHouseRadioButton.CheckedChanged += PartTypeRadioButton_CheckedChanged;
			Controls.Add(inHouseRadioButton);

			// OutSource Radio Button
			outsourcedRadioButton = new RadioButton();
			outsourcedRadioButton.Text = "OutSourced";
			outsourcedRadioButton.Location = new System.Drawing.Point(160, 50);
			outsourcedRadioButton.Size = new System.Drawing.Size(100, 30);
			Controls.Add(outsourcedRadioButton);

			// Labels and text boxes for part details
			// init the tooltip
			tooltip = new ToolTip();
			CreateLabelAndTextBox(out idLabel, out idTextBox, "ID", 80);
			idTextBox.Enabled = false;
			idTextBox.ReadOnly = true;
			CreateLabelAndTextBox(out nameLabel, out nameTextBox, "Name", 120);
			SetRequiredField(nameTextBox, "Part Name is required.");
			CreateLabelAndTextBox(out inventoryLabel, out inventoryTextBox, "Inventory", 160);
			SetRequiredField(inventoryTextBox, "Inventory value is required, must be number.");
			CreateLabelAndTextBox(out priceLabel, out priceTextBox, "Price", 200);
			SetRequiredField(priceTextBox, "Price value is required, must be number.");
			CreateLabelAndTextBox(out maxLabel, out maxTextBox, "Max", 240);
			SetRequiredField(maxTextBox, "Max value is required, must be number.");
			CreateLabelAndTextBox(out minLabel, out minTextBox, "Min", 280);
			SetRequiredField(minTextBox, "Min value is required, must be number.");
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

		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			// Initialize variables for validation
			int inv, min, max;
			decimal price;
			bool isValid = true;
			string errorMessage = "";

			// Validate Inventory
			if (!int.TryParse(inventoryTextBox.Text, out inv) || inv < 0)
			{
				isValid = false;
				errorMessage += "Inventory must be a positive integer.\n";
				inventoryTextBox.BackColor = Color.LightYellow;
			}

			// Validate Price
			if (!decimal.TryParse(priceTextBox.Text, out price) || price < 0)
			{
				isValid = false;
				errorMessage += "Price must be a positive decimal.\n";
				priceTextBox.BackColor = Color.LightYellow;
			}

			// Validate Min
			if (!int.TryParse(minTextBox.Text, out min) || min < 0)
			{
				isValid = false;
				errorMessage += "Min must be a positive integer.\n";
				minTextBox.BackColor = Color.LightYellow;
			}

			// Validate Max
			if (!int.TryParse(maxTextBox.Text, out max) || max < 0)
			{
				isValid = false;
				errorMessage += "Max must be a positive integer.\n";
				maxTextBox.BackColor = Color.LightYellow;
			}

			// Check if Min is greater than Max
			if (isValid && min > max)
			{
				isValid = false;
				errorMessage += "Min cannot be greater than Max.\n";
				minTextBox.BackColor = Color.LightYellow;
				maxTextBox.BackColor = Color.LightYellow;
			}

			// If validation fails, show error message and return
			if (!isValid)
			{
				MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Proceed with saving the part
			Part part;
			if (inHouseRadioButton.Checked)
			{
				part = new InHouse();
				if (!int.TryParse(companyOrMachineTextBox.Text, out int machineId))
				{
					MessageBox.Show("Machine ID must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					companyOrMachineTextBox.BackColor = Color.LightYellow;
					return;
				}
				((InHouse)part).MachineID = machineId;
			}
			else
			{
				part = new Outsourced();
				((Outsourced)part).CompanyName = companyOrMachineTextBox.Text;
			}
			part.PartID = int.Parse(idTextBox.Text);
			part.Name = nameTextBox.Text;
			part.InStock = inv;
			part.Price = price;
			part.Min = min;
			part.Max = max;

			// Update the part in the inventory
			this.inventory.UpdatePart(part.PartID, part);
			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SetRequiredField(TextBox textBox, string tooltipText)
		{
			// set the background color to red to indicate a required field
			textBox.BackColor = Color.LightYellow;

			// set the tooltip for the required field
			tooltip.SetToolTip(textBox, tooltipText);

			// add event handler to change the background color when the text box is empty
			textBox.TextChanged += (sender, e) =>
			{
				TextBox currentTextBox = sender as TextBox;

				if (string.IsNullOrEmpty(currentTextBox.Text))
				{
					currentTextBox.BackColor = Color.LightYellow;
				}
				else
				{
					currentTextBox.BackColor = SystemColors.Window;
				}
			};
		}

	}
	
}
