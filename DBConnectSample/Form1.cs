using DBConnectSample.DBContext;
using DBConnectSample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void AddStudent()
        {
            using (var context = new StudentContext())
            {
                var student1 = new Student { StudentNo = 1, Name = "Student001", Sex = 0 };
                var student2 = new Student { StudentNo = 2, Name = "Student002", Sex = 0 };
                context.Students.Add(student1);
                context.Students.Add(student2);
                context.SaveChanges();
            }

            MessageBox.Show("Add DB Complete");
        }

        private void FindStudentByNo(int studentno)
        {
            using (var context = new StudentContext())
            {
                var studentList = context.Students.Where(student => student.StudentNo == studentno).ToList();

                var nameStr = string.Empty;
                foreach (var student in studentList)
                {
                    nameStr += student.Name + ";";
                }
                MessageBox.Show(nameStr);
            }
        }

        private void FindStudentByName(string name)
        {
            using (var context = new StudentContext())
            {
                var studentList = from student in context.Students
                                  where string.Compare(student.Name, name) == 0
                                  select student;
                var nameStr = string.Empty;
                foreach (var student in studentList)
                {
                    nameStr += student.StudentNo.ToString() + ";";
                }
                MessageBox.Show(nameStr);
            }
        }

        // entity Framework 性能
        // https://msdn.microsoft.com/zh-cn/library/cc853327.aspx

        private void FindStudentBySex(short sex)
        {
            using (var context = new StudentContext())
            {
                var studentList = context.Students.Where(student => student.Sex == sex).ToList();
                var nameStr = string.Empty;
                foreach (var student in studentList)
                {
                    nameStr += student.Name + ";";
                }
                MessageBox.Show(nameStr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindStudentByNo(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FindStudentByName("Student002");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FindStudentBySex(0);
        }
    }
}
