
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NHibernate_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student st = new Student()
            {
                name = "Peterson Amakingi"
            };

            ISession isv = Sources.getSession();
            isv.SaveOrUpdate(st);
            isv.Transaction.Begin();
            isv.Transaction.Commit();
            Sources.CloseSession(isv);
            data();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data();



        }
        void data()
        {
            ISession isv = Sources.getSession();
            List<Student> students = isv.Query<Student>().ToList();

            dataGridView1.DataSource = students;
            Sources.CloseSession(isv);
        }
    }
}
