using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAss3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) status = "Married";
            else status = "Unmarried";



            try
            {
                CustomerValidation objval = new CustomerValidation();
                objval.CheckCustomerName(txtName.Text);
                frmCustomerPreview objPreview = new frmCustomerPreview();
                objPreview.SetValues(txtName.Text, comboBox1.Text, Gender, Hobby, status);
                objPreview.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {//Open a Connection
            string strConnection = "Data Source=LAPTOP-M30S6I6Q;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "Select * From Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dtgCustomer.DataSource = objDataSet.Tables[0];

            objConnection.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";
            // open a Connection
            string strConnection = "Data Source=LAPTOP-M30S6I6Q;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "insert into customer(CustomerName,Country,Gender,Hobby,Married) values('" + txtName.Text + "','"
                + comboBox1.Text + "','"
                + Gender + "','"
                + Hobby + "',"
                + Status + ")";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();

            // close the Connection
            objConnection.Close();
            LoadCustomer();

        }

        private void LoadCustomer()
        {
            throw new NotImplementedException();
        }

        private void displayCustomer(string id)
        {
            string strConnection = "Data Source=LAPTOP-M30S6I6Q;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Select * From Customer where id =" + id;
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            //Bind Data with UI
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();

            lblID.Text = objDataSet.Tables[0].Rows[0][0].ToString().Trim(); ;

            txtName.Text = objDataSet.Tables[0].Rows[0][1].ToString().Trim();
            comboBox1.Text = objDataSet.Tables[0].Rows[0][2].ToString().Trim();
            string Gender = objDataSet.Tables[0].Rows[0][3].ToString().Trim();
            if (Gender.Equals("Male")) radioMale.Checked = true;
            else radioFemale.Checked = true;
            string Hobby = objDataSet.Tables[0].Rows[0][4].ToString().Trim();
            if (Hobby.Equals("Reading")) chkReading.Checked = true;
            else chkPainting.Checked = true;
            string Married = objDataSet.Tables[0].Rows[0][5].ToString().Trim();
            if (Married.Equals("True")) radioMarried.Checked = true;
            else radioUnmarried.Checked = true;                

        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string id = dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(id);
        }
        private void clearForm()
        {
            txtName.Text = "";
            comboBox1.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;
            chkPainting.Checked = false;
            chkReading.Checked = false;
            radioMarried.Checked = false;
            radioUnmarried.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";
            // open a Connection
            string strConnection = "Data Source=LAPTOP-M30S6I6Q;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            //Fire a Command
            string strCommand = "UPDATE Customer SET CustomerName=@CustomerName，Country=@Country,"+
              "Gender=@Gender,Hobby=@Hobby,Married=@Married WHERE id=@id";
            SqlCommand objCommand = new SqlCommand(strCommand,objConnection);
            objCommand.Parameters.AddWithValue("@CustomerName", txtName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Country", comboBox1.SelectedItem.ToString().Trim()); 
            objCommand.Parameters.AddWithValue("@Gender", Gender);
            objCommand.Parameters.AddWithValue("@Hobby", Hobby); 
            objCommand.Parameters.AddWithValue("@Married", Status);
            objCommand.Parameters.AddWithValue("@id", lblID.Text.Trim());
            objCommand.ExecuteNonQuery();
            // close the Connection
            objConnection.Close();
            clearForm();
            LoadCustomer();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strConnection = "Data Source=LAPTOP-M30S6I6Q;Initial Catalog=CustomerDB;Integrated Security=True;Pooling=False";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            // Fire a Command
            string strCommand = "Delete from Customer where id = '" + lblID.Text + "'";
            SqlCommand objCommand = new SqlCommand(strCommand,objConnection);
            objCommand.ExecuteNonQuery();
            // close the Connection
            objConnection.Close();
            clearForm();
            LoadCustomer();

        }
    }
}
