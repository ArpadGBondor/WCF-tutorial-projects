using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client =
                new EmployeeService.EmployeeServiceClient();
            EmployeeService.EmployeeEntity employee = client.GetEmployee(Convert.ToInt32(txtID.Text));
            if (employee == null)
            {
                lblMessage.Text = "Employee does not exist";
            }
            else
            {
                txtName.Text = employee.Name;
                txtGender.Text = employee.Gender;
                txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
                lblMessage.Text = "Employee retrieved";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeServiceClient client =
                new EmployeeService.EmployeeServiceClient();

            EmployeeService.EmployeeEntity employee = new EmployeeService.EmployeeEntity();
            employee.ID = Convert.ToInt32(txtID.Text);
            employee.Name = txtName.Text;
            employee.Gender = txtGender.Text;
            employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

            client.SaveEmployee(employee);
            lblMessage.Text = "Employee saved";
        }
    }
}