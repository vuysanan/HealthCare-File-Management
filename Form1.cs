using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareFileManagement
{
    public partial class MainForm : Form
    {
        Dictionary<long, File> fileMap = new Dictionary<long, File>();

        long patientId = 0;
        string name = "";
        string surname = "";
        DateTime visitDate = DateTime.Now;
        string complaint = "";
        string physicalExamNotes = "";
        string prescribedMedication = "";
        public MainForm()
        {
            InitializeComponent();
        }

        private void lblSearchRequest_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearchInput.Text))
                {
                    MessageBox.Show("Invalid ID. Please enter an ID that only has numeric values to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!long.TryParse(txtSearchInput.Text, out patientId))
                {
                    MessageBox.Show("Invalid ID. Please enter an ID that only has numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                patientId = long.Parse(txtSearchInput.Text);
                if (patientId.ToString().Length != 13)
                {
                    MessageBox.Show("Invalid ID. Please enter an ID that is 13 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (fileMap.ContainsKey(patientId))
                {
                    //lblSearchFeedback.Visible = true;
                    //lblSearchFeedback.Text = DisplayFile(patientId);

                    lblNewFileTitle.Visible = true;
                    lblNewFileTitle.Text = "Displaying Patient File";
                    lblFileId.Visible = true;
                    txtFileId.Visible = true;
                    txtFileId.Text = fileMap[patientId].Id.ToString();
                    lblFileName.Visible = true;
                    txtFileName.Visible = true;
                    txtFileName.Enabled = false;
                    txtFileName.Text = fileMap[patientId].Name;
                    lblFileSurname.Visible = true;
                    txtFileSurname.Visible = true;
                    txtFileSurname.Enabled = false;
                    txtFileSurname.Text = fileMap[patientId].Surname;
                    lblVisitDate.Visible = true;
                    dateTimePicker.Visible = true;
                    dateTimePicker.Enabled = false;
                    dateTimePicker.Value = fileMap[patientId].VisitDate;
                    lblFileComplaint.Visible = true;
                    rtbFileComplaint.Visible = true;
                    rtbFileComplaint.Enabled = false;
                    rtbFileComplaint.Text = fileMap[patientId].Complaint;
                    lblFilePhyscialExamNotes.Visible = true;
                    rtbFilePhysicalExamNotes.Visible = true;
                    rtbFilePhysicalExamNotes.Enabled = false;
                    rtbFilePhysicalExamNotes.Text = fileMap[patientId].PhysicalExamNotes;
                    lblFilePrescribedMed.Visible = true;
                    rtbFilePrescribedMedication.Visible = true;
                    rtbFilePrescribedMedication.Enabled = false;
                    rtbFilePrescribedMedication.Text = fileMap[patientId].PrescribedMedication;
                    btnSaveFile.Visible = true;
                    //btnSaveFile.Size = 140, 23;
                    btnSaveFile.Text = "New Vist";
                }
                else
                {
                    MessageBox.Show("There is no record of this patient. Create a new file.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtSearchInput.Enabled = false;
                    btnSearchID.Enabled = false;
                    lblNewFileTitle.Visible = true;
                    lblFileId.Visible = true;
                    txtFileId.Visible = true;
                    txtFileId.Text = patientId.ToString();
                    lblFileName.Visible = true;
                    txtFileName.Visible = true;
                    lblFileSurname.Visible = true;
                    txtFileSurname.Visible = true;
                    lblVisitDate.Visible = true;
                    dateTimePicker.Visible = true;
                    dateTimePicker.Value = DateTime.Now;
                    lblFileComplaint.Visible = true;
                    rtbFileComplaint.Visible = true;
                    lblFilePhyscialExamNotes.Visible = true;
                    rtbFilePhysicalExamNotes.Visible = true;
                    lblFilePrescribedMed.Visible = true;
                    rtbFilePrescribedMedication.Visible = true;
                    btnSaveFile.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while searching.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }

        }

        private void lblSearchFeedback_Click(object sender, EventArgs e)
        {
            Text = "I'm here";
        }

        /*private string DisplayFile(long patientId)
        {
            return String.Format($"Patient ID: {fileMap[patientId].Id} \nName: {fileMap[patientId].Name} \nSurname: {fileMap[patientId].Surname} \nVisit Date: {fileMap[patientId].VisitDate} \nComplaint: {fileMap[patientId].Complaint} \nPhysical Examination Notes: {fileMap[patientId].PhysicalExamNotes} \nPrescribed Medication: {fileMap[patientId].PrescribedMedication}");
        }*/

        private void lblFileComplaint_Click(object sender, EventArgs e)
        {

        }

        private void lblFileId_Click(object sender, EventArgs e)
        {

        }

        private void txtFileId_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFileName_Click(object sender, EventArgs e)
        {

        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFileSurname_Click(object sender, EventArgs e)
        {

        }

        private void txtFileSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFilePhyscialExamNotes_Click(object sender, EventArgs e)
        {

        }

        private void lblFilePrescribedMed_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                name = txtFileName.Text;
                surname = txtFileSurname.Text;
                visitDate = dateTimePicker.Value;
                complaint = rtbFileComplaint.Text;
                physicalExamNotes = rtbFilePhysicalExamNotes.Text;
                prescribedMedication = rtbFilePrescribedMedication.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Invalid input. Please enter the patient name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(surname))
                {
                    MessageBox.Show("Invalid input. Please enter the patient surname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                fileMap.Add(patientId, new File(patientId, name, surname, visitDate, complaint, physicalExamNotes, prescribedMedication));
                if (fileMap.ContainsKey(patientId))
                {
                    MessageBox.Show("Patient File Has Been Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSearchInput.Text = null; txtFileId.Text = null; txtFileName.Text = null; txtFileSurname.Text = null; rtbFileComplaint.Text = null; rtbFilePhysicalExamNotes.Text = null; rtbFilePrescribedMedication.Text = null;
                    txtSearchInput.Enabled = true;
                    btnSearchID.Enabled = true;
                    lblNewFileTitle.Visible = false;
                    lblFileId.Visible = false;
                    txtFileId.Visible = false;
                    lblFileName.Visible = false;
                    txtFileName.Visible = false;
                    lblFileSurname.Visible = false;
                    txtFileSurname.Visible = false;
                    lblVisitDate.Visible = false;
                    dateTimePicker.Visible = false;
                    lblFileComplaint.Visible = false;
                    rtbFileComplaint.Visible = false;
                    lblFilePhyscialExamNotes.Visible = false;
                    rtbFilePhysicalExamNotes.Visible = false;
                    lblFilePrescribedMed.Visible = false;
                    rtbFilePrescribedMedication.Visible = false;
                    btnSaveFile.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
        }

        private void lblSaveFeedback_Click(object sender, EventArgs e)
        {

        }

        private void rtbFileComplaint_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbFilePhysicalExamNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbFilePrescribedMedication_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNewFileTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
