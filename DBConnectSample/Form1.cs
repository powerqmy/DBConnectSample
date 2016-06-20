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
                var newStudent = new Student { Name = "StudentNew", Sex = 0 };
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            MessageBox.Show("Add DB Complete");
        }

        private void AddStudentInfo()
        {
            using (var context = new StudentContext())
            {
                var studentNoList = (from student in context.Students
                                      select student.StudentNo).ToList();

                var studentinfoNoList = context.StudentInfos.Where(studentInfo => studentNoList.Contains(studentInfo.StudentNo)).Select(studentInfo => studentInfo.StudentNo).ToList();

                var InsList = studentNoList.Where(no => !studentinfoNoList.Contains(no)).ToList();

                foreach (var studentNo in InsList)
                {
                    var newStudentInfo = new StudentInfo { StudentNo = studentNo, Father = "Father" };
                    context.StudentInfos.Add(newStudentInfo);
                }
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

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudentInfo();
        }
    }
}