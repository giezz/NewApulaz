using System;
using System.Linq;
using System.Windows.Forms;
using WinFormsEntityFrameWork.models;
using EntityState = System.Data.Entity.EntityState;

namespace WinFormsEntityFrameWork
{
    public partial class Form1 : Form
    {
        private int rowIndex = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Select();
        }

        private void Select()
        {
            using EmployeeContext employeeContext = new EmployeeContext();
            var employees = employeeContext.Employees.OrderByDescending(p => p.IdEmployee);
            dataGridView1.DataSource = employees.ToList();;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using EmployeeContext employeeContext = new EmployeeContext();
            employeeContext.Employees.Add(new Employees
            {
                Inn = txtInn.Text,
                DateOfBirth = dpDob.Value,
                FirstName = txtName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                DriverLicenceCategory = cbCategories.Text
            });
            
            employeeContext.SaveChanges();

            txtInn.Text = null;
            txtName.Text = null;
            txtLastName.Text = null;
            txtMiddleName.Text = null;
            txtPhone.Text = null;
            txtEmail.Text  = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            txtInn.Text = dataGridView1.Rows[e.RowIndex].Cells["Inn"].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
            txtMiddleName.Text = dataGridView1.Rows[e.RowIndex].Cells["MiddleName"].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employees model = new Employees();
            using EmployeeContext employeeContext = new EmployeeContext();
            model.IdEmployee = int.Parse(dataGridView1.Rows[rowIndex].Cells["IdEmployee"].Value.ToString());
            model = employeeContext.Employees.Where(p => p.IdEmployee == model.IdEmployee).FirstOrDefault();
            model.Inn = txtInn.Text;
            model.DateOfBirth = dpDob.Value;
            model.FirstName = txtName.Text;
            model.LastName = txtLastName.Text;
            model.MiddleName = txtMiddleName.Text;
            model.Phone = txtPhone.Text;
            model.Email = txtEmail.Text;
            model.DriverLicenceCategory = cbCategories.Text;
            employeeContext.Entry(model).State = EntityState.Modified;
            employeeContext.SaveChanges();
            
            Select();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Employees model = new Employees();
            using EmployeeContext employeeContext = new EmployeeContext();
            model.IdEmployee = int.Parse(dataGridView1.Rows[rowIndex].Cells["IdEmployee"].Value.ToString());
            model = employeeContext.Employees.Where(p => p.IdEmployee == model.IdEmployee).FirstOrDefault();
            model.Inn = txtInn.Text;
            model.DateOfBirth = dpDob.Value;
            model.FirstName = txtName.Text;
            model.LastName = txtLastName.Text;
            model.MiddleName = txtMiddleName.Text;
            model.Phone = txtPhone.Text;
            model.Email = txtEmail.Text;
            model.DriverLicenceCategory = cbCategories.Text;
            employeeContext.Employees.Remove(model);
            employeeContext.SaveChanges();

            Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using EmployeeContext employeeContext = new EmployeeContext();
            var employees = employeeContext.Employees
                .Where(p => p.Inn == txtInnFilter.Text, !string.IsNullOrEmpty(txtInnFilter.Text))
                .Where(p => p.FirstName == txtNameFilter.Text, !string.IsNullOrEmpty(txtNameFilter.Text))
                .Where(p => p.LastName == txtLastNameFilter.Text, !string.IsNullOrEmpty(txtLastNameFilter.Text))
                .Where(p => p.MiddleName == txtMiddleName.Text, !string.IsNullOrEmpty(txtMiddleNameFilter.Text))
                .Where(p => p.Phone == txtPhone.Text, !string.IsNullOrEmpty(txtPhoneFilter.Text))
                .Where(p => p.Email == txtEmail.Text, !string.IsNullOrEmpty(txtEmailFilter.Text));
            dataGridView1.DataSource = employees.ToList();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Select();
        }
    }
}