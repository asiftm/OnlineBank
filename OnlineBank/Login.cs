using System;
using System.Windows.Forms;

namespace OnlineBank
{
    public partial class LogInPage : Form
    {
        public static string uEmail;
        public static string aEmail;

        public LogInPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginPageError.Visible = false;
            userEmail.Focus();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            User user = new User();

            if (userEmail.Text !=String.Empty && Password.Text != String.Empty)
            {
                user.Email = userEmail.Text;
                user.Password = Password.Text;
                if (user.VerifyUser(user)==true)
                {
                    uEmail = userEmail.Text;
                    userEmail.Text = string.Empty;
                    Password.Text = string.Empty;
                    loginPageError.Visible = false;
                    UserHomePage userHomePage = new UserHomePage();
                    userHomePage.Show();
                    this.Hide();
                }
                else
                {
                    loginPageError.Visible = true;
                    loginPageError.Text = ("Wrong User Email or Password");
                    userEmail.Focus();
                }
            }
            else
            {
                loginPageError.Visible = true;
                loginPageError.Text = ("Invalid input");
                userEmail.Focus ();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userEmail.Text = string.Empty;
            Password.Text = string.Empty;
            loginPageError.Visible = false;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CreateUser createAccount = new CreateUser();
            createAccount.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Admin admin = new Admin();

            if (userEmail.Text != String.Empty && Password.Text != String.Empty)
            {
                admin.Email = userEmail.Text;
                admin.Password = Password.Text;
                if (admin.VerifyUser(admin) == true)
                {
                    aEmail = userEmail.Text;
                    userEmail.Text = string.Empty;
                    Password.Text = string.Empty;
                    loginPageError.Visible = false;
                    AdminHomepage adminHomepage = new AdminHomepage();
                    adminHomepage.Show();
                    this.Hide();
                }
                else
                {
                    loginPageError.Visible = true;
                    loginPageError.Text = ("Wrong Admin Email or Password");
                    userEmail.Focus();
                }
            }
            else
            {
                loginPageError.Visible = true;
                loginPageError.Text = ("Invalid input");
                userEmail.Focus();
            }
        }
    }
}
