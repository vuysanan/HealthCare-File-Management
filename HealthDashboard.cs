using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HealthCareFileManagement
{
    public partial class Form1 : Form
    {
        public string name = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatientFile();

            txtID.ReadOnly = true;
            btnSearch.Enabled = false;
        }

        private void LoadPatientFile()
        {
            string connString = "Server=localhost;Database=HealthCare_File_Management;Uid=root;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string patientFileQuery = "SELECT * FROM patient WHERE patientID = @patientID";
                    MySqlCommand patientFileCmd = new MySqlCommand(patientFileQuery, conn);
                    patientFileCmd.Parameters.AddWithValue("@patientID", txtID.Text);
                    MySqlDataReader reader = patientFileCmd.ExecuteReader();

                    bool patientFound = reader.Read();

                    if (patientFound)
                    {
                        name = reader["patientName"].ToString();
                    }
                    reader.Close();

                    if (patientFound)
                    {
                        string visitsQuery = "SELECT visitID, visitDate FROM visit WHERE patientID = @patientID";
                        MySqlCommand visitsCmd = new MySqlCommand(visitsQuery, conn);
                        visitsCmd.Parameters.AddWithValue("patientID", txtID.Text);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(visitsCmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        ltbPreviousVisits.DataSource = dt;
                        ltbPreviousVisits.DisplayMember = "visitDate"; 
                        ltbPreviousVisits.ValueMember = "visitID"; 
                        lblEventShown.Text = "Previous Visits by: " + name;
                        lblEventShown.Visible = true;
                        ltbPreviousVisits.Visible = true;
                        btnAddNewVisit.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Patient not found. Create new file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblEventShown.Text = "New Patient";
                        txtShowID.Text = txtID.Text;
                        lblEventShown.Visible = true;
                        lblDisplayID.Visible = true;
                        txtShowID.Visible = true;
                        lblName.Visible = true;
                        txtEnterName.Visible = true;
                        lblSurname.Visible = true;
                        txtEnterSurname.Visible = true;
                        lblAddress.Visible = true;
                        txtAddress.Visible = true;
                        btnCreateFile.Visible = true;
                        btnDiscardFile.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void lblEventShown_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplayID_Click(object sender, EventArgs e)
        {

        }

        private void txtShowID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtEnterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSurname_Click(object sender, EventArgs e)
        {

        }

        private void txtEnterSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDiscardFile_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            CreateNewPatientFile();


            txtID.ReadOnly = true;
            btnSearch.Enabled = false;

            lblDisplayID.Visible = false;
            txtShowID.Visible = false;
            lblName.Visible = false;
            txtEnterName.Visible = false;
            lblSurname.Visible = false;
            txtEnterSurname.Visible = false;
            lblAddress.Visible = false;
            txtAddress.Visible = false;
            btnCreateFile.Visible = false;
            btnDiscardFile.Visible = false;

            lblEventShown.Text = "Previous Visits by: " + name;
            lblEventShown.Visible = true;
            ltbPreviousVisits.Visible = true;
            btnAddNewVisit.Visible = true;
        }

        private void CreateNewPatientFile()
        {
            string connString = "Server=localhost;Database=HealthCare_File_Management;Uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO patient (patientID, patientName, patientSurname, address) VALUES (@patientID, @patientName, @patientSurname, @address)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@patientID", txtID.Text);
                    insertCmd.Parameters.AddWithValue("@patientName", txtEnterName.Text);
                    insertCmd.Parameters.AddWithValue("@patientSurname", txtEnterSurname.Text);
                    insertCmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPatientFile(); // Refresh the form to show the new patient file
                    }
                    else
                    {
                        MessageBox.Show("Failed to create patient file.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ltbPreviousVisits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNewVisit_Click(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            btnSearch.Enabled = false;
            lblEventShown.Text = "New Visit by: " + name;
            lblEventShown.Visible = true;
            ltbPreviousVisits.Visible = false;
            btnAddNewVisit.Visible = false;

            lblVisitDate.Visible = true;
            txtVisitDate.Visible = true;
            lblComplaint.Visible = true;
            txtComplaint.Visible = true;
            lblExamNotes.Visible = true;
            txtExamNotes.Visible = true;
            Prescription.Visible = true;
            txtPrescription.Visible = true;
            btnFileVisit.Visible = true;

            txtVisitDate.Text = DateTime.Now.ToString();
        }

        private void lblVisitDate_Click(object sender, EventArgs e)
        {

        }

        private void txtVisitDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComplaint_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblComplaint_Click(object sender, EventArgs e)
        {

        }

        private void lblExamNotes_Click(object sender, EventArgs e)
        {

        }

        private void txtExamNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prescription_Click(object sender, EventArgs e)
        {

        }

        private void btnFileVisit_Click(object sender, EventArgs e)
        {
            SaveVisit();

            txtID.ReadOnly = true;
            btnSearch.Enabled = false;
            lblVisitDate.Visible = false;
            txtVisitDate.Visible = false;
            lblComplaint.Visible = false;
            txtComplaint.Visible = false;
            lblExamNotes.Visible = false;
            txtExamNotes.Visible = false;
            Prescription.Visible = false;
            txtPrescription.Visible = false;
            btnFileVisit.Visible = false;
        }

        private void SaveVisit()
        {
            string connString = "Server=localhost;Database=HealthCare_File_Management;Uid=root;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string insertQuery = "INSERT INTO visit (patientID, visitDate, complaint, physicalExaminationNotes, prescribedMedication) VALUES (@patientID, @visitDate, @complaint, @physicalExaminationNotes, @prescribedMedication)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@patientID", txtID.Text);
                    insertCmd.Parameters.AddWithValue("@visitDate", txtVisitDate.Text);
                    insertCmd.Parameters.AddWithValue("@complaint", txtComplaint.Text);
                    insertCmd.Parameters.AddWithValue("@physicalExaminationNotes", txtExamNotes.Text);
                    insertCmd.Parameters.AddWithValue("@prescribedMedication", txtPrescription.Text);
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Visit filed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //LoadPatientFile(); // Refresh the form to show the new visit
                    }
                    else
                    {
                        MessageBox.Show("Failed to file visit.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
