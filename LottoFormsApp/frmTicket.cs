using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lotto;  //  Lotto must be added as a reference to this project in the solution explorer window

namespace LottoFormsApp
{
    public partial class frmTicket : Form
    {
        // ******create a customer, sort out the tostring inheriting and also the luckystar array.
        List<Euro> Euros;
        Customer currentCustomer;
        Euro currentEuro;
        public frmTicket()
        {
            
            InitializeComponent();
            Euros = new List<Euro>();
            currentCustomer = new Customer();
        }

        private void BtnCreateTicket_Click(object sender, EventArgs e)
        {
            var tempEuro = new Euro();    //  creates a new Ticket object
            tempEuro.Customer = currentCustomer;   //  Takes the value from the text box named txtName and sets the ticket object name.
            int[] balls = { Convert.ToInt32(txtBall1.Text), Convert.ToInt32(txtBall2.Text), Convert.ToInt32(txtBall3.Text), Convert.ToInt32(txtBall4.Text), Convert.ToInt32(txtBall5.Text), Convert.ToInt32(txtBall6.Text)};
            int[] tempLucky = { Convert.ToInt32(txtLucky1.Text), Convert.ToInt32(txtLucky2.Text) };
            tempEuro.Numbers = balls;      // sets the Numbers array for the TestTicket object to equal the balls array
            try
            {
                //tempEuro.LuckyStar = Convert.ToInt32(txtBonus.Text);  // sets the TestTicket object bonus ball according to the rules in Ticket.cs
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   // if the bonus ball is not within 1 and 49 as dictated in ticket.cs an error will apply
            }
            tempEuro.LuckyStar = tempLucky;
            Euros.Add(tempEuro);
            currentEuro = tempEuro;
            MessageBox.Show("Ticket Created", "Lottery", MessageBoxButtons.OK);
            displayTicket();
        }
        private void displayTicket()
        {
            panTicket.BackColor = Color.FromArgb(245, 245, 245);

            lblName.Text = currentCustomer.Name;
            lblPhone.Text = currentCustomer.Phone;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye");
            Application.Exit();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnListTickets_Click(object sender, EventArgs e)
        {
            //Note: Ticket is the class, ticket is a temporary object for each loop iteration, 
            //tickets is the list of ticket objects
            foreach (Euro euroTicket in Euros)
            {
                lvTickets.Items.Add(euroTicket.ToString());
            }
        }

        private void BtnLuckyDip_Click(object sender, EventArgs e)
        {
            int[] tempNums = new int[7];

            tempNums = Ticket.RandomNum();

            txtBall1.Text = Convert.ToString(tempNums[0]);
            txtBall2.Text = Convert.ToString(tempNums[1]);
            txtBall3.Text = Convert.ToString(tempNums[2]);
            txtBall4.Text = Convert.ToString(tempNums[3]);
            txtBall5.Text = Convert.ToString(tempNums[4]);
            txtBall6.Text = Convert.ToString(tempNums[5]);
            txtLucky1.Text = Convert.ToString(tempNums[6]);
            txtLucky2.Text = "4";   //  note: the random generation will require to be changed to sub class, for now have fixed
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            currentCustomer.custID = Convert.ToInt32(txtID.Text);
            currentCustomer.Name = txtName.Text;
            currentCustomer.Phone = txtPhone.Text;
            currentCustomer.email = txtEmail.Text;
        }
    }
}
