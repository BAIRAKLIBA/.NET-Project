using System;
using System.Drawing;
using System.Windows.Forms;

namespace project1.Forms
{
    public partial class MainMenu : Form
    {
        private Button btnAdmin;
        private Button btnProducts;
        private Button btnSales;
        private Button btnReports;

        private ContextMenuStrip adminContextMenuStrip;
        private ContextMenuStrip productsContextMenuStrip;
        private ContextMenuStrip salesContextMenuStrip;
        private ContextMenuStrip reportsContextMenuStrip;

        public MainMenu()
        {
            InitializeMainMenuComponents();
        }

        private void InitializeMainMenuComponents()
        {
            this.Text = "Main Menu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 300);

            // ---------- Buttons ----------

            btnAdmin = new Button
            {
                Text = "ადმინისტრირება",
                Location = new Point(10, 10),
                Size = new Size(180, 30)
            };
            btnAdmin.Click += BtnAdmin_Click;

            btnProducts = new Button
            {
                Text = "პროდუქტები",
                Location = new Point(200, 10),
                Size = new Size(180, 30)
            };
            btnProducts.Click += BtnProducts_Click;

            btnSales = new Button
            {
                Text = "გაყიდვები",
                Location = new Point(390, 10),
                Size = new Size(180, 30)
            };
            btnSales.Click += BtnSales_Click;

            btnReports = new Button
            {
                Text = "რეპორტები",
                Location = new Point(580, 10),
                Size = new Size(180, 30)
            };
            btnReports.Click += BtnReports_Click;

            // ---------- Context Menus ----------

            adminContextMenuStrip = new ContextMenuStrip();
            adminContextMenuStrip.Items.Add("დამატება", null, (s, e) =>
            {
                // ფიზიკური პირის ფორმის გახსნა
                var addCustomerForm = new AddCustomerForm();
                addCustomerForm.ShowDialog();
            });
            adminContextMenuStrip.Items.Add("რედაქტირება", null, (s, e) => MessageBox.Show("რედაქტირება დაჭერილია"));
            adminContextMenuStrip.Items.Add("წაშლა", null, (s, e) => MessageBox.Show("წაშლა დაჭერილია"));

            productsContextMenuStrip = new ContextMenuStrip();
            productsContextMenuStrip.Items.Add("დამატება", null, (s, e) => AddProduct());
            productsContextMenuStrip.Items.Add("დასაწყობება", null, (s, e) => StoreProduct());
            productsContextMenuStrip.Items.Add("რედაქტირება", null, (s, e) => EditProduct());
            productsContextMenuStrip.Items.Add("წაშლა", null, (s, e) => DeleteProduct());
            productsContextMenuStrip.Items.Add("ფასდაკლების მინიჭება", null, (s, e) => ApplyDiscount());
            productsContextMenuStrip.Items.Add("ჩამოწერა", null, (s, e) => WriteOffProduct());

            salesContextMenuStrip = new ContextMenuStrip();
            salesContextMenuStrip.Items.Add("პროდუქტის გაყიდვა", null, (s, e) => SellProduct());
            salesContextMenuStrip.Items.Add("გაყიდული პროდუქტები", null, (s, e) => ShowSoldProducts());

            reportsContextMenuStrip = new ContextMenuStrip();
            reportsContextMenuStrip.Items.Add("ფიზიკური პირების სია", null, (s, e) => ShowIndividualsList());
            reportsContextMenuStrip.Items.Add("პროდუქტის რეალიზაციის სტატისტიკა ქალაქების მიხედვით", null, (s, e) => ShowSalesStatsByCity());
            reportsContextMenuStrip.Items.Add("Top 3 ყველაზე მოთხოვნადი სპორტული ინვენტარი", null, (s, e) => ShowTop3SportsInventory());
            reportsContextMenuStrip.Items.Add("ძვირადღირებული წიგნები", null, (s, e) => ShowExpensiveBooks());
            reportsContextMenuStrip.Items.Add("3 წლამდე ბავშვებისთვის რეკომენდირებული სათამაშოები", null, (s, e) => ShowRecommendedToys());

            // ---------- Add buttons to form ----------
            this.Controls.Add(btnAdmin);
            this.Controls.Add(btnProducts);
            this.Controls.Add(btnSales);
            this.Controls.Add(btnReports);
        }

        // ---------- Button Click Handlers ----------

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            adminContextMenuStrip.Show(btnAdmin, new Point(0, btnAdmin.Height));
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            productsContextMenuStrip.Show(btnProducts, new Point(0, btnProducts.Height));
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            salesContextMenuStrip.Show(btnSales, new Point(0, btnSales.Height));
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            reportsContextMenuStrip.Show(btnReports, new Point(0, btnReports.Height));
        }

        // ---------- Products menu methods ----------

        private void AddProduct() => MessageBox.Show("დამატება დაჭერილია (პროდუქტები)");
        private void StoreProduct() => MessageBox.Show("დასაწყობება დაჭერილია");
        private void EditProduct() => MessageBox.Show("რედაქტირება დაჭერილია (პროდუქტები)");
        private void DeleteProduct() => MessageBox.Show("წაშლა დაჭერილია (პროდუქტები)");
        private void ApplyDiscount() => MessageBox.Show("ფასდაკლების მინიჭება დაჭერილია");
        private void WriteOffProduct() => MessageBox.Show("ჩამოწერა დაჭერილია");

        // ---------- Sales menu methods ----------

        private void SellProduct() => MessageBox.Show("პროდუქტის გაყიდვა დაჭერილია");
        private void ShowSoldProducts() => MessageBox.Show("გაყიდული პროდუქტები დაჭერილია");

        // ---------- Reports menu methods ----------

        private void ShowIndividualsList() => MessageBox.Show("ფიზიკური პირების სია");
        private void ShowSalesStatsByCity() => MessageBox.Show("სტატისტიკა ქალაქების მიხედვით");
        private void ShowTop3SportsInventory() => MessageBox.Show("Top 3 სპორტული ინვენტარი");
        private void ShowExpensiveBooks() => MessageBox.Show("ძვირადღირებული წიგნები");
        private void ShowRecommendedToys() => MessageBox.Show("3 წლამდე ბავშვებისთვის სათამაშოები");
    }
}
