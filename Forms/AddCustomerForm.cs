using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using project1.Models;
using project1.Data;

namespace project1.Forms
{
    public partial class AddCustomerForm : Form
    {
        private TextBox txtFirstName, txtLastName, txtPersonalNumber, txtEmail;
        private ComboBox cbGender, cbCountry, cbCity;
        private DateTimePicker dtpBirthDate;
        private Button btnSave, btnCancel;
        private ShopDbContext _context;

        public AddCustomerForm()
        {
            _context = new ShopDbContext();
            InitializeComponents();
            LoadComboBoxes();
        }

        private void InitializeComponents()
        {
            this.Text = "ფიზიკური პირის დამატება";
            this.Size = new System.Drawing.Size(400, 450);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblFirstName = new Label { Text = "სახელი", Top = 20, Left = 20 };
            txtFirstName = new TextBox { Top = 40, Left = 20, Width = 300 };

            Label lblLastName = new Label { Text = "გვარი", Top = 80, Left = 20 };
            txtLastName = new TextBox { Top = 100, Left = 20, Width = 300 };

            Label lblPersonalNumber = new Label { Text = "პირადი ნომერი", Top = 140, Left = 20 };
            txtPersonalNumber = new TextBox { Top = 160, Left = 20, Width = 300 };

            Label lblBirthDate = new Label { Text = "დაბადების თარიღი", Top = 200, Left = 20 };
            dtpBirthDate = new DateTimePicker { Top = 220, Left = 20, Width = 300, Format = DateTimePickerFormat.Short };

            Label lblGender = new Label { Text = "სქესი", Top = 260, Left = 20 };
            cbGender = new ComboBox { Top = 280, Left = 20, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblCountry = new Label { Text = "ქვეყანა", Top = 320, Left = 20 };
            cbCountry = new ComboBox { Top = 340, Left = 20, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblCity = new Label { Text = "ქალაქი", Top = 380, Left = 20 };
            cbCity = new ComboBox { Top = 400, Left = 20, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblEmail = new Label { Text = "ელ-ფოსტა", Top = 440, Left = 20 };
            txtEmail = new TextBox { Top = 460, Left = 20, Width = 300 };

            btnSave = new Button { Text = "დამატება", Top = 510, Left = 20, Width = 140 };
            btnCancel = new Button { Text = "გაუქმება", Top = 510, Left = 180, Width = 140 };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[]
            {
                lblFirstName, txtFirstName,
                lblLastName, txtLastName,
                lblPersonalNumber, txtPersonalNumber,
                lblBirthDate, dtpBirthDate,
                lblGender, cbGender,
                lblCountry, cbCountry,
                lblCity, cbCity,
                lblEmail, txtEmail,
                btnSave, btnCancel
            });

            this.Height = 620;
        }

        private void LoadComboBoxes()
        {
            cbGender.DataSource = _context.Genders.ToList();
            cbGender.DisplayMember = "Name";
            cbGender.ValueMember = "Id";

            cbCountry.DataSource = _context.Countries.ToList();
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Id";

            cbCity.DataSource = _context.Cities.ToList();
            cbCity.DisplayMember = "Name";
            cbCity.ValueMember = "Id";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPersonalNumber.Text))
            {
                MessageBox.Show("შეავსეთ ყველა სავალდებულო ველი!");
                return;
            }

            var customer = new Customer
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                PersonalNumber = txtPersonalNumber.Text.Trim(),
                BirthDate = dtpBirthDate.Value.Date,
                GenderId = (int)cbGender.SelectedValue,
                CountryId = (int)cbCountry.SelectedValue,
                CityId = (int)cbCity.SelectedValue,
                Email = txtEmail.Text.Trim()
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            MessageBox.Show("მომხმარებელი წარმატებით დაემატა!");
            this.Close();
        }
    }
}
